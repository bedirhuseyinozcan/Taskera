using MediatR;
using Taskera.Domain.Shared;

namespace Taskera.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }