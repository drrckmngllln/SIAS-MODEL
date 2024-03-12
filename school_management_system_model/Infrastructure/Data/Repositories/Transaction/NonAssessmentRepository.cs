using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class NonAssessmentRepository : IGenericRepository<NonAssessment>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        CourseRepository _courseRepo = new CourseRepository();
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();


        public async Task<IReadOnlyList<NonAssessment>> AddRecordsAsync(NonAssessment entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "insert into non_assessment_soa(id_number_id, school_year_id, date, course_id, year_level, semester, " +
                    "reference_no, particulars, amount, cashier_in_charge) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.id_number);
                    cmd.Parameters.AddWithValue("@2", entity.school_year);
                    cmd.Parameters.AddWithValue("@3", entity.date);
                    cmd.Parameters.AddWithValue("@4", entity.course_id);
                    cmd.Parameters.AddWithValue("@5", entity.year_level);
                    cmd.Parameters.AddWithValue("@6", entity.semester);
                    cmd.Parameters.AddWithValue("@7", entity.reference_no);
                    cmd.Parameters.AddWithValue("@8", entity.particulars);
                    cmd.Parameters.AddWithValue("@9", entity.amount);
                    cmd.Parameters.AddWithValue("@10", entity.cashier_in_charge);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }

            return await GetAllAsync();
        }

        public Task AddRecords(NonAssessment entity)
        {
            throw new NotImplementedException();
        }



        public Task DeleteRecords(NonAssessment entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecords(NonAssessment entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<NonAssessment>> GetAllAsync()
        {
            var list = new List<NonAssessment>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from non_assessment_soa";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var studentaccounts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var schoolyears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));
                            var courses = await _courseRepo.GetByIdAsync(reader.GetInt32("course_id"));

                            var soa = new NonAssessment
                            {
                                id = reader.GetInt32("id"),
                                id_number = studentaccounts.id_number,
                                school_year = schoolyears.code,
                                date = reader.GetString("date"),
                                course_id = courses.code,
                                year_level = reader.GetString("year_level"),
                                semester = reader.GetString("semester"),
                                reference_no = reader.GetInt32("reference_no"),
                                particulars = reader.GetString("particulars"),
                                amount = reader.GetDecimal("amount"),
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

        public async Task<NonAssessment> GetByIdAsync(int id)
        {
            var nonAssessment = new NonAssessment();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from non_assessment_soa where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var studentaccounts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var schoolyears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));
                            var courses = await _courseRepo.GetByIdAsync(reader.GetInt32("course_id"));

                            nonAssessment = new NonAssessment
                            {
                                id = reader.GetInt32("id"),
                                id_number = studentaccounts.id_number,
                                school_year = schoolyears.code,
                                date = reader.GetString("date"),
                                course_id = courses.code,
                                year_level = reader.GetString("year_level"),
                                semester = reader.GetString("semester"),
                                reference_no = reader.GetInt32("reference_no"),
                                particulars = reader.GetString("particulars"),
                                amount = reader.GetDecimal("amount"),
                                cashier_in_charge = reader.GetString("cashier_in_charge")
                            };
                        }
                        await con.CloseAsync();
                        return nonAssessment;
                    }
                }
            }
        }
    }
}
