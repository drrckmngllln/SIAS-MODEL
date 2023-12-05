using Krypton.Toolkit;
using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_create_account : KryptonForm
    {
        public static frm_create_account instance;
        public string schoolYear { get; set; }
        public int id { get; set; }
        public frm_create_account()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_create_account_Load(object sender, EventArgs e)
        {
            if (this.Text == "Create Account")
            {
                tTitle.Text = this.Text;
                loadSchoolYear();
                loadIdNumber();
            }
            else if (this.Text == "Update Account")
            {
                tTitle.Text = this.Text;
                var update = new StudentAccount();
                var data = update.loadUpdateRecord(id);


                tIdNumber.Text = data.Rows[0]["id_number"].ToString();
                tSchoolyear.Text = data.Rows[0]["school_year"].ToString();
                tLastname.Text = data.Rows[0]["last_name"].ToString();
                tFirstname.Text = data.Rows[0]["first_name"].ToString();
                tMiddlename.Text = data.Rows[0]["middle_name"].ToString();
                tGender.Text = data.Rows[0]["gender"].ToString();
                tCivilStatus.Text = data.Rows[0]["civil_status"].ToString();
                tDateofBirth.Text = data.Rows[0]["date_of_birth"].ToString();
                tPlaceofBirth.Text =data.Rows[0]["place_of_birth"].ToString();
                tNationality.Text = data.Rows[0]["nationality"].ToString();
                tReligion.Text = data.Rows[0]["religion"].ToString();
                tStatus.Text = data.Rows[0]["status"].ToString();
                btnCreate.Text = "Update Account";
            }
        }

        private void loadSchoolYear()
        {
            tSchoolyear.Text = schoolYear;
        }
        private void loadIdNumber()
        {
            var data = new StudentAccount();
            int count = 0;
            count = data.countStudent(tSchoolyear.Text);
            var idNumber = DateTime.Now.Year.ToString();

            var semester = new StudentAccount();
            idNumber += "-" + semester.loadSemester(tSchoolyear.Text);

            if (count < 9)
            {
                count++;
                idNumber += "-" + "000" + count.ToString();
            }
            else if (count < 99)
            {
                count++;
                idNumber += "-" + "00" + count.ToString();
            }
            else if (count < 999)
            {
                count++;
                idNumber += "-" + "0" + count.ToString();
            }
            else if (count < 9999)
            {
                count++;
                idNumber += "-" + count.ToString();
            }
            tIdNumber.Text = idNumber;
            tLastname.Select();
        }

        private void addRecord()
        {
            try
            {

                if (this.Text == "Create Account")
                {
                    var add = new StudentAccount
                    {
                        id_number = tIdNumber.Text,
                        school_year = tSchoolyear.Text,
                        full_name = tLastname.Text + ", " + tFirstname.Text + " " + tMiddlename.Text,
                        last_name = tLastname.Text,
                        first_name = tFirstname.Text,
                        middle_name = tMiddlename.Text,
                        gender = tGender.Text,
                        civil_status = tCivilStatus.Text,
                        date_of_birth = tDateofBirth.Text,
                        place_of_birth = tPlaceofBirth.Text,
                        nationality = tNationality.Text,
                        religion = tReligion.Text,
                        status = tStatus.Text
                    };
                    add.addRecord();
                    MessageBox.Show("Account Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else if (this.Text == "Update Account")
                {
                    var edit = new StudentAccount
                    {
                        id_number = tIdNumber.Text,
                        school_year = tSchoolyear.Text,
                        full_name = tLastname.Text + ", " + tFirstname.Text + " " + tMiddlename.Text,
                        last_name = tLastname.Text,
                        first_name = tFirstname.Text,
                        middle_name = tMiddlename.Text,
                        gender = tGender.Text,
                        civil_status = tCivilStatus.Text,
                        date_of_birth = tDateofBirth.Text,
                        place_of_birth = tPlaceofBirth.Text,
                        nationality = tNationality.Text,
                        religion = tReligion.Text,
                        status = tStatus.Text
                    };
                    edit.editRecord(tIdNumber.Text);
                    MessageBox.Show("Account Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_create_account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecord();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            addRecord();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tDateofBirth.Text = dateTimePicker1.Value.ToString("MM-dd-yyyy");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
