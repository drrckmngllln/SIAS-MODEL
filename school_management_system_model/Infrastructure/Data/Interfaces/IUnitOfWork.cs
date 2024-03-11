using System;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        Task<T> Repository<T>() where T : class;
    }
}
