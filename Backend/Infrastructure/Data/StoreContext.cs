using Core.Entities.Settings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        // Settings
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<CurriculumSubject> CurriculumSubjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorPosition> InstructorPositions { get; set; }
        public DbSet<LabFee> LabFees { get; set; }
        public DbSet<LabFeeSubject> LabFeeSubjects { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<MiscellaneousFee> MiscellaneousFees { get; set; }
        public DbSet<OtherFee> OtherFees { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionSubject> SectionSubjects { get; set; }
        public DbSet<TuitionFee> TuitionFees { get; set; }

    }
}