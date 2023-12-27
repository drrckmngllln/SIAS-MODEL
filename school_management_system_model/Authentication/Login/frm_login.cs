using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Authentication.Auth_Forms.Registrar;
using school_management_system_model.Classes;
using school_management_system_model.Controls;
using school_management_system_model.Forms.main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Authentication.Login
{
    public partial class frm_login : KryptonForm
    {
        private const int CS_DropShadow = 0x20000;

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }
        public frm_login()
        {
            this.BackColor = Color.White;
            InitializeComponent();
        }

        

        private void loginAuthentication(string email, string password)
        {
            
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from users where email='"+ email +"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            var compare = dt.Rows[0]["password"].ToString();
            bool passwordMatching = BCrypt.Net.BCrypt.Verify(password, compare);
            if (passwordMatching)
            {
                UserName = dt.Rows[0]["fullname"].ToString();
                Email = dt.Rows[0]["email"].ToString();
                Password = dt.Rows[0]["password"].ToString();
                AccessLevel = dt.Rows[0]["access_level"].ToString();
                isAdd = Convert.ToBoolean(dt.Rows[0]["is_add"]);
                isEdit = Convert.ToBoolean(dt.Rows[0]["is_edit"]);
                isDelete = Convert.ToBoolean(dt.Rows[0]["is_delete"]);
                switch (AccessLevel)
                {
                    case "Administrator":
                        new Classes.Toastr().toast("Success", "Administrator Login Success!");
                        var frm = new frm_main_registrar
                        {
                            fullname = UserName,
                            email = Email,
                            password = Password,
                            access_level = AccessLevel,
                            is_add = isAdd,
                            is_delete = isDelete,
                            is_edit = isEdit
                        };
                        frm.Show();
                        this.Hide();
                        break;
                }
            }
            else
            {
                new Classes.Toastr().toast("Warning", "Authentication Problem");
            }

        }

        private void frm_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D1)
            {
                new Classes.Toastr().toast("Success", "Login Successful");
                var frm = new main_form();
                frm.ShowDialog();
                this.Hide();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            loginAuthentication(tUserName.Text, tPassword.Text);
        }
    }
}
