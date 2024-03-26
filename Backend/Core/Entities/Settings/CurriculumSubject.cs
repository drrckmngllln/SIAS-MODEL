using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class CurriculumSubject : BaseEntity
    {
        public Curriculum Curriculum { get; set; }
        public int CurriculumId { get; set; }
        public int YearLevel { get; set; }
        public int Semester { get; set; }
        [MaxLength(100)]
        public string SubjectCode { get; set; }
        public string DescriptiveTitle { get; set; }
        public decimal TotalUnits { get; set; }
        public decimal LectureUnits { get; set; }
        public decimal LabUnits { get; set; }
        public string PreRequisite { get; set; }
        public decimal TotalHoursPerWeek { get; set; }
    }
}