using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Data.DTOs
{
    public class WorkingTimeDTO
    {
        public int? Id { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
        public DateOnly TimestampBegin { get; set; } = new DateOnly();
        public DateOnly TimestampEnd { get; set; } = new DateOnly();
        public int SelectedProjectId { get; set; }
        public Project Project { get; set; } = new Project();
    }
}
