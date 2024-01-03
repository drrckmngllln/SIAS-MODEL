using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Controls
{
    internal interface IAuthorization<T> where T : session
    {
        Task<bool> isAdd {  get; }
        Task<bool> isEdit { get; }
        Task<bool> isRemove { get; }
    }
}
