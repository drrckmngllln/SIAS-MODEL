using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities.Transaction;
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
    internal class StudentAssessmentRepository : IGenericRepository<StudentAssessment>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        public Task AddRecords(StudentAssessment entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecords(StudentAssessment entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<StudentAssessment>> GetAllAsync()
        {
            var list = new List<StudentAssessment>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from student_assessment";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var id_number_id = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));

                            var school_year_id = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));

                            var student = new StudentAssessment
                            {
                                id = reader.GetInt32("id"),
                                id_number = id_number_id.ToString(),
                                school_year = school_year_id.code,
                                fee_type = reader.GetString("fee_type"),
                                amount = reader.GetDecimal("amount"),
                                units = reader.GetDecimal("units"),
                                computation = reader.GetDecimal("computation")
                            };
                            list.Add(student);
                        }
                    }
                }
                await con.CloseAsync();
            }
            return list;
        }

        public async Task<StudentAssessment> GetByIdAsync(int id)
        {
            var studentAssessment = new StudentAssessment();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from student_assessment where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var id_number_id = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));

                            var school_year_id = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));

                            studentAssessment = new StudentAssessment
                            {
                                id = reader.GetInt32("id"),
                                id_number = id_number_id.ToString(),
                                school_year = school_year_id.code,
                                fee_type = reader.GetString("fee_type"),
                                amount = reader.GetDecimal("amount"),
                                units = reader.GetDecimal("units"),
                                computation = reader.GetDecimal("computation")
                            };
                        }
                        await con.CloseAsync();
                        return studentAssessment;
                    }
                }
            }
        }

        public Task UpdateRecords(StudentAssessment entity)
        {
            throw new NotImplementedException();
        }
    }
}
