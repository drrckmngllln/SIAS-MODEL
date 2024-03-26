using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class Curriculum : BaseEntity
    {
        [MaxLength(100)]
        public string Code { get; set; }
        public string Description { get; set; }
        public Campus Campus { get; set; }
        public int CampusId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public DateTime Effective { get; set; }
        public DateTime Expires { get; set; }
    }
}