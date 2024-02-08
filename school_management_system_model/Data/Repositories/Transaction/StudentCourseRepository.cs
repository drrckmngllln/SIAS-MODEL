using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Transaction
{
    internal class StudentCourseRepository : IGenericRepository<StudentCourses>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        public Task AddRecords(StudentCourses entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecords(StudentCourses entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<StudentCourses>> GetAllAsync()
        {
            var list = new List<StudentCourses>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from student_courses";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var a = await _studentAccountRepo.GetAllAsync();
                        var id_number_id = a.FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));

                        
                        while (reader.Read())
                        {
                            var studentCourse = new StudentCourses
                            {
                                id = reader.GetInt32("id"),
                                id_number = id_number_id.id_number,
                                course = reader.GetString("course_id"),
                                campus = reader.GetString("campus_id"),
                                curriculum = reader.GetString("curriculum_id"),
                                year_level = reader.GetString("year_level"),
                                section = reader.GetString("section_id"),
                                semester = reader.GetString("semester")
                            };
                            list.Add(studentCourse);
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public Task UpdateRecords(StudentCourses entity)
        {
            throw new NotImplementedException();
        }
    }
}
