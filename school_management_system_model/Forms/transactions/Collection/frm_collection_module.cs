using school_management_system_model.Data.Repositories.Setings;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.Collection
{
    public partial class frm_collection_module : Form
    {
        UserRepository _userRepo = new UserRepository();


        

        public static frm_collection_module instance;
        public frm_collection_module(string email)
        {
            instance = this;
            InitializeComponent();
            Email = email;
        }
        private async void frm_collection_module_Load(object sender, EventArgs e)
        {
            await loadCashier();
            openAssessedCollection();
        }

        public string Email { get; }

        private string SelectedTab;

        public string CashierInCharge { get; set; }
        public int OrNumber { get; set; }
        public string Department { get; set; }

        private async Task loadCashier()
        {
            var users = await _userRepo.GetAllAsync();

            var cashier = users.FirstOrDefault(x => x.email == Email);

            tCashier.Text = cashier.fullname;
            Department = cashier.department;
            CashierInCharge = cashier.fullname;
            Department = cashier.department;
        }

        private void setOrNumber()
        {
            if (tOrNumberSet.Text == "")
            {
                new Classes.Toastr("Error", "Fields Missing");
            }
            else
            {
                try
                {
                    OrNumber = Convert.ToInt32(tOrNumberSet.Text);
                    tOrNumber.Text = OrNumber.ToString();
                    tOrNumberSet.Clear();
                }
                catch (Exception ex)
                {
                    new Classes.Toastr("Warning", ex.Message);
                }
            }
        }

        public void incrementOrNumber()
        {
            OrNumber++;
            tOrNumber.Text = OrNumber.ToString();
        }


        private void openAssessedCollection()
        {
            SelectedTab = "Fee Collection";
            var frm = new frm_fee_collection(Email);
            frm.TopLevel = false;
            routerPanel.Controls.Clear();
            routerPanel.Controls.Add(frm);
            frm.Show();
        }

        private void openNonAssessedCollection()
        {
            SelectedTab = "Non assessed collection";
            var frm = new frm_non_assessed_collection(Email);
            frm.TopLevel = false;
            routerPanel.Controls.Clear();
            routerPanel.Controls.Add(frm);
            frm.Show();
        }

        private void btnAssessed_Click(object sender, EventArgs e)
        {
            openAssessedCollection();
        }

        private void btnNonAssessed_Click(object sender, EventArgs e)
        {
            openNonAssessedCollection();
        }

        
        private void btnSet_Click(object sender, EventArgs e)
        {
            setOrNumber();
        }
    }
}
