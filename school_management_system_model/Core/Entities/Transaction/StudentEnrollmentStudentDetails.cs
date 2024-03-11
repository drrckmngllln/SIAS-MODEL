namespace school_management_system_model.Core.Entities.Transaction
{
    internal class StudentEnrollmentStudentDetails : BaseEntity
    {
        public string id_number { get; set; }
        public string student_name { get; set; }
        public string course { get; set; }
        public string campus { get; set; }
        public string curriculum { get; set; }
        public string section { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
    }
}
