using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class InstructorPosition : BaseEntity
    {
        [MaxLength(100)]
        public string PositionCode { get; set; }
        public string Description { get; set; }
    }
}