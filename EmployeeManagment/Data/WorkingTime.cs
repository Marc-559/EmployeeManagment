using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Data
{
    public class WorkingTime
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
        public DateOnly TimestampBegin { get; set; }
        public DateOnly TimestampEnd { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

