using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class StudentDiscountRepository : IGenericRepository<StudentDiscount>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        public async Task AddRecords(StudentDiscount entity)
        {
            var a = await _studentAccountRepo.GetAllAsync();
            var id_number_id = a
                .FirstOrDefault(x => x.id_number == entity.id_number);
            if (id_number_id != null)
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("insert into student_discounts(id_number_id, code, description, discount_percentage, discount_target) " +
                    "values(@1,@2,@3,@4,@5)", con);
                cmd.Parameters.AddWithValue("@1", id_number_id.id);
                cmd.Parameters.AddWithValue("@2", entity.code);
                cmd.Parameters.AddWithValue("@3", entity.description);
                cmd.Parameters.AddWithValue("@4", entity.discount_percentage);
                cmd.Parameters.AddWithValue("@5", entity.discount_target);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public async Task DeleteRecords(StudentDiscount entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("delete from student_discounts where id='" + entity.id + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<StudentDiscount>> GetAllAsync()
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

        public Task UpdateRecords(StudentDiscount entity)
        {
            throw new NotImplementedException();
        }
    }
}
