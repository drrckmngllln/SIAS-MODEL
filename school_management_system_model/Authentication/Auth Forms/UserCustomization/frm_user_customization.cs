using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Authentication.Auth_Forms.UserCustomization
{
    public partial class frm_user_customization : KryptonForm
    {
        public frm_user_customization(string email)
        {
            InitializeComponent();
            GetUserRecords(email);
        }

        private void GetUserRecords(string email)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from users where email='" + email + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            tLastname.Text = dt.Rows[0]["last_name"].ToString();
            tFirstname.Text = dt.Rows[0]["first_name"].ToString();
            tMiddlename.Text = dt.Rows[0]["middle_name"].ToString();
            tEmployeeId.Text = dt.Rows[0]["employee_id"].ToString();
            tEmail.Text = dt.Rows[0]["email"].ToString();

        }

        private void frm_user_customization_Load(object sender, EventArgs e)
        {

        }
    }
}
