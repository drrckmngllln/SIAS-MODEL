
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model
{
    internal class connection
    {
       
        public static string con()
        {
            return ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
        }
    }
}
