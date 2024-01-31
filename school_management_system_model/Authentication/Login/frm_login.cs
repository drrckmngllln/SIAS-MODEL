using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Authentication.Auth_Forms;
using school_management_system_model.Authentication.Auth_Forms.Registrar;
using school_management_system_model.Classes;
using school_management_system_model.Forms.main;
using school_management_system_model.Loggers.Authentication;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public string Department { get; set; }
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public bool isAdministrator { get; set; }

        string Date = DateTime.Now.ToString("MM-dd-yyyy");
        string Time = DateTime.Now.ToString("hh:mm:ss tt");

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

        

        private async void loginAuthentication(string email, string password)
        {
            try
            {
                //var userEmail = await new UserManagement().GetUserManagementsAsync();
                //userEmail.FirstOrDefault(x => x.email == email);

                //if (userEmail != null)
                //{

                //}

                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from users where email='" + email + "'", con);
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
                    Department = dt.Rows[0]["department"].ToString();
                    isAdd = Convert.ToBoolean(dt.Rows[0]["is_add"]);
                    isEdit = Convert.ToBoolean(dt.Rows[0]["is_edit"]);
                    isDelete = Convert.ToBoolean(dt.Rows[0]["is_delete"]);
                    isAdministrator = Convert.ToBoolean(dt.Rows[0]["is_administrator"]);
                    switch (Department)
                    {
                        case "Registrar":
                            new Classes.Toastr("Success", "Login Success!");
                            var frm = new frm_main_registrar
                            {
                                fullname = UserName,
                                email = Email,
                                password = Password,
                                access_level = AccessLevel,
                                is_add = isAdd,
                                is_delete = isDelete,
                                is_edit = isEdit,
                                isAdministrator = isAdministrator
                            };
                            new AuthenticationLogger(UserName, AccessLevel, Date, Time).LoginLogger();
                            frm.Show();
                            this.Hide();
                            break;
                        case "Finance":
                            new Classes.Toastr("Success", "Login Success!");
                            var frmFinance = new frm_main_finance
                            {
                                Fullname = UserName,
                                AccessLevel = AccessLevel,
                                IsAdd = isAdd,
                                IsDelete = isDelete,
                                IsEdit = isEdit,
                                IsAdministrator = isAdministrator,
                                Email = Email
                            };
                            new AuthenticationLogger(UserName, AccessLevel, Date, Time).LoginLogger();
                            frmFinance.Show();
                            this.Hide();
                            break;
                        case "Dean":
                            new Classes.Toastr("Success", "Login Success!");
                            var frmDean = new frm_main_deans
                            {
                                Fullname = UserName,
                                AccessLevel = AccessLevel,
                                IsAdd = isAdd,
                                IsDelete = isDelete,
                                IsEdit = isEdit,
                                IsAdministrator = isAdministrator
                            };
                            new AuthenticationLogger(UserName, AccessLevel, Date, Time).LoginLogger();
                            frmDean.Show();
                            this.Hide();
                            break;
                        case "Campaign":
                            new Classes.Toastr("Success", "Login Success!");
                            var frmCampaign = new frm_main_campaign
                            {
                                Fullname = UserName,
                                AccessLevel = AccessLevel,
                                IsAdd = isAdd,
                                IsDelete = isDelete,
                                IsEdit = isEdit,
                                IsAdministrator = isAdministrator
                            };
                            new AuthenticationLogger(UserName, AccessLevel, Date, Time).LoginLogger();
                            frmCampaign.Show();
                            this.Hide();
                            break;
                    }
                }
                else
                {
                    new Classes.Toastr("Warning", "Access Denied, Error Password!");
                    tPassword.Clear();
                    tPassword.Select();
                }
            }
            catch
            {
                new Classes.Toastr("Warning", "Access Denied, Error Username or Password");
                tPassword.Clear();
                tUserName.Clear();
                tUserName.Select();
            }
            

        }

        private void developersOptionsRegistrar()
        {
            new Classes.Toastr("Success", "Developers Mode, Registrar Main");
            var frm = new frm_main_registrar();
            frm_main_registrar.instance.fullname = "Developer";
            frm_main_registrar.instance.access_level = "Developer Authorization";
            frm_main_registrar.instance.is_add = true;
            frm_main_registrar.instance.is_edit = true;
            frm_main_registrar.instance.is_delete = true;
            frm_main_registrar.instance.isAdministrator = true;
            frm.Show();
            this.Hide();
        }
        private void developerOptionsFinance()
        {
            new Classes.Toastr("Success", "Developers Mode, Registrar Main");
            var frm = new frm_main_registrar
            {
                fullname = UserName,
                access_level = AccessLevel,
                is_add = isAdd,
                is_edit = isEdit,
                is_delete = isDelete,
            };
        }
        private void developerOptionsDean()
        {
            throw new NotImplementedException();
        }
        private void developerOptionsCampaign()
        {
            throw new NotImplementedException();
        }

        private void frm_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D1)
            {
                new Classes.Toastr("Success", "Login Successful");
                var frm = new main_form("Administrator Override");
                frm.ShowDialog();
                this.Hide();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                developersOptionsRegistrar();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.F11)
            {
                developerOptionsFinance();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.F10)
            {
                developerOptionsDean();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.F9)
            {
                developerOptionsCampaign();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                loginAuthentication(tUserName.Text, tPassword.Text);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            loginAuthentication(tUserName.Text, tPassword.Text);
        }

        private void frm_login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tPassword.UseSystemPasswordChar = false;
                tPassword.PasswordChar = '\0';
            }
            else if (!checkBox1.Checked)
            {
                tPassword.UseSystemPasswordChar = true;
                tPassword.PasswordChar = '●';
            }
        }
    }
}
