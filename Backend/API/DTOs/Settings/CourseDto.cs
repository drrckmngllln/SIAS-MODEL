namespace API.DTOs.Settings
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string Campus { get; set; }
        public string Department { get; set; }
        public decimal MaxUnits { get; set; }
    }
}
