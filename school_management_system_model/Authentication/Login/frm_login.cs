using Krypton.Toolkit;
using school_management_system_model.Classes;
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
    }
}
