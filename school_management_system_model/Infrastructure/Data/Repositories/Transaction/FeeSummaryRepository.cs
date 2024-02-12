using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities.Settings;
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
using System.Data;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class FeeSummaryRepository : IGenericRepository<FeeSummary>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        public async Task AddRecords(FeeSummary entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into fee_summary(id_number, school_year, current_assessment, discounts, previous_balance, current_receivable) " +
                "values(@1,@2,@3,@4,@5,@6)", con);
            cmd.Parameters.AddWithValue("@1", entity.id_number);
            cmd.Parameters.AddWithValue("@2", entity.school_year);
            cmd.Parameters.AddWithValue("@3", entity.current_assessment);
            cmd.Parameters.AddWithValue("@4", entity.discounts);
            cmd.Parameters.AddWithValue("@5", entity.previous_balance);
            cmd.Parameters.AddWithValue("@6", entity.current_receivable);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public Task DeleteRecords(FeeSummary entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<FeeSummary>> GetAllAsync()
        {
            
            var list = new List<FeeSummary>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from fee_summary";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var a = await _studentAccountRepo.GetAllAsync();
                            var id_number_id = a.FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));

                            var c = await _schoolYearRepo.GetAllAsync();
                            var school_year_id = c.FirstOrDefault(x => x.id == reader.GetInt32("school_year_id"));
                            if (id_number_id != null && school_year_id != null)
                            {
                                var feeSummary = new FeeSummary
                                {
                                    id = reader.GetInt32("id"),
                                    id_number = id_number_id.id_number,
                                    school_year = school_year_id.code,
                                    current_assessment = reader.GetDecimal("current_assessment"),
                                    discounts = reader.GetDecimal("discounts"),
                                    previous_balance = reader.GetDecimal("previous_balance"),
                                    current_receivable = reader.GetDecimal("current_receivable")
                                };
                                list.Add(feeSummary);
                            }
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public Task UpdateRecords(FeeSummary entity)
        {
            throw new NotImplementedException();
        }

        public decimal LoadPreviousBalance(int id_number_id)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from statements_of_accounts where id_number='" + id_number_id + "' order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["balance"]);
            }
            else
            {
                return 0;
            }
        }
    }
}
