using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class MainRegistrar
    {
        public MainRegistrar(string enrollmentType)
        {
            EnrollmentType = enrollmentType;
        }

        public string EnrollmentType { get; }

        public bool ScheduleChecker()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from admission_schedule where code='" + EnrollmentType + "' order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            bool result;
            var from = Convert.ToDateTime(dt.Rows[0]["schedule_from"].ToString());
            var to = Convert.ToDateTime(dt.Rows[0]["schedule_to"].ToString());
            if (from < DateTime.Now && to > DateTime.Now)
            {
                result = true;
            }
            else { result = false; }
            return result;
        }
    }
}
