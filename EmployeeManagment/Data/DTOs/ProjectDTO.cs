using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Data.DTOs
{
    public class ProjectDTO
    {
        public int? Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ClientName { get; set; } = string.Empty;
    }
}
