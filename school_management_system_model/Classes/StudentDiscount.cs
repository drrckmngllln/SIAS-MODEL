using MySql.Data.MySqlClient;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
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
        public int id { get; set; }
        public string id_number { get; set; }
        public string code { get; set; }
        public string discount_target { get; set; }
        public string description { get; set; }
        public int discount_percentage { get; set; }

        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();

        public async Task<List<StudentDiscount>> GetStudentDiscounts()
        {
            
            var list = new List<StudentDiscount>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from student_discounts";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var a = await _studentAccountRepo.GetAllAsync();
                            var id_number_id = a
                                .FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));
                            if (id_number_id != null)
                            {
                                var discount = new StudentDiscount
                                {
                                    id = reader.GetInt32("id"),
                                    id_number = id_number_id.id_number,
                                    code = reader.GetString("code"),
                                    discount_target = reader.GetString("discount_target"),
                                    description = reader.GetString("description"),
                                    discount_percentage = reader.GetInt32("discount_percentage")
                                };
                                list.Add(discount);
                            }
                           
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public DataTable loadRecords(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_discounts where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public async void addRecords()
        {
            var a = await _studentAccountRepo.GetAllAsync();
            var id_number_id = a
                .FirstOrDefault(x => x.id_number == id_number);
            if (id_number_id != null)
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("insert into student_discounts(id_number_id, code, description, discount_percentage, discount_target) " +
                    "values(@1,@2,@3,@4,@5)", con);
                cmd.Parameters.AddWithValue("@1", id_number_id.id);
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
