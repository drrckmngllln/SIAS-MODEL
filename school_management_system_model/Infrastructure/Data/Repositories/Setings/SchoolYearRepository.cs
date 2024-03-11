using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class SchoolYearRepository : IGenericRepository<SchoolYear>
    {
        public async Task AddRecords(SchoolYear entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "insert into school_year(code, description, school_year_from, school_year_to, semester, is_current) " +
                    "values(@1,@2,@3,@4,@5,@6)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.code);
                    cmd.Parameters.AddWithValue("@2", entity.description);
                    cmd.Parameters.AddWithValue("@3", entity.school_year_from);
                    cmd.Parameters.AddWithValue("@4", entity.school_year_to);
                    cmd.Parameters.AddWithValue("@5", entity.semester);
                    cmd.Parameters.AddWithValue("@6", entity.is_current);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }

        }

        public async Task DeleteRecords(SchoolYear entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var cmd = new MySqlCommand("delete from school_year where id='" + entity.id + "'", con);
                await cmd.ExecuteNonQueryAsync();
                await con.CloseAsync();
            }
        }

        public async Task<IReadOnlyList<SchoolYear>> GetAllAsync()
        {
            var list = new List<SchoolYear>();
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from school_year", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var schoolYear = new SchoolYear
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    school_year_from = reader.GetString("school_year_from"),
                    school_year_to = reader.GetString("school_year_to"),
                    semester = reader.GetString("semester"),
                    is_current = reader.GetString("is_current")
                };
                list.Add(schoolYear);
            }
            await con.CloseAsync();
            return list;
        }

        public async Task<SchoolYear> GetByIdAsync(int id)
        {
            var schoolYear = new SchoolYear();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from school_year where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            schoolYear = new SchoolYear
                            {
                                id = reader.GetInt32("id"),
                                code = reader.GetString("code"),
                                description = reader.GetString("description"),
                                school_year_from = reader.GetString("school_year_from"),
                                school_year_to = reader.GetString("school_year_to"),
                                semester = reader.GetString("semester"),
                                is_current = reader.GetString("is_current")
                            };
                        }
                    }
                    await con.CloseAsync();
                    return schoolYear;
                }
            }
        }

        public async Task UpdateRecords(SchoolYear entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "update school_year set code=@1, description=@2, school_year_from=@3, school_year_to=@4, semester=@5, is_current=@6 " +
                    "where id='" + entity.id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.code);
                    cmd.Parameters.AddWithValue("@2", entity.description);
                    cmd.Parameters.AddWithValue("@3", entity.school_year_from);
                    cmd.Parameters.AddWithValue("@4", entity.school_year_to);
                    cmd.Parameters.AddWithValue("@5", entity.semester);
                    cmd.Parameters.AddWithValue("@6", entity.is_current);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }
    }
}
