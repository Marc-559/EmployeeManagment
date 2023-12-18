

namespace EmployeeManagment.Data.Service
{
    public interface IApplicationUserService
    {
        Task<List<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetCurrentUser(string Username);
        Task<string> GetUserRoleIdFromUser(string username);
    }
}