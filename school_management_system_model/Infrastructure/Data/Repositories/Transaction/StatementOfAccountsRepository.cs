using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class StatementOfAccountsRepository : IGenericRepository<StatementOfAccount>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        CourseRepository _courseRepo = new CourseRepository();

        public async Task<IReadOnlyList<StatementOfAccount>> AddRecordsAsync(StatementOfAccount entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into statements_of_accounts(id_number_id, date, reference_no, particulars, debit, credit, balance, cashier_in_charge, school_year_id, " +
                "course_id, year_level, semester) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)", con);
            cmd.Parameters.AddWithValue("@1", entity.id_number);
            cmd.Parameters.AddWithValue("@2", DateTime.Now.ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@3", entity.reference_no);
            cmd.Parameters.AddWithValue("@4", entity.particulars);
            cmd.Parameters.AddWithValue("@5", entity.debit);
            cmd.Parameters.AddWithValue("@6", entity.credit);
            cmd.Parameters.AddWithValue("@7", entity.balance);
            cmd.Parameters.AddWithValue("@8", entity.cashier_in_charge);
            cmd.Parameters.AddWithValue("@9", entity.school_year);
            cmd.Parameters.AddWithValue("@10", entity.course);
            cmd.Parameters.AddWithValue("@11", entity.year_level);
            cmd.Parameters.AddWithValue("@12", entity.semester);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();

            return await GetAllAsync();
        }


        public async Task AddRecords(StatementOfAccount entity)
        {
            entity.reference_no = referenceNumber();
            incrementReferenceNumber(entity.reference_no);
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into statements_of_accounts(id_number_id, date, reference_no, particulars, debit, credit, balance, cashier_in_charge, school_year_id, " +
                "course_id, year_level, semester) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)", con);
            cmd.Parameters.AddWithValue("@1", entity.id_number);
            cmd.Parameters.AddWithValue("@2", DateTime.Now.ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@3", entity.reference_no);
            cmd.Parameters.AddWithValue("@4", entity.particulars);
            cmd.Parameters.AddWithValue("@5", entity.debit);
            cmd.Parameters.AddWithValue("@6", entity.credit);
            cmd.Parameters.AddWithValue("@7", entity.balance);
            cmd.Parameters.AddWithValue("@8", entity.cashier_in_charge);
            cmd.Parameters.AddWithValue("@9", entity.school_year);
            cmd.Parameters.AddWithValue("@10", entity.course);
            cmd.Parameters.AddWithValue("@11", entity.year_level);
            cmd.Parameters.AddWithValue("@12", entity.semester);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task FeeCollectionSave(StatementOfAccount entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into statements_of_accounts(id_number_id, date, reference_no, particulars, debit, credit, balance, cashier_in_charge, school_year_id, " +
                "course_id, year_level, semester) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)", con);
            cmd.Parameters.AddWithValue("@1", entity.id_number);
            cmd.Parameters.AddWithValue("@2", DateTime.Now.ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@3", entity.reference_no);
            cmd.Parameters.AddWithValue("@4", entity.particulars);
            cmd.Parameters.AddWithValue("@5", entity.debit);
            cmd.Parameters.AddWithValue("@6", entity.credit);
            cmd.Parameters.AddWithValue("@7", entity.balance);
            cmd.Parameters.AddWithValue("@8", entity.cashier_in_charge);
            cmd.Parameters.AddWithValue("@9", entity.school_year);
            cmd.Parameters.AddWithValue("@10", entity.course);
            cmd.Parameters.AddWithValue("@11", entity.year_level);
            cmd.Parameters.AddWithValue("@12", entity.semester);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public Task DeleteRecords(StatementOfAccount entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<StatementOfAccount>> GetAllAsync()
        {
            var list = new List<StatementOfAccount>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from statements_of_accounts";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var studentaccouts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var schoolyears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));
                            var courses = await _courseRepo.GetByIdAsync(reader.GetInt32("course_id"));

                            var soa = new StatementOfAccount
                            {
                                id = reader.GetInt32("id"),
                                id_number = reader.GetString("id_number_id"),
                                school_year = reader.GetString("school_year_id"),
                                date = reader.GetString("date"),
                                course = reader.GetString("course_id"),
                                year_level = reader.GetString("year_level"),
                                semester = reader.GetString("semester"),
                                reference_no = reader.GetInt32("reference_no"),
                                particulars = reader.GetString("particulars"),
                                debit = reader.GetDecimal("debit"),
                                credit = reader.GetDecimal("credit"),
                                balance = reader.GetDecimal("balance"),
                                cashier_in_charge = reader.GetString("cashier_in_charge")
                            };
                            list.Add(soa);
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public async Task<StatementOfAccount> GetByIdAsync(int id)
        {
            var soa = new StatementOfAccount();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from statements_of_accounts where id='"+ id +"'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var studentaccouts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var schoolyears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));
                            var courses = await _courseRepo.GetByIdAsync(reader.GetInt32("course_id"));

                            soa = new StatementOfAccount
                            {
                                id = reader.GetInt32("id"),
                                id_number = reader.GetString("id_number_id"),
                                school_year = reader.GetString("school_year_id"),
                                date = reader.GetString("date"),
                                course = reader.GetString("course_id"),
                                year_level = reader.GetString("year_level"),
                                semester = reader.GetString("semester"),
                                reference_no = reader.GetInt32("reference_no"),
                                particulars = reader.GetString("particulars"),
                                debit = reader.GetDecimal("debit"),
                                credit = reader.GetDecimal("credit"),
                                balance = reader.GetDecimal("balance"),
                                cashier_in_charge = reader.GetString("cashier_in_charge")
                            };
                        }
                        await con.CloseAsync();
                        return soa;
                    }
                }
            }
        }

        public Task UpdateRecords(StatementOfAccount entity)
        {
            throw new NotImplementedException();
        }

        public int referenceNumber()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from reference_number_setup order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["reference_number"]) + 1;
        }
        public void incrementReferenceNumber(int referenceNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update reference_number_setup set reference_number='" + referenceNumber + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
