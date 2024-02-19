using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class FeeBreakdownRepository : IGenericRepository<FeeBreakdown>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        public async Task AddRecords(FeeBreakdown entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into fee_breakdown(id_number_id, school_year_id,prelim, midterm, semi_finals, finals, total, prelim_original, midterm_original, semi_finals_original,finals_original, " +
                "total_original, downpayment, downpayment_original) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14)", con);
            cmd.Parameters.AddWithValue("@1", entity.id_number);
            cmd.Parameters.AddWithValue("@2", entity.school_year);
            cmd.Parameters.AddWithValue("@3", entity.prelim);
            cmd.Parameters.AddWithValue("@4", entity.midterm);
            cmd.Parameters.AddWithValue("@5", entity.semi_finals);
            cmd.Parameters.AddWithValue("@6", entity.finals);
            cmd.Parameters.AddWithValue("@7", entity.total);
            cmd.Parameters.AddWithValue("@8", entity.prelim);
            cmd.Parameters.AddWithValue("@9", entity.midterm);
            cmd.Parameters.AddWithValue("@10", entity.semi_finals);
            cmd.Parameters.AddWithValue("@11", entity.finals);
            cmd.Parameters.AddWithValue("@12", entity.total);
            cmd.Parameters.AddWithValue("@13", entity.downpayment);
            cmd.Parameters.AddWithValue("@14", entity.downpayment);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public Task DeleteRecords(FeeBreakdown entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<FeeBreakdown>> GetAllAsync()
        {
            var list = new List<FeeBreakdown>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from fee_breakdown";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var feeBreakdown = new FeeBreakdown
                            {
                                id = reader.GetInt32("id"),
                                id_number = reader.GetString("id_number_id"),
                                school_year = reader.GetString("school_year_id"),
                                downpayment = reader.GetDecimal("downpayment"),
                                prelim = reader.GetDecimal("prelim"),
                                midterm = reader.GetDecimal("midterm"),
                                semi_finals = reader.GetDecimal("semi_finals"),
                                finals = reader.GetDecimal("finals"),
                                downpayment_original = reader.GetDecimal("downpayment_original"),
                                prelim_original = reader.GetDecimal("prelim_original"),
                                midterm_original = reader.GetDecimal("midterm_original"),
                                semi_finals_original = reader.GetDecimal("semi_finals_original"),
                                finals_original = reader.GetDecimal("finals_original"),
                                total_original = reader.GetDecimal("total_original")
                            };
                            list.Add(feeBreakdown);
                        }
                    }
                }

                var studentAccounts = await _studentAccountRepo.GetAllAsync();

                var schoolYears = await _schoolYearRepo.GetAllAsync();
                await con.CloseAsync();
                return list.Select(x => new FeeBreakdown
                {
                    id = x.id,
                    id_number = studentAccounts.FirstOrDefault(s => s.id == Convert.ToInt32(x.id_number)).id_number,
                    school_year = schoolYears.FirstOrDefault(sy => sy.id == Convert.ToInt32(x.school_year)).code,
                    downpayment = x.downpayment,
                    prelim = x.prelim,
                    midterm = x.midterm,
                    semi_finals = x.semi_finals,
                    finals = x.finals,
                    total = x.total,
                    downpayment_original = x.downpayment_original,
                    prelim_original = x.prelim_original,
                    midterm_original = x.midterm_original,
                    semi_finals_original = x.semi_finals_original,
                    finals_original = x.finals_original,
                    total_original = x.total_original
                }).ToList();
            }
        }

        public async Task UpdateRecords(FeeBreakdown entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update fee_breakdown set downpayment=@1, prelim=@2, midterm=@3, semi_finals=@4, finals=@5 " +
                "where id_number_id='" + entity.id_number + "' and school_year_id='" + entity.school_year + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.downpayment);
            cmd.Parameters.AddWithValue("@2", entity.prelim);
            cmd.Parameters.AddWithValue("@3", entity.midterm);
            cmd.Parameters.AddWithValue("@4", entity.semi_finals);
            cmd.Parameters.AddWithValue("@5", entity.finals);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<FeeBreakdown>> UpdateRecordsAsync(FeeBreakdown entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update fee_breakdown set downpayment=@1, prelim=@2, midterm=@3, semi_finals=@4, finals=@5 " +
                "where id_number_id='" + entity.id_number + "' and school_year_id='" + entity.school_year + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.downpayment);
            cmd.Parameters.AddWithValue("@2", entity.prelim);
            cmd.Parameters.AddWithValue("@3", entity.midterm);
            cmd.Parameters.AddWithValue("@4", entity.semi_finals);
            cmd.Parameters.AddWithValue("@5", entity.finals);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return await GetAllAsync();
        }
    }
}
