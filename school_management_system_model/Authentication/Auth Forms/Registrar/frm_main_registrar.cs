﻿using Krypton.Toolkit;
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
            
        }
    }
}
