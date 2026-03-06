using MediatR;
using Taskera.Application.Abstractions.Messaging;

public sealed record DeleteWorkspaceCommand(Guid WorkspaceId) : ICommand<Unit>;