using DocumentFormat.OpenXml.Office2010.Excel;
using MySql.Data.MySqlClient;
using school_management_system_model.Core.Dtos;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Setings.Section;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Infrastructure.Data.Repositories;
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
                            var studentAccounts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var courses = await _courseRepo.GetByIdAsync(reader.GetInt32("course_id"));
                            var campuses = await _campusRepo.GetByIdAsync(reader.GetInt32("campus_id"));
                            var curriculums = await _curriculumRepo.GetByIdAsync(reader.GetInt32("curriculum_id"));
                            var sections = await _sectionRepo.GetByIdAsync(reader.GetInt32("section_id"));

                            var studentCourse = new StudentCourses
                            {
                                id = reader.GetInt32("id"),
                                id_number = studentAccounts.id_number,
                                course = courses.code,
                                campus = campuses.code,
                                curriculum = curriculums.code,
                                year_level = reader.GetString("year_level"),
                                section = sections.section_code,
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

        public async Task<StudentCourses> GetByIdAsync(int id)
        {
            var _studentAccounRepo = new StudentAccountRepository();
            var _courseRepo = new CourseRepository();
            var _campusRepo = new CampusRepository();
            var _curriculumRepo = new CurriculumRepository();
            var _sectionRepo = new SectionRepository();


            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select student_course where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var student = await _studentAccounRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                        var courses = await _courseRepo.GetByIdAsync(reader.GetInt32("course_id"));
                        var campuses = await _campusRepo.GetByIdAsync(reader.GetInt32("campus_id"));
                        var curriculums = await _curriculumRepo.GetByIdAsync(reader.GetInt32("curriculum_id"));
                        var sections = await _sectionRepo.GetByIdAsync(reader.GetInt32("section_id"));

                        var studentCourses = new StudentCourses
                        {
                            id = reader.GetInt32("id"),
                            id_number = student.id_number,
                            course = courses.code,
                            campus = campuses.code,
                            curriculum = curriculums.code,
                            year_level = reader.GetString("year_level"),
                            section = sections.section_code,
                            semester = reader.GetString("semester")
                        };
                        await con.CloseAsync();
                        return studentCourses;
                    }
                }
            }
        }

        public async Task<StudentCourses> GetByIdNumberAsync(string id_number)
        {
            var _studentAccounRepo = new StudentAccountRepository();
            var _courseRepo = new CourseRepository();
            var _campusRepo = new CampusRepository();
            var _curriculumRepo = new CurriculumRepository();
            var _sectionRepo = new SectionRepository();

            var studentCourses = new StudentCourses();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from student_course where id_number_id='" + id_number + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = await _studentAccounRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var courses = await _courseRepo.GetByIdAsync(reader.GetInt32("course_id"));
                            var campuses = await _campusRepo.GetByIdAsync(reader.GetInt32("campus_id"));
                            var curriculums = await _curriculumRepo.GetByIdAsync(reader.GetInt32("curriculum_id"));
                            var sections = await _sectionRepo.GetByIdAsync(reader.GetInt32("section_id"));

                            studentCourses = new StudentCourses
                            {
                                id = reader.GetInt32("id"),
                                id_number = student.id_number,
                                course = courses.code,
                                campus = campuses.code,
                                curriculum = curriculums.code,
                                year_level = reader.GetString("year_level"),
                                section = sections.section_code,
                                semester = reader.GetString("semester")
                            };
                        }
                        
                    }
                }
                await con.CloseAsync();
                return studentCourses;
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
