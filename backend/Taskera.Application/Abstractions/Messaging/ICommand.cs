using MediatR;
using Taskera.Domain.Shared;

namespace Taskera.Application.Abstractions.Messaging;

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }