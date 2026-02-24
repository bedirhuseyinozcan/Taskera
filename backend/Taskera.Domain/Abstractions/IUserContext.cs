using Taskera.Domain.Identity;

namespace Taskera.Domain.Abstractions
{
    public interface IUserContext
    {
        UserId UserId { get; }
    }
}