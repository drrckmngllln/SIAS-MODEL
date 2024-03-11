using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Reports.Datasets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

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

        public async Task<IReadOnlyList<Core.Entities.Transaction.AssessmentBreakdown>> GetAllAsync()
        {
            var list = new List<Core.Entities.Transaction.AssessmentBreakdown>();

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
                            var studentAccounts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var schoolYears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));

                            var assessmentBreakdown = new Core.Entities.Transaction.AssessmentBreakdown
                            {
                                id = reader.GetInt32("id"),
                                id_number = studentAccounts.id_number,
                                school_year = schoolYears.code,
                                fee_type = reader.GetString("fee_type"),
                                amount = reader.GetDecimal("amount")
                            };
                            list.Add(assessmentBreakdown);
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public async Task<Core.Entities.Transaction.AssessmentBreakdown> GetByIdAsync(int id)
        {
            var assessmentBreakdown = new Core.Entities.Transaction.AssessmentBreakdown();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from assessment_breakdown where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var studentAccounts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var schoolYears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));
                            assessmentBreakdown = new Core.Entities.Transaction.AssessmentBreakdown
                            {
                                id = reader.GetInt32("id"),
                                id_number = studentAccounts.id_number,
                                school_year = schoolYears.code,
                                fee_type = reader.GetString("fee_type"),
                                amount = reader.GetDecimal("amount")
                            };
                        }
                        await con.CloseAsync();
                        return assessmentBreakdown;
                    }
                }
            }
        }

        public async Task UpdateRecords(Core.Entities.Transaction.AssessmentBreakdown entity)
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

        public async Task<IReadOnlyList<Core.Entities.Transaction.AssessmentBreakdown>> UpdateRecordsAsync(Core.Entities.Transaction.AssessmentBreakdown entity)
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
