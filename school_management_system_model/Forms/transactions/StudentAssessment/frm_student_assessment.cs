using Krypton.Toolkit;
using school_management_system_model.Classes;
using school_management_system_model.Forms.transactions.StudentAssessment;
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
    public partial class frm_student_assessment : Form
    {
        public static frm_student_assessment instance;
        public string studentID { get; set; }
        public string schoolYear { get; set; }
        public decimal totalUnits { get; set; }
        public decimal labFee { get; set; }
        public string labFeeCategory { get; set; }

        public frm_student_assessment()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_student_assessment_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            dgv.Columns.Add("fee_type", "Fee Type");
            dgv.Columns.Add("amount", "Amount");
            dgv.Columns.Add("units", "Units");
            dgv.Columns.Add("computation", "Computation");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Select Student";
            frm.ShowDialog();
            if (studentID != null)
            {
                // Getting Student Name
                var name = new student_assessment
                {
                    id_number = studentID
                };
                tStudentName.Text = name.getStudentName();

                // Getting Student Course
                tIdNumber.Text = studentID.ToString();
                var studentDetails = new student_assessment
                {
                    id_number = tIdNumber.Text
                };
                var data = studentDetails.getStudentDetails();
                tCourse.Text = data.Rows[0]["course"].ToString();
                tYearLevel.Text = data.Rows[0]["year_level"].ToString();
                tSemester.Text = data.Rows[0]["semester"].ToString();
                tCampus.Text = data.Rows[0]["campus"].ToString();
                
            }
        }

        private void addAssessmentRecords()
        {
            // Loading of Tuition Fee/Unit
            var lectureFee = new student_assessment();
            int tuitionUnit = 0;
            tuitionUnit = lectureFee.getTotalLectureUnits(tIdNumber.Text);

            var tuition = new student_assessment();
            var data = tuition.getTuitionFee(tCampus.Text);
            if (tYearLevel.Text == "1")
            {
                dgv.Rows.Add(
                    data.Rows[0]["category"],
                    data.Rows[0]["first_year"],
                    tuitionUnit,
                    tuitionUnit * Convert.ToDecimal(data.Rows[0]["first_year"])
                    );
            }
            else if (tYearLevel.Text == "2")
            {
                dgv.Rows.Add(
                   data.Rows[0]["category"],
                   data.Rows[0]["second_year"],
                   tuitionUnit,
                    tuitionUnit * Convert.ToDecimal(data.Rows[0]["second_year"])
                   );
            }
            else if (tYearLevel.Text == "3")
            {
                dgv.Rows.Add(
                   data.Rows[0]["category"],
                   data.Rows[0]["third_year"],
                   tuitionUnit,
                   tuitionUnit * Convert.ToDecimal(data.Rows[0]["third_year"])
                   );
            }
            else if (tYearLevel.Text == "4")
            {
                dgv.Rows.Add(
                   data.Rows[0]["category"],
                   data.Rows[0]["fourth_year"],
                   tuitionUnit,
                   tuitionUnit * Convert.ToDecimal(data.Rows[0]["fourth_year"])
                   );
            }

            // Loading of Miscellaneous Fee
            var misc = new student_assessment();
            var miscData = misc.getMiscellaneousFee(tCampus.Text);
            foreach(DataRow row in miscData.Rows)
            {
                if (tYearLevel.Text == "1")
                {
                    dgv.Rows.Add(
                        row["category"],
                        row["first_year"],
                        1,
                        1 * Convert.ToDecimal(row["first_year"])
                        );
                }
                else if (tYearLevel.Text == "2")
                {
                    dgv.Rows.Add(
                       row["category"],
                       row["second_year"],
                       1,
                       1 * Convert.ToDecimal(row["second_year"])
                       );
                }
                else if (tYearLevel.Text == "3")
                {
                    dgv.Rows.Add(
                       row["category"],
                       row["third_year"],
                       1,
                       1 * Convert.ToDecimal(row["third_year"])
                       );
                }
                else if (tYearLevel.Text == "4")
                {
                    dgv.Rows.Add(
                       row["category"],
                       row["fourth_year"],
                       1,
                       1 * Convert.ToDecimal(row["fourth_year"])
                       );
                }
            }


        }

        private void loadAssessment()
        {
            
            var assessment = new student_assessment();
            var data = assessment.loadRecords(schoolYear, tIdNumber.Text);
            if (data.Rows.Count > 0)
            {
                dgv.Columns.Clear();
                
                dgv.DataSource = data;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["id_number"].Visible = false;
                dgv.Columns["school_year"].Visible = false;
                dgv.Columns["fee_type"].HeaderText = "Fee Type";
                dgv.Columns["amount"].HeaderText = "Amount";
                dgv.Columns["units"].HeaderText = "Units";
                dgv.Columns["computation"].HeaderText = "Computation";

            }
            else
            {
                dgv.Columns.Clear();
                
                dgv.Columns.Add("fee_type", "Fee Type");
                dgv.Columns.Add("amount", "Amount");
                dgv.Columns.Add("units", "Units");
                dgv.Columns.Add("computation", "Computation");
                addAssessmentRecords();
            }
        }

        private void addLabFee()
        {
            dgv.Rows.Add(labFeeCategory, labFee, 1, 1 * labFee);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Select School Year";
            frm.ShowDialog();
            if (schoolYear != null)
            {
                // Loading the assessment
                tSchoolYear.Text = schoolYear.ToString();
                loadAssessment();

                
            }
        }

        private void totalTimer_Tick(object sender, EventArgs e)
        {
            totalUnits = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                totalUnits += Convert.ToDecimal(row.Cells["computation"].Value.ToString());
            }
            tTotal.Text = totalUnits.ToString();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Select Lab Fee";
            frm_select_student.instance.campus = tCampus.Text;
            frm_select_student.instance.yearLevel = tYearLevel.Text;
            frm.ShowDialog();
            if (labFeeCategory != null)
            {
                addLabFee();
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            var frm = new frm_view_subjects();
            frm.Text = "View Subjects";
            frm_view_subjects.instance.id_number = tIdNumber.Text;
            frm.ShowDialog();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            int unit = 0;
            unit = Convert.ToInt32(dgv.CurrentRow.Cells["units"].Value);
            unit++;
            dgv.CurrentRow.Cells["units"].Value = unit;
            dgv.CurrentRow.Cells["computation"].Value = unit * Convert.ToDecimal(dgv.CurrentRow.Cells["amount"].Value);
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            dgv.Rows.Remove(dgv.CurrentRow);
        }

        private void saveAssessment()
        {
            // Save to Student Assessment
            foreach(DataGridViewRow row in dgv.Rows)
            {
                var assessment = new student_assessment
                {
                    id_number = tIdNumber.Text,
                    school_year = tSchoolYear.Text,
                    fee_type = row.Cells["fee_type"].Value.ToString(),
                    amount = Convert.ToDecimal(row.Cells["amount"].Value),
                    units = Convert.ToInt32(row.Cells["units"].Value),
                    computation = Convert.ToDecimal(row.Cells["computation"].Value)
                };
                assessment.saveAssessment(tIdNumber.Text);
            }
            MessageBox.Show("Assessment Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void loadDiscounts()
        {
            // Loading the discount of the student
            var data = new student_assessment();
            var studentDiscounts = data.loadDiscounts(tIdNumber.Text);
            decimal initialBreakdown = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                initialBreakdown += Convert.ToDecimal(row.Cells["computation"].Value);
            }
            foreach (DataRow row in studentDiscounts.Rows)
            {
                dgv.Rows.Add(
                    row["description"],
                    "-" + (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown,
                    1,
                    "-" + (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown
                    );
            }
        }
        private void saveToStatementsOfAccounts()
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveAssessment();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            loadDiscounts();
        }
    }
}
