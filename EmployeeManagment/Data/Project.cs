using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EmployeeManagment.Data
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ClientName { get; set; } = string.Empty;

        public List<ApplicationUser> Users { get; set; }
        public List<WorkingTime> workingTimes { get; set; }
    }
}
