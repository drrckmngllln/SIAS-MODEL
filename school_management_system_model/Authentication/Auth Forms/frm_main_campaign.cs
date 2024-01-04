using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Authentication.Auth_Forms
{
    public partial class frm_main_campaign : Form
    {
        public string Fullname { get; set; }
        public string AccessLevel { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public frm_main_campaign()
        {
            InitializeComponent();
        }
    }
}
