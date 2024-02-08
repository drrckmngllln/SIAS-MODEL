namespace school_management_system_model.Core.Entities
{
    internal class Curriculums
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string campus_id { get; set; }
        public string course_id { get; set; }
        public string effective { get; set; }
        public string expires { get; set; }
        public string status { get; set; }

    }
}
