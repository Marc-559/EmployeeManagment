
using EmployeeManagment.Data.DTOs;

namespace EmployeeManagment.Data.Service
{
    public interface IWorkingTimeService
    {
        Task AddWorkingTimeAsync(WorkingTimeDTO workingTimeDTO, ApplicationUser currentUser, Project selectedProject);
        Task EditWorkingTimeAsync(WorkingTimeDTO workingTimeDTO);
        Task<List<WorkingTimeDTO>> GetAllWorkingTimeDTOsAsync();
        Task<WorkingTime> GetWorkingTimeByIdAsync(int? workingTimeId);
        Task<WorkingTimeDTO> GetWorkingTimeDTOByIdAsync(int? workingTimeID);
        Task<List<WorkingTime>> GetWorkingTimeWithProjectId(int? projectId);
        Task RemoveWorkingTimeAsync(WorkingTime workingTime);
    }
}