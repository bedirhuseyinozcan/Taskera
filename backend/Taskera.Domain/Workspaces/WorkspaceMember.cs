using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Workspaces
{
    public class WorkspaceMember : Entity
    {
        public UserId UserId { get; set; }
        public TeamRole Role { get; set; }

        internal WorkspaceMember(UserId userId, TeamRole role)
        {
            UserId = userId;
            Role = role;
        }
        internal void ChangeRole(TeamRole role)
        {
            Role = role; 
        }
    }
}
