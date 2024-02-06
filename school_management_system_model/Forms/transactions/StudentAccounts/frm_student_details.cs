using school_management_system_model.Classes;
using school_management_system_model.Reports.Datasets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    public partial class frm_student_details : Form
    {
        public frm_student_details(string id_number)
        {
            InitializeComponent();
            Id_Number = id_number;
        }

        public string Id_Number { get; }

        private void frm_student_details_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var studentCourse = new StudentCourses().GetStudentCourses()
                .Where(x => x.id_number_id == Id_Number).ToList();
            dgv.DataSource = studentCourse;
        }
    }
}
