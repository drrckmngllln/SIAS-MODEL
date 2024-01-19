using school_management_system_model.Toastr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    public class Toastr
    {
        public Toastr(string type, string message)
        {
            Type = type;
            Message = message;
            toast();
        }

        public string Type { get; }
        public string Message { get; }

        public void toast()
        {
            var frm = new frm_toastr(Type, Message);
            frm.ShowDialog();
        }
    }
}
