namespace school_management_system_model.Core.Dtos
{
    internal class StudentAccountDetailDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public string campus { get; set; }
        public string status { get; set; }
    }
}
