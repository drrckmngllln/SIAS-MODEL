using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class Instructor : BaseEntity
    {
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        public InstructorPosition Position { get; set; }
        public int PositionId { get; set; }        
    }
}