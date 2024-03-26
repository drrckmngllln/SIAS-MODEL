using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class Discount : BaseEntity
    {
        [MaxLength(100)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string DiscountTarget { get; set; }
        public string Description { get; set; }
        public int DiscountPercentage { get; set; }
    }
}