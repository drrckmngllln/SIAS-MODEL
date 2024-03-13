using school_management_system_model.Core.Entities;

namespace school_management_system_model.Core.Dtos
{
    internal class UserCredentialDto : BaseEntity
    {
        public string email { get; set; }
        public string Username { get; set; }
        public int IsAdd { get; set; }
        public int IsEdit { get; set; }
        public int IsDelete { get; set; }
        public int IsAdministrator { get; set; }
    }
}
