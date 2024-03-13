using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class CourseRepository : IGenericRepository<Courses>
    {
        DepartmentRepository _departmentRepo = new DepartmentRepository();
        LevelsRepository _levelsRepo = new LevelsRepository();
        CampusRepository _campusRepo = new CampusRepository();
        public async Task AddRecords(Courses entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "insert into courses(code, description, level_id, campus_id, department_id, max_units, status) " +
                    "values(@1,@2,@3,@4,@5,@6,@7)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.code);
                    cmd.Parameters.AddWithValue("@2", entity.description);
                    cmd.Parameters.AddWithValue("@3", entity.level);
                    cmd.Parameters.AddWithValue("@4", entity.campus);
                    cmd.Parameters.AddWithValue("@5", entity.department);
                    cmd.Parameters.AddWithValue("@6", entity.max_units);
                    cmd.Parameters.AddWithValue("@7", entity.status);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public async Task DeleteRecords(Courses entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "delete from courses where id='" + entity.id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public async Task<IReadOnlyList<Courses>> GetAllAsync()
        {
            var _campusRepo = new CampusRepository();
            var list = new List<Courses>();
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from courses", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var level = await _levelsRepo.GetByIdAsync(reader.GetInt32("level_id"));

                var campus = await _campusRepo.GetByIdAsync(reader.GetInt32("campus_id"));

                var department = await _departmentRepo.GetByIdAsync(reader.GetInt32("department_id"));

                var course = new Courses
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    level = level.code,
                    campus = campus.code,
                    department = department.code,
                    max_units = reader.GetString("max_units"),
                    status = reader.GetString("status")
                };
                list.Add(course);
            }
            await con.CloseAsync();
            return list;
        }

        public async Task<Courses> GetByIdAsync(int id)
        {
            var course = new Courses();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from courses where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var level = await _levelsRepo.GetByIdAsync(reader.GetInt32("level_id"));
                            var campuses = await _campusRepo.GetByIdAsync(reader.GetInt32("campus_id"));
                            var department = await _departmentRepo.GetByIdAsync(reader.GetInt32("department_id"));
                            course = new Courses
                            {
                                id = reader.GetInt32("id"),
                                code = reader.GetString("code"),
                                description = reader.GetString("description"),
                                level = level.code,
                                campus = campuses.code,
                                department = department.code,
                                max_units = reader.GetString("max_units"),
                                status = reader.GetString("status")
                            };
                        }

                    }
                }
                await con.CloseAsync();
                return course;
            }
        }

        public async Task<Courses> GetByCodeAsync(string code)
        {
            var course = new Courses();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from courses where code='"+ code +"'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var level = await _levelsRepo.GetByIdAsync(reader.GetInt32("level_id"));
                            var campuses = await _campusRepo.GetByIdAsync(reader.GetInt32("campus_id"));
                            var department = await _departmentRepo.GetByIdAsync(reader.GetInt32("department_id"));
                            course = new Courses
                            {
                                id = reader.GetInt32("id"),
                                code = reader.GetString("code"),
                                description = reader.GetString("description"),
                                level = level.code,
                                campus = campuses.code,
                                department = department.code,
                                max_units = reader.GetString("max_units"),
                                status = reader.GetString("status")
                            };
                        }
                        await con.CloseAsync();
                        return course;
                    }
                }
            }
        }

        public async Task UpdateRecords(Courses entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "update courses set code=@1, description=@2, level_id=@3, campus_id=@4, department_id=@5, max_units=@6, status=@7 " +
                    "where id='" + entity.id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.code);
                    cmd.Parameters.AddWithValue("@2", entity.description);
                    cmd.Parameters.AddWithValue("@3", entity.level);
                    cmd.Parameters.AddWithValue("@4", entity.campus);
                    cmd.Parameters.AddWithValue("@5", entity.department);
                    cmd.Parameters.AddWithValue("@6", entity.max_units);
                    cmd.Parameters.AddWithValue("@7", entity.status);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }
    }
}
