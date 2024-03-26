using Core.Entities.Settings;
using Core.Parameters.Settings;

namespace Core.Specifications.Settings
{
    public class CoursesSpecifications : BaseSpecification<Course>
    {
        public CoursesSpecifications(CoursesParameters parameter)
            : base (x => 
            (string.IsNullOrEmpty(parameter.Search) || x.Code.ToLower().Contains(parameter.Search) 
            || x.Description.ToLower().Contains(parameter.Search)) &&
            (!parameter.CampusId.HasValue || x.CampusId == parameter.CampusId) && 
            (!parameter.LevelId.HasValue || x.LevelId ==  parameter.LevelId) &&
            (!parameter.DepartmentId.HasValue || x.DepartmentId ==  parameter.DepartmentId))
        {
            AddInclude(x => x.Level);
            AddInclude(x => x.Campus);
            AddInclude(x => x.Department);
            AddOrderByDescending(x => x.Id);
            ApplyPaging(parameter.PageSize * (parameter.PageNumber - 1), parameter.PageNumber);
        }

        public CoursesSpecifications(int id) : base (x => x.Id == id)
        {
            
        }
    }
}
