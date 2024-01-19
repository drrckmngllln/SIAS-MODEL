using MySql.Data.MySqlClient;
using school_management_system_model.Forms.transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Classes
{
    internal class add_section
    {
        public string section_code {  get; set; }
        public string year_level { get; set; }
        public string course {  get; set; }
        public string number_of_students { get; set; }
        public string max_number_of_students { get; set; }
        public string status { get; set; }
        public string search {  get; set; }
       

        //public void loadAvailableSections()
        //{
        //    var con = new MySqlConnection(connection.con());
        //    var da = new MySqlDataAdapter("select * from sections where course = '"+ course +"' and status='Available'", con);
        //    da.Fill(frm_select_section.instance.dt);
        //}
        //public void searchSections()
        //{
        //    var con = new MySqlConnection(connection.con());
        //    var da = new MySqlDataAdapter("select * from sections where concat(section_code, course, section) like '%" + search + "%' and " +
        //        "course='" + course + "' and status='Available'", con);
        //    da.Fill(frm_select_section.instance.dt);
        //}
    }
}
