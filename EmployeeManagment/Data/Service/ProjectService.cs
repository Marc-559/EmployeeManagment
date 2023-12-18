using EmployeeManagment.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Data.Service
{
    public class ProjectService : IProjectService
    {
        private ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Projects and creates a DTO for each project and returns all DTOs
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProjectDTO>> GetAllProjectDTOsAsync()
        {
            return await _context.Projects.Select(x => new ProjectDTO
            {
                Id = x.Id,
                ClientName = x.ClientName,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
        }

        /// <summary>
        /// Gets a specific Project by Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Project> GetProjectById(int? projectId)
        {
            try
            {
                return await _context.Projects.Where(x => x.Id == projectId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get customer by id. See following exception: {ex}");
            }
        }

        /// <summary>
        /// Gets a specific Project by Id, creates and returns a DTO with the values of the specific project.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProjectDTO> GetProjectDTOByIdAsync(int? projectId)
        {
            try
            {
                return await _context.Projects.Where(x => x.Id == projectId).Select(x => new ProjectDTO
                {
                    Id = x.Id,
                    ClientName = x.ClientName,
                    Name = x.Name,
                    Description = x.Description
                }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get customer by id. See following exception: {ex}");
            }
        }

        /// <summary>
        /// Creates a new Project with ProjectDTO values and adds it to the database
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        public async Task AddProjectAsync(ProjectDTO projectDTO)
        {
            await _context.Projects.AddAsync(new Project()
            {
                Name = projectDTO.Name,
                ClientName = projectDTO.ClientName,
                Description = projectDTO.Description,
                Users = new List<ApplicationUser>(),
                workingTimes = new List<WorkingTime>()
            });
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits a already existing project with the ProjectDTO values and saves the changes.
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        public async Task EditProjectAsync(ProjectDTO projectDTO)
        {
            Project project = await GetProjectById(projectDTO.Id);

            project.Description = projectDTO.Description;
            project.Name = projectDTO.Name;
            project.ClientName = projectDTO.ClientName;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an existing Project from the Database and saves the changes
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public async Task RemoveProjectAsync(Project project)
        {
            _context.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
