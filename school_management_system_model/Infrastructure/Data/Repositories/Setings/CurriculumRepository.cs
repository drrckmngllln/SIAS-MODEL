using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;


namespace school_management_system_model.Data.Repositories.Setings
{
    internal class CurriculumRepository : IGenericRepository<Curriculums>
    {
        CourseRepository _coursesRepo = new CourseRepository();
        CampusRepository _campusRepo = new CampusRepository();
        MySqlConnection con = new MySqlConnection(connection.con());
        public async Task AddRecords(Curriculums entity)
        {
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into curriculums(code, description, campus_id, course_id, effective, expires, status) " +
                "values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", entity.code);
            cmd.Parameters.AddWithValue("@2", entity.description);
            cmd.Parameters.AddWithValue("@3", entity.campus);
            cmd.Parameters.AddWithValue("@4", entity.course);
            cmd.Parameters.AddWithValue("@5", entity.effective);
            cmd.Parameters.AddWithValue("@6", entity.expires);
            cmd.Parameters.AddWithValue("@7", entity.status);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeleteRecords(Curriculums entity)
        {
            await con.OpenAsync();
            var sql = "delete from curriculums where id='" + entity.id + "'";
            using (var cmd = new MySqlCommand(sql, con))
            {
                await cmd.ExecuteNonQueryAsync();
            }
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<Curriculums>> GetAllAsync()
        {
            var list = new List<Curriculums>();
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from curriculums", con);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var a = await _campusRepo.GetByIdAsync(reader.GetInt32("campus_id"));

                var b = await _coursesRepo.GetByIdAsync(reader.GetInt32("course_id"));
                var curriculum = new Curriculums
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    campus = a.code,
                    course = b.code,
                    effective = reader.GetString("effective"),
                    expires = reader.GetString("expires"),
                    status = reader.GetString("status")
                };
                list.Add(curriculum);
            }

            await con.CloseAsync();
            return list;
        }

        public async Task<Curriculums> GetByIdAsync(int id)
        {
            var curriculum = new Curriculums();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from curriculums where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var campuses = await _campusRepo.GetByIdAsync(reader.GetInt32("campus_id"));
                            var course = await _coursesRepo.GetByIdAsync(reader.GetInt32("course_id"));
                            curriculum = new Curriculums
                            {
                                id = reader.GetInt32("id"),
                                code = reader.GetString("code"),
                                description = reader.GetString("description"),
                                campus = campuses.code,
                                course = course.code,
                                effective = reader.GetString("effective"),
                                expires = reader.GetString("expires"),
                                status = reader.GetString("status")
                            };
                        }

                    }
                }
                await con.CloseAsync();
                return curriculum;
            }
        }

        public async Task UpdateRecords(Curriculums entity)
        {
            await con.OpenAsync();
            var cmd = new MySqlCommand("update curriculums set code=@1, description=@2, campus_id=@3, course_id=@4, effective=@5, expires=@6, " +
                "status=@7 where id='" + entity.id + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.code);
            cmd.Parameters.AddWithValue("@2", entity.description);
            cmd.Parameters.AddWithValue("@3", entity.campus);
            cmd.Parameters.AddWithValue("@4", entity.course);
            cmd.Parameters.AddWithValue("@5", entity.effective);
            cmd.Parameters.AddWithValue("@6", entity.expires);
            cmd.Parameters.AddWithValue("@7", entity.status);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}
