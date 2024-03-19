namespace school_management_system_model.Core.Entities.Transaction
{
    internal class ExternalCredential : BaseEntity
    {
        public string id_number { get; set; }
        public string unique_id { get; set; }
        public string school_year { get; set; }
        public string subject_code { get; set; }
        public string descriptive_title { get; set; }
        public string pre_requisite { get; set; }
        public decimal total_units { get; set; }
        public decimal lecture_units { get; set; }
        public decimal lab_units { get; set; }
        public decimal grade { get; set; }
        public string remarks { get; set; }
    }
}
