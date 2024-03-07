using MySql.Data.MySqlClient;
using school_management_system_model.Core.Dtos;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Infrastructure.Data.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Transaction.StudentAccounts
{
    internal class StudentAccountRepository : IGenericRepository<StudentAccount>
    {

        public async Task AddRecords(StudentAccount entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var cmd = new MySqlCommand("insert into student_accounts(id_number, school_year, fullname, last_name, " +
                    "first_name, middle_name, gender, civil_status, date_of_birth, place_of_birth, nationality, " +
                    "religion, status,sy_enrolled, contact_no, email, elem, jhs, shs, elem_year,jhs_year, shs_year,mother_name,mother_no,father_name,father_no,home_address,m_occupation,f_occupation, type_of_student, date_of_admission) " +
                    "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32)", con);
                cmd.Parameters.AddWithValue("@1", entity.id_number);
                cmd.Parameters.AddWithValue("@2", entity.school_year_id);
                cmd.Parameters.AddWithValue("@3", entity.fullname);
                cmd.Parameters.AddWithValue("@4", entity.last_name);
                cmd.Parameters.AddWithValue("@5", entity.first_name);
                cmd.Parameters.AddWithValue("@6", entity.middle_name);
                cmd.Parameters.AddWithValue("@7", entity.gender);
                cmd.Parameters.AddWithValue("@8", entity.civil_status);
                cmd.Parameters.AddWithValue("@9", entity.date_of_birth);
                cmd.Parameters.AddWithValue("@10", entity.place_of_birth);
                cmd.Parameters.AddWithValue("@11", entity.nationality);
                cmd.Parameters.AddWithValue("@12", entity.religion);
                cmd.Parameters.AddWithValue("@13", entity.status);
                cmd.Parameters.AddWithValue("@14", entity.sy_enrolled);
                cmd.Parameters.AddWithValue("@16", entity.contact_no);
                cmd.Parameters.AddWithValue("@17", entity.email);
                cmd.Parameters.AddWithValue("@18", entity.elem);
                cmd.Parameters.AddWithValue("@19", entity.jhs);
                cmd.Parameters.AddWithValue("@20", entity.shs);
                cmd.Parameters.AddWithValue("@21", entity.elem_year);
                cmd.Parameters.AddWithValue("@22", entity.jhs_year);
                cmd.Parameters.AddWithValue("@23", entity.shs_year);
                cmd.Parameters.AddWithValue("@24", entity.mother_name);
                cmd.Parameters.AddWithValue("@25", entity.mother_no);
                cmd.Parameters.AddWithValue("@26", entity.father_name);
                cmd.Parameters.AddWithValue("@27", entity.father_no);
                cmd.Parameters.AddWithValue("@28", entity.home_address);
                cmd.Parameters.AddWithValue("@29", entity.m_occupation);
                cmd.Parameters.AddWithValue("@30", entity.f_occupation);
                cmd.Parameters.AddWithValue("@31", entity.type_of_student);
                cmd.Parameters.AddWithValue("@32", entity.date_of_admission);
                await cmd.ExecuteNonQueryAsync();
                await con.CloseAsync();
            }
        }

        public Task DeleteRecords(StudentAccount entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<StudentAccount>> GetAllAsync()
        {
            SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
            StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
            CourseRepository _courseRepo = new CourseRepository();

            var list = new List<StudentAccount>();
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from student_accounts", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                var student = new StudentAccount
                {
                    id = reader.GetInt32("id"),
                    id_number = reader.GetString("id_number"),
                    sy_enrolled = reader.GetString("sy_enrolled"),
                    school_year_id = reader.GetString("school_year"),
                    fullname = reader.GetString("fullname"),
                    last_name = reader.GetString("last_name"),
                    first_name = reader.GetString("first_name"),
                    middle_name = reader.GetString("middle_name"),
                    gender = reader.GetString("gender"),
                    civil_status = reader.GetString("civil_status"),
                    date_of_birth = reader.GetString("date_of_birth"),
                    place_of_birth = reader.GetString("place_of_birth"),
                    nationality = reader.GetString("nationality"),
                    religion = reader.GetString("religion"),
                    status = reader.GetString("status"),
                    contact_no = reader.GetString("contact_no"),
                    email = reader.GetString("email"),
                    elem = reader.GetString("elem"),
                    jhs = reader.GetString("jhs"),
                    shs = reader.GetString("shs"),
                    elem_year = reader.GetString("elem_year"),
                    jhs_year = reader.GetString("jhs_year"),
                    shs_year = reader.GetString("shs_year"),
                    mother_name = reader.GetString("mother_name"),
                    mother_no = reader.GetString("mother_no"),
                    father_name = reader.GetString("father_name"),
                    father_no = reader.GetString("father_no"),
                    home_address = reader.GetString("home_address"),
                    m_occupation = reader.GetString("m_occupation"),
                    f_occupation = reader.GetString("f_occupation"),
                    type_of_student = reader.GetString("type_of_student"),
                    date_of_admission = reader.GetString("date_of_admission"),
                };
                list.Add(student);
            }
            await con.CloseAsync();

            var schoolYears = await _schoolYearRepo.GetAllAsync();
            return list.Select(x => new StudentAccount
            {
                id = x.id,
                id_number = x.id_number,
                sy_enrolled = x.sy_enrolled,
                school_year_id = schoolYears.FirstOrDefault(sy => sy.id == Convert.ToInt32(x.school_year_id)).code,
                fullname = x.fullname,
                last_name = x.last_name,
                first_name = x.first_name,
                middle_name = x.middle_name,
                gender = x.gender,
                civil_status = x.civil_status,
                date_of_birth = x.date_of_birth,
                place_of_birth = x.place_of_birth,
                nationality = x.nationality,
                religion = x.religion,
                status = x.status,
                contact_no = x.contact_no,
                email = x.email,
                elem = x.elem,
                jhs = x.jhs,
                shs = x.shs,
                elem_year = x.elem_year,
                jhs_year = x.jhs_year,
                shs_year = x.shs_year,
                mother_name = x.mother_name,
                mother_no = x.mother_no,
                father_name = x.father_name,
                father_no = x.father_no,
                home_address = x.home_address,
                m_occupation = x.m_occupation,
                f_occupation = x.f_occupation,
                type_of_student = x.type_of_student,
                date_of_admission = x.date_of_admission
            }).ToList();
        }

        public async Task UpdateRecords(StudentAccount entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update student_accounts set id_number=@1, school_year=@2, fullname=@3, " +
                "last_name=@4, first_name=@5, middle_name=@6, gender=@7, civil_status=@8, date_of_birth=@9, " +
                "place_of_birth=@10, nationality=@11, religion=@12, status=@13, sy_enrolled=@14, contact_no=@16, " +
                "email=@17, elem=@18, jhs=@19, shs=@20, elem_year=@21, jhs_year=@22, shs_year=@23,mother_name=@24," +
                "mother_no=@25, father_name=@26,father_no=@27,home_address=@28, m_occupation=@29, f_occupation=@30, " +
                "type_of_student= @31, date_of_admission=@32 where id_number='" + entity.id_number + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.id_number);
            cmd.Parameters.AddWithValue("@2", entity.school_year_id);
            cmd.Parameters.AddWithValue("@3", entity.fullname);
            cmd.Parameters.AddWithValue("@4", entity.last_name);
            cmd.Parameters.AddWithValue("@5", entity.first_name);
            cmd.Parameters.AddWithValue("@6", entity.middle_name);
            cmd.Parameters.AddWithValue("@7", entity.gender);
            cmd.Parameters.AddWithValue("@8", entity.civil_status);
            cmd.Parameters.AddWithValue("@9", entity.date_of_birth);
            cmd.Parameters.AddWithValue("@10", entity.place_of_birth);
            cmd.Parameters.AddWithValue("@11", entity.nationality);
            cmd.Parameters.AddWithValue("@12", entity.religion);
            cmd.Parameters.AddWithValue("@13", entity.status);
            cmd.Parameters.AddWithValue("@14", entity.sy_enrolled);
            cmd.Parameters.AddWithValue("@16", entity.contact_no);
            cmd.Parameters.AddWithValue("@17", entity.email);
            cmd.Parameters.AddWithValue("@18", entity.elem);
            cmd.Parameters.AddWithValue("@19", entity.jhs);
            cmd.Parameters.AddWithValue("@20", entity.shs);
            cmd.Parameters.AddWithValue("@21", entity.elem_year);
            cmd.Parameters.AddWithValue("@22", entity.jhs_year);
            cmd.Parameters.AddWithValue("@23", entity.shs_year);
            cmd.Parameters.AddWithValue("@24", entity.mother_name);
            cmd.Parameters.AddWithValue("@25", entity.mother_no);
            cmd.Parameters.AddWithValue("@26", entity.father_name);
            cmd.Parameters.AddWithValue("@27", entity.father_no);
            cmd.Parameters.AddWithValue("@28", entity.home_address);
            cmd.Parameters.AddWithValue("@29", entity.m_occupation);
            cmd.Parameters.AddWithValue("@30", entity.f_occupation);
            cmd.Parameters.AddWithValue("@31", entity.type_of_student);
            cmd.Parameters.AddWithValue("@32", entity.date_of_admission);
            cmd.ExecuteNonQuery();
            await con.CloseAsync();
        }

        public async Task ChangeStudentStatus(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update student_accounts set Status='Accounting' " +
                "where id_number='" + idNumber + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task ApproveStudent(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update student_accounts set status='For Enrollment' where id='" + idNumber + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task StudentOfficiallyEnroll(string id_number_id, string status)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "update student_accounts set status='" + status + "' where id='" + id_number_id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public async Task<IReadOnlyList<StudentAccountDto>> GetStudentAccountDtoAsync()
        {
            var _studentCourseRepo = new StudentCourseRepository();
            var DtoList = new List<StudentAccountDto>();
            var studentAccountList = await GetAllAsync();


            var studentCourses = await _studentCourseRepo.GetAllAsync();

            foreach (var studentNumber in studentAccountList)
            {
                var Dto = new StudentAccountDto
                {
                    id = studentNumber.id,
                    name = studentNumber.fullname,
                    gender = studentNumber.gender,
                    course = studentCourses.FirstOrDefault(x => x.id_number == studentNumber.id_number).course,
                    section = studentCourses.FirstOrDefault(x => x.id_number == studentNumber.id_number).section,
                    year_level = studentCourses.FirstOrDefault(x => x.id_number == studentNumber.id_number).year_level
                };
                DtoList.Add(Dto);
            }
            return DtoList.Select(d => new StudentAccountDto
            {
                id = d.id,
                name = d.name,
                gender = d.gender,
                course = d.course,
                section = d.section,
                year_level = d.year_level
            }).ToList();
        }

        public async Task<StudentAccountDetailDto> GetStudentDetailAsync(string id_number)
        {
            var student = await GetAllAsync();

            var _studentCourseRepo = new StudentCourseRepository();

            var studentCourse = await _studentCourseRepo.GetAllAsync();

            var studentDetail = student.FirstOrDefault(x => x.id_number ==  id_number);

            var studentDto = new StudentAccountDetailDto
            {
                id = studentDetail.id,
                name = studentDetail.fullname,
                course = studentCourse.FirstOrDefault(x => x.id_number == id_number).course,
                year_level = studentCourse.FirstOrDefault(x => x.id_number == id_number).year_level,
                semester = studentCourse.FirstOrDefault(x => x.id_number == id_number).semester,
                campus = studentCourse.FirstOrDefault(x => x.id_number == id_number).campus,
                status = studentDetail.status
            };

            return studentDto;
        }

        public async Task<IReadOnlyList<StudentAccountsMainDto>> GetStudentAccountsMainAsync(StudentAccountsMainSpecifications accountspec)
        {
            
        }
    }
}
