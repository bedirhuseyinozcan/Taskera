namespace Taskera.Application.Features.Workspaces.DTOs
{
    public class WorkspaceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<WorkspaceMemberDTO> Members { get; set; } = new List<WorkspaceMemberDTO>();
    }

    public class WorkspaceMemberDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Role {  get; set; }
    }
}
