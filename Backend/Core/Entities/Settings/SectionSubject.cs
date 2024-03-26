using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class SectionSubject : BaseEntity
    {
        public Section Section { get; set; }
        public int SectionId { get; set; }
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
        [MaxLength(100)]
        public string PreRequisite { get; set; }
        [MaxLength(50)]
        public string Time { get; set; }
        [MaxLength(50)]
        public string Day { get; set; }
        [MaxLength(50)]
        public string Room { get; set; }
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
    }
}