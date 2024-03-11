using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class CashierLogRepository : IGenericRepository<CashierLog>
    {
        private readonly SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        public async Task AddRecords(CashierLog entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "insert into cashier_log(date, name, reference_no, particulars, school_year_id, department, credit, debit, balance) " +
                    "values(@1,@2,@3,@4,@5,@6,@7,@8,@9)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.date);
                    cmd.Parameters.AddWithValue("@2", entity.name);
                    cmd.Parameters.AddWithValue("@3", entity.reference_no);
                    cmd.Parameters.AddWithValue("@4", entity.particulars);
                    cmd.Parameters.AddWithValue("@5", entity.school_year);
                    cmd.Parameters.AddWithValue("@6", entity.department);
                    cmd.Parameters.AddWithValue("@7", entity.credit);
                    cmd.Parameters.AddWithValue("@8", entity.debit);
                    cmd.Parameters.AddWithValue("@9", entity.balance);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public Task DeleteRecords(CashierLog entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<CashierLog>> GetAllAsync()
        {
            var list = new List<CashierLog>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from cashier_log";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var schoolYears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));
                            var cashier = new CashierLog
                            {
                                id = reader.GetInt32("id"),
                                date = reader.GetDateTime("date"),
                                name = reader.GetString("name"),
                                reference_no = reader.GetString("reference_no"),
                                particulars = reader.GetString("particulars"),
                                school_year = schoolYears.code,
                                department = reader.GetString("department"),
                                credit = reader.GetDecimal("credit"),
                                debit = reader.GetDecimal("debit"),
                                balance = reader.GetDecimal("balance")
                            };
                            list.Add(cashier);
                        }
                    }
                }
                await con.CloseAsync();
            }
            return list;
        }

        public async Task<CashierLog> GetByIdAsync(int id)
        {
            var cashier = new CashierLog();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from cashier_log where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var schoolYears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));
                            cashier = new CashierLog
                            {
                                id = reader.GetInt32("id"),
                                date = reader.GetDateTime("date"),
                                name = reader.GetString("name"),
                                reference_no = reader.GetString("reference_no"),
                                particulars = reader.GetString("particulars"),
                                school_year = schoolYears.code,
                                department = reader.GetString("department"),
                                credit = reader.GetDecimal("credit"),
                                debit = reader.GetDecimal("debit"),
                                balance = reader.GetDecimal("balance")
                            };
                        }
                        await con.CloseAsync();
                        return cashier;
                    }
                }
            }
        }

        public Task UpdateRecords(CashierLog entity)
        {
            throw new NotImplementedException();
        }
    }
}
