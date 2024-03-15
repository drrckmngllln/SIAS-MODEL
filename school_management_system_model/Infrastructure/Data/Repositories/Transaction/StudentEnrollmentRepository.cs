using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class StudentEnrollmentRepository
    {
        public async Task<StudentEnrollmentStudentDetails> GetStudentDetails(int id)
        {
            var _studentAccountRepo = new StudentAccountRepository();
            var _studentCourseRepo = new StudentCourseRepository();

            var studentAccounts = await _studentAccountRepo.GetByIdAsync(id);
            var studentCourse = await _studentCourseRepo.GetByIdNumberAsync(id);

            var studentEnrollmentStudentDetail = new StudentEnrollmentStudentDetails
            {
                id = id,
                id_number = studentAccounts.id_number,
                student_name = studentAccounts.fullname,
                course = studentCourse.course,
                campus = studentCourse.campus,
                curriculum = studentCourse.curriculum,
                section = studentCourse.section,
                year_level = studentCourse.year_level,
                semester = studentCourse.semester
            };
            return studentEnrollmentStudentDetail;
        }
    }
}
