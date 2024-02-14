using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Setings.Section;
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
        CourseRepository _courseRepo = new CourseRepository();
        CampusRepository _campusRepo = new CampusRepository();
        CurriculumRepository _curriculumRepo = new CurriculumRepository();
        SectionRepository _sectionRepo = new SectionRepository();


        public async Task AddRecords(StudentCourses entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into student_course(id_number_id, course_id, campus_id, curriculum_id, year_level, section_id, semester) " +
                "values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", entity.id_number);
            cmd.Parameters.AddWithValue("@2", entity.course);
            cmd.Parameters.AddWithValue("@3", entity.campus);
            cmd.Parameters.AddWithValue("@4", entity.curriculum);
            cmd.Parameters.AddWithValue("@5", entity.year_level);
            cmd.Parameters.AddWithValue("@6", entity.section);
            cmd.Parameters.AddWithValue("@7", entity.semester);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
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
                var sql = "select * from student_course";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var a = await _studentAccountRepo.GetAllAsync();
                            var id_number_id = a.FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));

                            var b = await _courseRepo.GetAllAsync();
                            var course_id = b.FirstOrDefault(x => x.id == reader.GetInt32("course_id"));

                            var c = await _curriculumRepo.GetAllAsync();

                            string curriculum_id;
                            var curriculumReader = reader.GetString("curriculum_id");
                            if (curriculumReader == "Not Set")
                            {
                                curriculum_id = "Not Set";
                            }
                            
                            else
                            {
                                curriculum_id = c.FirstOrDefault(x => x.id == reader.GetInt32("curriculum_id")).code;
                            }

                            var d = await _campusRepo.GetAllAsync();
                            var campus_id = d.FirstOrDefault(x => x.id == reader.GetInt32("campus_id"));

                            var sections = await _sectionRepo.GetAllAsync();
                            string section_id;
                            var sectionReader = reader.GetString("section_id");
                            if (reader.GetString("section_id") == "Not Set")
                            {
                                section_id = "Not Set";
                            }
                            else if (sectionReader == "0")
                            {
                                section_id = "Not Set";
                            }
                            else
                            {
                                section_id = sections.FirstOrDefault(x => x.id == reader.GetInt32("section_id")).section_code;
                            }

                            var studentCourse = new StudentCourses
                            {
                                id = reader.GetInt32("id"),
                                id_number = id_number_id.id_number,
                                course = course_id.code,
                                campus = campus_id.code,
                                curriculum = curriculum_id,
                                year_level = reader.GetString("year_level"),
                                section = section_id,
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

        public async Task UpdateRecords(StudentCourses entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "update student_course set id_number_id=@1, course_id=@2, campus_id=@3, curriculum_id=@4, year_level=@5, section_id=@6, semester=@7 " +
                    "where id='" + entity.id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.id_number);
                    cmd.Parameters.AddWithValue("@2", entity.course);
                    cmd.Parameters.AddWithValue("@3", entity.campus);
                    cmd.Parameters.AddWithValue("@4", entity.curriculum);
                    cmd.Parameters.AddWithValue("@5", entity.year_level);
                    cmd.Parameters.AddWithValue("@6", entity.section);
                    cmd.Parameters.AddWithValue("@7", entity.semester);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public async Task EnrolStudent(int id, string year_level, string section_id)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "update student_course set year_level=@1, section_id=@2 where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", year_level);
                    cmd.Parameters.AddWithValue("@2", section_id);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public async Task ApproveStudent(int id_number_id, int curriculum_id)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "update student_course set curriculum_id='" + curriculum_id + "' where id_number_id='" + id_number_id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }
    }
}
