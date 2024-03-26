using Core.Entities.Settings;
using Core.Parameters.Settings;

namespace Core.Specifications.Settings
{
    public class CampusesSpecifications : BaseSpecification<Campus>
    {
        public CampusesSpecifications(CampusesParameters parameter)
            : base (x =>
            (string.IsNullOrEmpty(parameter.Search) || x.Code.ToLower().Contains(parameter.Search) 
            || x.Description.ToLower().Contains(parameter.Search)))
        {
            AddOrderByDescending(x => x.Id);
            ApplyPaging(parameter.PageNumber * (parameter.PageSize - 1), parameter.PageNumber);
        }

        public CampusesSpecifications(int id) : base (x => x.Id == id)
        {
        }
    }
}
