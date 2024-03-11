using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Repositories
{
    internal class UnitOfWork
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> Repository<T>() where T : class
        {
            //if (typeof(T) == typeof(StudentAccountRepository))
            //{
            //    var repo = new StudentAccountRepository();
            //    var defaultMethod = repo.GetAllAsync();
            //    return List<defaultMethod>;
            //}
            //if (typeof (T) == typeof(StudentCourseRepository))
            //{
            //    var repo = new StudentCourseRepository();
            //    var defaultMethod = repo.GetAllAsync();
            //    return defaultMethod;
            //}

            return null;
        }
    }
}
