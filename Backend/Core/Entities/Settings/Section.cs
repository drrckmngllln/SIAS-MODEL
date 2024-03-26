using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class Section : BaseEntity
    {
        [MaxLength(100)]
        public string Code { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public int YearLevel { get; set; }
        public int Semester { get; set; }
        [MaxLength(100)]
        public string SectionName { get; set; }
        [Range(0, 50, ErrorMessage = "Value must be between 0 and 50")]
        public int NumberOfStudents { get; set; } = 0;
        [MaxLength(100)]
        public string Status { get; set; }
        [MaxLength(100)]
        public string Remarks { get; set; }
    }
}