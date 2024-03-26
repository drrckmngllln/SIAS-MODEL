using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class Course : BaseEntity
    {
        [MaxLength(100)]
        public string Code { get; set; }
        public string Description { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public Campus Campus { get; set; }
        public int CampusId { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public decimal MaxUnits { get; set; }
    }
}