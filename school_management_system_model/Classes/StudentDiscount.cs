using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Classes
{
    internal class StudentDiscount
    {
        public string id_number { get; set; }
        public string code { get; set; }
        public string discount_target { get; set; }
        public string description { get; set; }
        public int discount_percentage { get; set; }

        public DataTable loadRecords(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_discounts where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int percentageCount(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_discounts where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["discount_percentage"].ToString());
            }
            else { return 0; }
        }
        public void addRecords()
        {
            var count = percentageCount(id_number);
            if (discount_percentage + count > 100)
            {
                MessageBox.Show("Discount Full", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("insert into student_discounts(id_number, code, description, discount_percentage, discount_target) " +
                    "values(@1,@2,@3,@4,@5)", con);
                cmd.Parameters.AddWithValue("@1", id_number);
                cmd.Parameters.AddWithValue("@2", code);
                cmd.Parameters.AddWithValue("@3", description);
                cmd.Parameters.AddWithValue("@4", discount_percentage);
                cmd.Parameters.AddWithValue("@5", discount_target);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void deleteRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from student_discounts where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
