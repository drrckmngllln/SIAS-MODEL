using MySql.Data.MySqlClient;
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


                            var studentCourse = new StudentCourses
                            {
                                id = reader.GetInt32("id"),
                                id_number = reader.GetString("id_number_id"),
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

                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                var courses = await _courseRepo.GetAllAsync();
                var campuses = await _campusRepo.GetAllAsync();
                var curriculums = await _curriculumRepo.GetAllAsync();
                var sections = await _sectionRepo.GetAllAsync();

                var listDt = list.ToDataTable();

                int lastRow = listDt.Rows.Count - 1;

                if (listDt.Rows[lastRow]["curriculum"].ToString() == "Not Set" || listDt.Rows[lastRow]["section"].ToString() == "Not Set")
                {
                    return list.Select(x => new StudentCourses
                    {
                        id = x.id,
                        id_number = studentAccounts.FirstOrDefault(s => s.id == Convert.ToInt32(x.id_number)).id_number,
                        course = courses.FirstOrDefault(c => c.id == Convert.ToInt32(x.course)).code,
                        campus = campuses.FirstOrDefault(campus => campus.id == Convert.ToInt32(x.campus)).code,
                        curriculum = "Not Set",
                        year_level = x.year_level,
                        section = "Not Set",
                        semester = x.semester
                    }).ToList();
                }
                //else if (listDt.Rows[0]["section"].ToString() == "Not Set")
                //{
                //    return list.Select(x => new StudentCourses
                //    {
                //        id = x.id,
                //        id_number = studentAccounts.FirstOrDefault(s => s.id == Convert.ToInt32(x.id_number)).id_number,
                //        course = courses.FirstOrDefault(c => c.id == Convert.ToInt32(x.course)).code,
                //        campus = campuses.FirstOrDefault(campus => campus.id == Convert.ToInt32(x.campus)).code,
                //        curriculum = curriculums.FirstOrDefault(cur => cur.id == Convert.ToInt32(x.curriculum)).code,
                //        year_level = x.year_level,
                //        section = "Not Set",
                //        semester = x.semester
                //    }).ToList();
                //}
                else
                {
                    return list.Select(x => new StudentCourses
                    {
                        id = x.id,
                        id_number = studentAccounts.FirstOrDefault(s => s.id == Convert.ToInt32(x.id_number)).id_number,
                        course = courses.FirstOrDefault(c => c.id == Convert.ToInt32(x.course)).code,
                        campus = campuses.FirstOrDefault(campus => campus.id == Convert.ToInt32(x.campus)).code,
                        year_level = x.year_level,
                        curriculum = curriculums.FirstOrDefault(cur => cur.id == Convert.ToInt32(x.curriculum)).code,
                        section = sections.FirstOrDefault(section => section.id == Convert.ToInt32(x.section)).section_code,
                        semester = x.semester
                    }).ToList();
                }

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
