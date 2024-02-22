using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Prng;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class AssessmentBreakdownRepository : IGenericRepository<AssessmentBreakdown>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();


        public async Task AddRecords(AssessmentBreakdown entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "insert into assessment_breakdown(id_number_id, school_year_id, fee_type, amount) " +
                    "values(@1,@2,@3,@4)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.id_number);
                    cmd.Parameters.AddWithValue("@2", entity.school_year);
                    cmd.Parameters.AddWithValue("@3", entity.fee_type);
                    cmd.Parameters.AddWithValue("@4", entity.amount);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public Task DeleteRecords(AssessmentBreakdown entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<AssessmentBreakdown>> GetAllAsync()
        {
            var list = new List<AssessmentBreakdown>();

            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from assessment_breakdown";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            

                            var assessmentBreakdown = new AssessmentBreakdown
                            {
                                id = reader.GetInt32("id"),
                                id_number = reader.GetString("id_number_id"),
                                school_year = reader.GetString("school_year_id"),
                                fee_type = reader.GetString("fee_type"),
                                amount = reader.GetDecimal("amount")
                            };
                            list.Add(assessmentBreakdown);
                        }
                    }
                }

                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                var schoolYears = await _schoolYearRepo.GetAllAsync();

                await con.CloseAsync();
                return list.Select(x => new AssessmentBreakdown
                {
                    id = x.id,
                    id_number = studentAccounts.FirstOrDefault(s => s.id == Convert.ToInt32(x.id_number)).id_number,
                    school_year = schoolYears.FirstOrDefault(sy => sy.id == Convert.ToInt32(x.school_year)).code,
                    fee_type = x.fee_type,
                    amount = x.amount
                }).ToList();
            }
        }

        public async Task UpdateRecords(AssessmentBreakdown entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "update assessment_breakdown set id_number_id=@1, school_year_id=@2, fee_type=@3, amount=@4 where id_number_id='" + entity.id_number + "' " +
                    "and fee_type='" + entity.fee_type + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.id_number);
                    cmd.Parameters.AddWithValue("@2", entity.school_year);
                    cmd.Parameters.AddWithValue("@3", entity.fee_type);
                    cmd.Parameters.AddWithValue("@4", entity.amount);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public async Task<IReadOnlyList<AssessmentBreakdown>> UpdateRecordsAsync(AssessmentBreakdown entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "update assessment_breakdown set id_number_id=@1, school_year_id=@2, fee_type=@3, amount=@4 where id_number_id='" + entity.id_number + "' " +
                    "and fee_type='" + entity.fee_type + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.id_number);
                    cmd.Parameters.AddWithValue("@2", entity.school_year);
                    cmd.Parameters.AddWithValue("@3", entity.fee_type);
                    cmd.Parameters.AddWithValue("@4", entity.amount);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }

            return await GetAllAsync();
        }
    }
}
