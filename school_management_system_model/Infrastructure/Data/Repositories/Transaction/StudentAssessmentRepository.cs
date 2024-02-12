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
                            var studentAccounts = await _studentAccountRepo.GetAllAsync();
                            var id_number_id = studentAccounts.FirstOrDefault(x => x.id == reader.GetInt32("id_number_id")).id_number; ;

                            var schoolYears = await _schoolYearRepo.GetAllAsync();
                            var school_year_id = schoolYears.FirstOrDefault(x => x.id == reader.GetInt32("school_year_id")).code;

                            var student = new StudentAssessment
                            {
                                id = reader.GetInt32("id"),
                                id_number = id_number_id.ToString(),
                                school_year = school_year_id,
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

        public Task UpdateRecords(StudentAssessment entity)
        {
            throw new NotImplementedException();
        }
    }
}
