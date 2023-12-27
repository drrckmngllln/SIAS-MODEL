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
        public void toast(string type, string message)
        {
            var frm = new frm_toastr(type, message);
            frm.ShowDialog();
        }
    }
}
