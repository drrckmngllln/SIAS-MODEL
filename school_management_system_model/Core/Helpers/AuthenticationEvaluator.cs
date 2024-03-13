using DocumentFormat.OpenXml.Office2010.Excel;
using school_management_system_model.Core.Dtos;
using school_management_system_model.Data.Repositories.Setings;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Helpers
{
    internal class AuthenticationEvaluator
    {
        UserRepository _userRepo = new UserRepository();
       
        public async Task<UserCredentialDto> CheckUserCredential(string email)
        {
            var users = await _userRepo.GetByEmailAsync(email);
            var user = new UserCredentialDto
            {
                id = users.id,
                email = users.email,
                Username = users.fullname,
                IsAdd = users.add,
                IsEdit = users.edit,
                IsDelete = users.delete,
                IsAdministrator = users.administrator
            };
            return user;
        }

    }
}
