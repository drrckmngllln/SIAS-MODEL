using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Settings
{
    public class LabFeeSubject : BaseEntity
    {
        public LabFee LabFee { get; set; }
        public int LabFeeId { get; set; }
        [MaxLength(100)]
        public string SubjectCode { get; set; }
        public string DescriptiveTitle { get; set; }
    }
}