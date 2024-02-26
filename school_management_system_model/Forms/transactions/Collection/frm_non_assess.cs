using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Infrastructure.Data.Repositories.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Instrumentation;

namespace school_management_system_model.Forms.transactions.Collection
{
    public partial class frm_non_assess : Form
    {

        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
        NonAssessmentRepository _nonAssessmentRepository = new NonAssessmentRepository();
        CourseRepository _courseRepo = new CourseRepository();
        private frm_non_assess instance;
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly CashierLogRepository _cashierLogRepo = new CashierLogRepository();


        public string department { get; set; }
        public string id_number { get; set; }    
        public int OrNumber { get; set; }
        public string _email { get; set; }

        public frm_non_assess(string email)
        {
            instance = this;
            InitializeComponent();
            _email = email;
        }

        public frm_non_assess()
        {
        }

        private async void loadCashier()
        {
            var users = await _userRepo.GetAllAsync();
            var cashier = users.FirstOrDefault(x => x.email == _email);
            tCashier.Text = cashier.fullname;
            department = cashier.department;
        }


    }
}
