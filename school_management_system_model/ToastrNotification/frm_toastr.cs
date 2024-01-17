using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Toastr
{
    public partial class frm_toastr : Form
    {
        int toastX, toastY;
        
        public frm_toastr(string type, string message)
        {
            InitializeComponent();
            tType.Text = type;
            tMessage.Text = message;
            switch (type)
            {
                case "Success":
                    toastColor.BackColor = Color.FromArgb(57, 155, 53);
                    icon.Image = Properties.Resources.check;
                    break;
                case "Error":
                    toastColor.BackColor = Color.FromArgb(227, 50, 45);
                    icon.Image = Properties.Resources.error;

                    break;
                case "Information":
                    toastColor.BackColor = Color.FromArgb(18, 136, 191);
                    icon.Image = Properties.Resources.information;

                    break;
                case "Warning":
                    toastColor.BackColor = Color.FromArgb(245, 171, 35);
                    icon.Image = Properties.Resources.warning;

                    break;
            }
        }

        private void toastr_success_Load(object sender, EventArgs e)
        {
            Position();
        }

        private void toastTimer_Tick(object sender, EventArgs e)
        {
            toastY -= 10;
            this.Location = new Point(toastX, toastY);
            if (toastY <= 950 ) //950
            {
                toastTimer.Stop();
                toastHide.Start();
            }
        }
        int y = 100;
        private void toastHide_Tick(object sender, EventArgs e)
        {
            y--;
            if (y <=0 )
            {
                toastY += 1;
                this.Location = new Point(toastX, toastY += 10);
                if (toastY > 800)
                {
                    toastHide.Stop();
                    y = 100;
                    Close();
                }
            }
            
        }

        private void Position()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            toastX = screenWidth - this.Width;
            toastY = screenHeight - this.Height;

            this.Location = new Point(toastX, toastY);

            
        }
    }
}
