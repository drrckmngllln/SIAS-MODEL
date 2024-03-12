using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Transaction.StudentAssessment
{
    internal class StudentSubjectRepository : IGenericRepository<StudentSubject>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        InstructorRepository _instructorRepo = new InstructorRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        public async Task AddRecords(StudentSubject entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into student_subjects(id_number_id, unique_id, school_year_id, subject_code, descriptive_title, " +
                "pre_requisite, total_units, lecture_units, lab_units, time, day, room, instructor_id, grade, remarks) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)", con);
            cmd.Parameters.AddWithValue("@1", entity.id_number_id);
            cmd.Parameters.AddWithValue("@2", entity.unique_id);
            cmd.Parameters.AddWithValue("@3", entity.school_year_id);
            cmd.Parameters.AddWithValue("@4", entity.subject_code);
            cmd.Parameters.AddWithValue("@5", entity.descriptive_title);
            cmd.Parameters.AddWithValue("@6", entity.pre_requisite);
            cmd.Parameters.AddWithValue("@7", entity.total_units);
            cmd.Parameters.AddWithValue("@8", entity.lecture_units);
            cmd.Parameters.AddWithValue("@9", entity.lab_units);
            cmd.Parameters.AddWithValue("@10", entity.time);
            cmd.Parameters.AddWithValue("@11", entity.day);
            cmd.Parameters.AddWithValue("@12", entity.room);
            cmd.Parameters.AddWithValue("@13", entity.instructor_id);
            cmd.Parameters.AddWithValue("@14", "No Grade");
            cmd.Parameters.AddWithValue("@15", "N/A");

            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public Task DeleteRecords(StudentSubject entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<StudentSubject>> GetAllAsync()
        {
            var list = new List<StudentSubject>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var cmd = new MySqlCommand("select * from student_subjects", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var studentAccounts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));

                    var schoolYears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));

                    var instructors = await _instructorRepo.GetByIdAsync(reader.GetInt32("instructor_id"));

                    var studentSubjects = new StudentSubject
                    {
                        id = reader.GetInt32("id"),
                        id_number_id = reader.GetString("id_number_id"),
                        unique_id = reader.GetString("unique_id"),
                        school_year_id = reader.GetString("school_year_id"),
                        subject_code = reader.GetString("subject_code"),
                        descriptive_title = reader.GetString("descriptive_title"),
                        pre_requisite = reader.GetString("pre_requisite"),
                        total_units = reader.GetString("total_units"),
                        lecture_units = reader.GetString("lecture_units"),
                        lab_units = reader.GetString("lab_units"),
                        time = reader.GetString("time"),
                        day = reader.GetString("day"),
                        room = reader.GetString("room"),
                        instructor_id = reader.GetString("instructor_id"),
                        grade = reader.GetString("grade"),
                        remarks = reader.GetString("remarks")
                    };
                    list.Add(studentSubjects);
                }
                await con.CloseAsync();
                return list;
            }
        }

        public async Task<StudentSubject> GetByIdAsync(int id)
        {
            var studentSubject = new StudentSubject();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from student_subjects where id='"+ id +"'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var studentAccounts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));

                            var schoolYears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));

                            var instructors = await _instructorRepo.GetByIdAsync(reader.GetInt32("instructor_id"));

                            studentSubject = new StudentSubject
                            {
                                id = reader.GetInt32("id"),
                                id_number_id = reader.GetString("id_number_id"),
                                unique_id = reader.GetString("unique_id"),
                                school_year_id = reader.GetString("school_year_id"),
                                subject_code = reader.GetString("subject_code"),
                                descriptive_title = reader.GetString("descriptive_title"),
                                pre_requisite = reader.GetString("pre_requisite"),
                                total_units = reader.GetString("total_units"),
                                lecture_units = reader.GetString("lecture_units"),
                                lab_units = reader.GetString("lab_units"),
                                time = reader.GetString("time"),
                                day = reader.GetString("day"),
                                room = reader.GetString("room"),
                                instructor_id = reader.GetString("instructor_id"),
                                grade = reader.GetString("grade"),
                                remarks = reader.GetString("remarks")
                            };
                        }
                    }
                    await con.CloseAsync();
                    return studentSubject;
                }
            }
        }

        public Task UpdateRecords(StudentSubject entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<StudentSubject>> AddSubjectAsync(StudentSubject entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "insert into student_subjects(unique_id, school_year_id, subject_code, descriptive_title, lecture_units, pre_requisite, total_units, lab_units, " +
                    "time, day, room, instructor_id, id_number_id, grade, remarks) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.unique_id);
                    cmd.Parameters.AddWithValue("@2", entity.school_year_id);
                    cmd.Parameters.AddWithValue("@3", entity.subject_code);
                    cmd.Parameters.AddWithValue("@4", entity.descriptive_title);
                    cmd.Parameters.AddWithValue("@5", entity.lecture_units);
                    cmd.Parameters.AddWithValue("@6", entity.pre_requisite);
                    cmd.Parameters.AddWithValue("@7", entity.total_units);
                    cmd.Parameters.AddWithValue("@8", entity.lab_units);
                    cmd.Parameters.AddWithValue("@9", entity.time);
                    cmd.Parameters.AddWithValue("@10", entity.day);
                    cmd.Parameters.AddWithValue("@11", entity.room);
                    cmd.Parameters.AddWithValue("@12", entity.instructor_id);
                    cmd.Parameters.AddWithValue("@13", entity.id_number_id);
                    cmd.Parameters.AddWithValue("@14", entity.grade);
                    cmd.Parameters.AddWithValue("@15", entity.remarks);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
            return await GetAllAsync();
        }
    }
}
