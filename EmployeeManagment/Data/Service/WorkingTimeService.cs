using EmployeeManagment.Data.DTOs;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagment.Data.Service
{
    public class WorkingTimeService : IWorkingTimeService
    {
        private ApplicationDbContext _context;
        
        public WorkingTimeService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a specific WorkingTime by Id
        /// </summary>
        /// <param name="workingTimeId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WorkingTime> GetWorkingTimeByIdAsync(int? workingTimeId)
        {
            return await _context.WorkingTimes.Where(x => x.Id == workingTimeId).Include(nameof(ApplicationUser)).Include(nameof(Project)).FirstAsync();
        }

        /// <summary>
        /// Gets a specific WorkingTime with a projectI.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<List<WorkingTime>> GetWorkingTimeWithProjectId(int? projectId)
        {
            return await _context.WorkingTimes.Where(x => x.ProjectId == projectId).Include(nameof(ApplicationUser)).Include(nameof(Project)).OrderBy(x => x.ApplicationUser.UserName).ToListAsync();
        }

        /// <summary>
        /// Gets a specific WorkingTime by Id, creates and returns a DTO with the values of the specific WorkingTime.
        /// </summary>
        /// <param name="workingTimeID"></param>
        /// <returns></returns>
        public async Task<WorkingTimeDTO> GetWorkingTimeDTOByIdAsync(int? workingTimeID)
        {
            return await _context.WorkingTimes.Where(x => x.Id == workingTimeID).Include(nameof(Project)).Select(x => new WorkingTimeDTO
            {
                Id = x.Id,
                TimestampBegin = x.TimestampBegin,
                TimestampEnd = x.TimestampEnd,
                Description = x.Description,
                Project = x.Project,
            }).FirstAsync();
        }

        /// <summary>
        /// Gets all WorkingTimes and creates a DTO for each WorkingTime and returns all DTOs 
        /// </summary>
        /// <returns></returns>
        public async Task<List<WorkingTimeDTO>> GetAllWorkingTimeDTOsAsync()
        {
            return await _context.WorkingTimes.Include(nameof(Project)).Select(x => new WorkingTimeDTO
            {
                Id = x.Id,
                TimestampBegin = x.TimestampBegin,
                TimestampEnd = x.TimestampEnd,
                Description = x.Description,
                Project = x.Project
            }).OrderBy(x => x.TimestampEnd).ToListAsync();
        }

        /// <summary>
        /// Creates a new WorkingTime with WorkingTimeDTO values and adds it to the database 
        /// </summary>
        /// <param name="workingTimeDTO"></param>
        /// <param name="currentUser"></param>
        /// <param name="selectedProject"></param>
        /// <returns></returns>
        public async Task AddWorkingTimeAsync(WorkingTimeDTO workingTimeDTO, ApplicationUser currentUser, Project selectedProject)
        {
            await _context.WorkingTimes.AddAsync(new WorkingTime()
            {
                Date = DateTime.Now,
                TimestampBegin = workingTimeDTO.TimestampBegin,
                TimestampEnd = workingTimeDTO.TimestampEnd,
                Description = workingTimeDTO.Description,
                ApplicationUser = currentUser,
                Project = selectedProject,
                ProjectId = workingTimeDTO.SelectedProjectId,
            });
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits a already existing WorkingTime with the WorkingTimeDTO values and saves the changes. 
        /// </summary>
        /// <param name="workingTimeDTO"></param>
        /// <returns></returns>
        public async Task EditWorkingTimeAsync(WorkingTimeDTO workingTimeDTO)
        {
            WorkingTime workingTime = await GetWorkingTimeByIdAsync(workingTimeDTO.Id);

            workingTime.TimestampBegin = workingTimeDTO.TimestampBegin;
            workingTime.TimestampEnd = workingTimeDTO.TimestampEnd;
            workingTime.Description = workingTimeDTO.Description;

            _context.WorkingTimes.Update(workingTime);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an existing workTime from the Database and saves the changes 
        /// </summary>
        /// <param name="workingTime"></param>
        /// <returns></returns>
        public async Task RemoveWorkingTimeAsync(WorkingTime workingTime)
        {
            _context.Remove(workingTime);
            await _context.SaveChangesAsync();
        }
    }

 
}

