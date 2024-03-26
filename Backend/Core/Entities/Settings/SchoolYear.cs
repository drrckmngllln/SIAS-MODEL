using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class SchoolYear : BaseEntity
    {
        [MaxLength(100)]
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime SchoolYearStart { get; set; }
        public DateTime SchoolYearEnd { get; set; }
        public int Semester { get; set; }
        public bool IsCurrent { get; set; }
    }
}