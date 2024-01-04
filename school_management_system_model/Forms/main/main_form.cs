using Krypton.Toolkit;
using school_management_system_model.Forms.settings;
using school_management_system_model.Forms.settings.FeeSetup;
using school_management_system_model.Forms.settings.Schedule;
using school_management_system_model.Forms.settings.UserManagement;
using school_management_system_model.Forms.transactions;
using school_management_system_model.Forms.transactions.Collection;
using school_management_system_model.Forms.transactions.StudentDiscounts;
using System;
using System.Threading.Tasks;

namespace school_management_system_model.Forms.main
{
    public partial class main_form : KryptonForm
    {
        public main_form()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (panelSettings.Visible == false)
            {
                panelSettings.Visible = true;
            }
            else
            {
                panelSettings.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panelGeneral.Visible == false)
            {
                panelGeneral.Visible = true;
            }
            else
            {
                panelGeneral.Visible = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (panelOfferings.Visible == false)
            {
                panelOfferings.Visible = true;
            }
            else
            {
                panelOfferings.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panelTransactions.Visible == false)
            {
                panelTransactions.Visible = true;
            }
            else
            {
                panelTransactions.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new frm_campuses();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var frm = new frm_departments();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var frm = new frm_levels();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var frm = new frm_sections();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var frm = new frm_curriculum();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var frm = new frm_subjects();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var frm = new frm_courses();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            panelTask.Controls.Clear();
        }

        public void open_curriculum_subjects()
        {
            var frm = new frm_curriculum_subjects();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panelStudentAdmission.Visible == false)
            {
                panelStudentAdmission.Visible = true;
            }
            else
            {
                panelStudentAdmission.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_accounts();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var frm = new frm_miscellaneous_setup();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }


        private void button18_Click(object sender, EventArgs e)
        {
            var frm = new frm_tuition_fee();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var frm = new frm_lab_fee_setup();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var frm = new frm_instructors();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_assessment();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var frm = new frm_school_year();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var frm = new frm_discount_setup();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (panelStudents.Visible == false)
            {
                panelStudents.Visible = true;
            }
            else
            {
                panelStudents.Visible = false;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_discounts();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            var frm = new frm_other_fees();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var frm = new frm_or_number_setup();
            frm.Text = "Set OR Number";
            frm.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (panelCollection.Visible == false)
            {
                panelCollection.Visible = true;
            }
            else
            {
                panelCollection.Visible = false;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            var frm = new frm_statements_of_accounts();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            var frm = new frm_fee_collection();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            var frm = new frm_user_management();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private async void button35_Click(object sender, EventArgs e)
        {
            var frm = new frm_admission_schedule();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            await Task.Delay(100);
            frm.Show();
        }
    }
}
