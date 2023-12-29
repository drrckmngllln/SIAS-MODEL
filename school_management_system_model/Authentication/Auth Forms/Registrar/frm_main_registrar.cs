using Krypton.Toolkit;
using school_management_system_model.Authentication.Login;
using school_management_system_model.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Authentication.Auth_Forms.Registrar
{
    public partial class frm_main_registrar : KryptonForm
    {
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string access_level { get; set; }
        public bool is_add { get; set; }
        public bool is_edit { get; set; }
        public bool is_delete { get; set; }
        public string picUrl { get; set; }

        public frm_main_registrar()
        {
            InitializeComponent();
        }

        private void frm_main_registrar_Load(object sender, EventArgs e)
        {
            loadUserCredentials();
        }

        private void loadUserCredentials()
        {
            tUsername.Text = fullname;
            tAccesslevel.Text = access_level;
        }

        private void tLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to logout?","Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                var frm = new frm_login();
                frm.Show();
                this.Close();
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            transactionTransition.Start();
        }

        int panelHeight;
        private void transactionTransition_Tick(object sender, EventArgs e)
        {
            if (panelTransaction.Visible == true)
            {
                panelHeight += 10;
                panelTransaction.Visible = true;
                panelTransaction.Height = panelHeight;
                if (panelTransaction.Height >= 80)
                {
                    transactionTransition.Stop();
                }
            }
            //else
            //{
            //    panelHeight -= 10;
            //    panelTransaction.Height = panelHeight;
            //    if (panelHeight >= 0)
            //    {
            //        panelTransaction.Visible = true;
            //        transactionTransition.Stop();
            //    }
            //}
            
        }
    }
}
