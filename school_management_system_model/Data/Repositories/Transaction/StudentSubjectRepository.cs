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

namespace school_management_system_model.Data.Repositories.Transaction.StudentAssessment
{
    internal class StudentSubjectRepository : IGenericRepository<StudentSubject>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        InstructorRepository _instructorRepo = new InstructorRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        public Task AddRecords(StudentSubject entity)
        {
            throw new NotImplementedException();
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
                    var instructor = c.FirstOrDefault(x => x.id == reader.GetInt32("instructor_id"));

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
                        //instructor_id = instructor.fullname,
                        //grade = reader.GetString("grade"),
                        //remarks = reader.GetString("remarks")
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
