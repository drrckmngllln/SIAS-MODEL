using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_miscellaneous_setup : Form
    {
        public static frm_miscellaneous_setup instance;
        public DataTable dt = new DataTable();
        public DataTable coursesDt = new DataTable();
        string ID;

        public frm_miscellaneous_setup()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_fees_Load(object sender, EventArgs e)
        {
            loadRecords();
            loadCampuses();
        }

        private void loadCampuses()
        {
            var courses = new MiscellaneousFeeSetup();
            var data = courses.loadCampuses();
            foreach(DataRow row in data.Rows)
            {
                tCampus.Items.Add(row["code"]);
                
            }
        }

        private void loadRecords()
        {
            var data = new MiscellaneousFeeSetup();
            dgv.DataSource = data.loadRecords();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["category"].Visible = false;
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 250;
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["first_year"].HeaderText = "1st Year";
            dgv.Columns["second_year"].HeaderText = "2nd Year";
            dgv.Columns["third_year"].HeaderText = "3rd Year";
            dgv.Columns["fourth_year"].HeaderText = "4th Year";
        }   

        private void addRecords()
        {
            if (btn_save.Text == "Save")
            {
                try
                {
                    var add = new MiscellaneousFeeSetup
                    {
                        category = tCategory.Text,
                        campus = tCampus.Text,
                        description = tDescription.Text,
                        first_year = Convert.ToDecimal(tFirstYear.Text),
                        second_year = Convert.ToDecimal(tSecondYear.Text),
                        third_year = Convert.ToDecimal(tThirdYear.Text),
                        fourth_year = Convert.ToDecimal(tFourthYear.Text)
                        
                    };
                    add.AddRecords();
                    MessageBox.Show("Successfully Saved","Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadRecords();
                    txtClear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btn_save.Text == "Update")
            {
                try
                {
                    var add = new MiscellaneousFeeSetup
                    {
                        id = Convert.ToInt32(ID),
                        category = tCategory.Text,
                        description= tDescription.Text,
                        campus = tCampus.Text,
                        first_year = Convert.ToDecimal(tFirstYear.Text),
                        second_year = Convert.ToDecimal(tSecondYear.Text),
                        third_year = Convert.ToDecimal(tThirdYear.Text),
                        fourth_year = Convert.ToDecimal(tFourthYear.Text)
                    };
                    add.editRecords();
                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClear();
                    loadRecords();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtClear()
        {
            tCampus.Text = "";
            tFirstYear.Clear();
            tSecondYear.Clear();
            tThirdYear.Clear();
            tFourthYear.Clear();
            btn_save.Text = "Save";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            addRecords();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void deleteRecords()
        {
            var delete = new MiscellaneousFeeSetup();
            delete.deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
            MessageBox.Show("Deleted Successfully","Success",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            loadRecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete records?","Warning!",
                MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtClear();
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new MiscellaneousFeeSetup();
                var searchData = search.searchRecords(tsearch.Text);
                dgv.DataSource = searchData;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            addRecords();
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            txtClear();
        }

        private void frm_miscellaneous_setup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecords();
            }
        }

        private void kryptonButton1_Click_2(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells["id"].Value.ToString();
            tCategory.Text = dgv.CurrentRow.Cells["category"].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells["campus"].Value.ToString();
            tFirstYear.Text = dgv.CurrentRow.Cells["first_year"].Value.ToString();
            tSecondYear.Text = dgv.CurrentRow.Cells["second_year"].Value.ToString();
            tThirdYear.Text = dgv.CurrentRow.Cells["third_year"].Value.ToString();
            tFourthYear.Text = dgv.CurrentRow.Cells["fourth_year"].Value.ToString();
            btn_save.Text = "Update";
        }
    }
}
