using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class DepartmentRepository : IGenericRepository<Departments>
    {
        MySqlConnection con = new MySqlConnection(connection.con());
        CampusRepository _campusRepo = new CampusRepository();
        public async Task AddRecords(Departments entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var sql = "insert into departments(code, description, campus_id) " +
                "values(@1,@2,@3)";
            using (var cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@1", entity.code);
                cmd.Parameters.AddWithValue("@2", entity.description);
                cmd.Parameters.AddWithValue("@3", entity.campus);
                await cmd.ExecuteNonQueryAsync();
            }
            await con.CloseAsync();
        }

        public async Task DeleteRecords(Departments entity)
        {
            await con.OpenAsync();
            var sql = "delete from departments where id='" + entity.id + "'";
            using (var cmd = new MySqlCommand(sql, con))
            {
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<IReadOnlyList<Departments>> GetAllAsync()
        {
            var list = new List<Departments>();

            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from departments", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var a = await _campusRepo.GetAllAsync();
                var campus = a.FirstOrDefault(x => x.id == reader.GetInt32("campus_id")).code;

                var departments = new Departments
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    campus = campus
                };
                list.Add(departments);
            }
            await con.CloseAsync();
            return list;
        }

        public async Task<Departments> GetByIdAsync(int id)
        {
            var _campusRepo = new CampusRepository();
            var dep = new Departments();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from departments where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var campus = await _campusRepo.GetByIdAsync(reader.GetInt32("id"));
                            dep = new Departments
                            {
                                id = reader.GetInt32("id"),
                                code = reader.GetString("code"),
                                description = reader.GetString("description"),
                                campus = campus.code,
                            };
                        }
                    }
                }
            }
            await con.CloseAsync();
            return dep;
        }

        public async Task UpdateRecords(Departments entity)
        {
            await con.OpenAsync();
            var sql = "update departments set code=@1, description=@2, campus_id=@3 where id='" + entity.id + "'";
            using (var cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@1", entity.code);
                cmd.Parameters.AddWithValue("@2", entity.description);
                cmd.Parameters.AddWithValue("@3", entity.campus);
                await cmd.ExecuteNonQueryAsync();
            }
            await con.CloseAsync();
        }
    }
}
