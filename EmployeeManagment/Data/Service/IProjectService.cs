
using EmployeeManagment.Data.DTOs;

namespace EmployeeManagment.Data.Service
{
    public interface IProjectService
    {
        Task AddProjectAsync(ProjectDTO projectDTO);
        Task EditProjectAsync(ProjectDTO projectDTO);
        Task<List<ProjectDTO>> GetAllProjectDTOsAsync();
        Task<Project> GetProjectById(int? projectId);
        Task<ProjectDTO> GetProjectDTOByIdAsync(int? projectId);
        Task RemoveProjectAsync(Project project);
    }
}