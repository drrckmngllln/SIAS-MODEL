using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class LabFee : BaseEntity
    {
        [MaxLength(100)]
        public string Category { get; set; }
        public string Description { get; set; }
        public Campus Campus { get; set; }
        public int CampusId { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public int YearLevel { get; set; }
        public int Semester { get; set; }
        public decimal Amount { get; set; }
    }
}