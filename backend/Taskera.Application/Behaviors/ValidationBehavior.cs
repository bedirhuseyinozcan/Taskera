using FluentValidation;
using MediatR;
using Taskera.Domain.Shared;
using Taskera.Domain.Shared.Enums;

namespace Taskera.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (failures.Count == 0) return await next();

        // Buradaki Error dönüşü senin Domain.Shared içindeki Error yapına göre ayarlanmalı
        // ValidationBehavior.cs içinde ilgili satırı şöyle güncelle:
        var error = new Error("Validation.Error", failures.First().ErrorMessage, ErrorType.Validation);

        // Result.Fail dönen bir response oluşturur
        return (TResponse)typeof(Result<>)
            .MakeGenericType(typeof(TResponse).GetGenericArguments()[0])
            .GetMethod("Fail")!
            .Invoke(null, new object[] { error })!;
    }
}