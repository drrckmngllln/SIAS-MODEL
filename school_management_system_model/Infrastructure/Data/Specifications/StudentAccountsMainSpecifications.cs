using school_management_system_model.Core.Dtos;
using school_management_system_model.Infrastructure.Data.Parameters;

namespace school_management_system_model.Infrastructure.Data.Specifications
{
    internal class StudentAccountsMainSpecifications : BaseSpecification<StudentAccountDetailDto>
    {
        public StudentAccountsMainSpecifications(StudentAccountsMainParameters studentParams)
            : base(x =>
            (string.IsNullOrEmpty(studentParams.Search) || x.name.ToLower().Contains(studentParams.Search) &&
            (!studentParams.course_id.HasValue || x.course == studentParams.course_id.ToString())))
        {
            AddInclude(x => x.course);
            ApplyPaging(studentParams.PageSize * (studentParams.PageNumber - 1), studentParams.PageNumber);
        }

        public StudentAccountsMainSpecifications(int id) 
            : base(x => x.id == id)
        {
        }

    }
}
