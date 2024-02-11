using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                "pre_requisite, total_units, lecture_units, lab_units, time, day, room, instructor_id) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)", con);
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
                    var a = await _studentAccountRepo.GetAllAsync();
                    var id_number = a.FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));

                    var b = await _schoolYearRepo.GetAllAsync();
                    var school_year = b.FirstOrDefault(x => x.id == reader.GetInt32("school_year_id"));

                    var c = await _instructorRepo.GetAllAsync();
                    string instructor;
                    if (reader.GetString("instructor_id") == "Not Set")
                    {
                        instructor = "Not Set";
                    }
                    else
                    {
                        instructor = c.FirstOrDefault(x => x.id == reader.GetInt32("instructor_id")).fullname;
                    }
                        
                        //c.FirstOrDefault(x => x.id == reader.GetInt32("instructor_id"));

                    var studentSubjects = new StudentSubject
                    {
                        id = reader.GetInt32("id"),
                        id_number_id = id_number.id_number,
                        unique_id = reader.GetString("unique_id"),
                        school_year_id = school_year.code,
                        subject_code = reader.GetString("subject_code"),
                        descriptive_title = reader.GetString("descriptive_title"),
                        pre_requisite = reader.GetString("pre_requisite"),
                        total_units = reader.GetString("total_units"),
                        lecture_units = reader.GetString("lecture_units"),
                        lab_units = reader.GetString("lab_units"),
                        time = reader.GetString("time"),
                        day = reader.GetString("day"),
                        room = reader.GetString("room"),
                        instructor_id = instructor,
                        grade = reader.GetString("grade"),
                        remarks = reader.GetString("remarks")
                    };
                    list.Add(studentSubjects);
                }
                await con.CloseAsync();
            }
            
            return list;
        }

        public Task UpdateRecords(StudentSubject entity)
        {
            throw new NotImplementedException();
        }
    }
}
