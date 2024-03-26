using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class Level : BaseEntity
    {
        [MaxLength(100)]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}