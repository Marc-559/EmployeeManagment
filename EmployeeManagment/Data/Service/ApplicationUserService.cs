using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Data.Service
{
    public class ApplicationUserService : IApplicationUserService
    {
        private ApplicationDbContext _context;
        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the currenUser with the username, (Email)
        /// and returns the ApplicationUser Object.
        /// If there is an Error exception is thrown.
        /// </summary>
        /// <param name="Username"></param>
        /// <exception cref="Exception"></exception>
        public async Task<ApplicationUser> GetCurrentUser(string Username)
        {
            try
            {
                return await _context.Users.Where(x => x.UserName == Username).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get current user: {ex.Message}");
            }
        }

        /// <summary>
        /// Simple request to get all Users from the database.
        /// if there is an error then an Exception is thrown
        /// </summary>
        /// <returns>List<ApplicationUser></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get current user: {ex.Message}");
            }
        }

        /// <summary>
        /// I had to split the linq request because I got errors if i didn't.
        /// First request is to get the Id from the currentUser, 
        /// and then the secend request gives back the UserRoleId from the currenUser.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>UserRoleId</returns>
        public async Task<string> GetUserRoleIdFromUser(string username)
        {
            string userId = await _context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstAsync();

            return await _context.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId).FirstAsync();
        }
    }
}
