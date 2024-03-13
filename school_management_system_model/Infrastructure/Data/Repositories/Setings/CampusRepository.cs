using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class CampusRepository : IGenericRepository<Campuses>
    {
        MySqlConnection con = new MySqlConnection(connection.con());
        public async Task AddRecords(Campuses entity)
        {
            await con.OpenAsync();
            var sql = "insert into campuses(code, description, address, status) " +
                "values(@1,@2,@3,@4)";
            using (var cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@1", entity.code);
                cmd.Parameters.AddWithValue("@2", entity.description);
                cmd.Parameters.AddWithValue("@3", entity.address);
                cmd.Parameters.AddWithValue("@4", entity.status);
                await cmd.ExecuteNonQueryAsync();
            }
            await con.CloseAsync();
        }

        public async Task DeleteRecords(Campuses entity)
        {
            await con.OpenAsync();
            var cmd = new MySqlCommand("delete from campuses where id='" + entity.id + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<Campuses>> GetAllAsync()
        {
            var list = new List<Campuses>();
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from campuses", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var campus = new Campuses
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    address = reader.GetString("address"),
                    status = reader.GetString("status")
                };
                list.Add(campus);
            }
            await con.CloseAsync();
            return list;
        }

        public async Task<Campuses> GetByIdAsync(int id)
        {
            var campuses = new Campuses();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from campuses where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            campuses = new Campuses
                            {
                                id = reader.GetInt32("id"),
                                code = reader.GetString("code"),
                                description = reader.GetString("description"),
                                address = reader.GetString("address"),
                                status = reader.GetString("status")
                            };
                        }
                    }
                }
            }
            await con.CloseAsync();
            return campuses;
        }

        public async Task<Campuses> GetByCodeAsync(string code)
        {
            var campuses = new Campuses();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from campuses where code='" + code + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            campuses = new Campuses
                            {
                                id = reader.GetInt32("id"),
                                code = reader.GetString("code"),
                                description = reader.GetString("description"),
                                address = reader.GetString("address"),
                                status = reader.GetString("status")
                            };
                        }
                    }
                }
            }
            await con.CloseAsync();
            return campuses;
        }

        public async Task UpdateRecords(Campuses entity)
        {
            await con.OpenAsync();
            var sql = "update campuses set code=@1, description=@2, address=@3, status=@4 where id='" + entity.id + "'";
            using (var cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@1", entity.code);
                cmd.Parameters.AddWithValue("@2", entity.description);
                cmd.Parameters.AddWithValue("@3", entity.address);
                cmd.Parameters.AddWithValue("@4", entity.status);
                await cmd.ExecuteNonQueryAsync();
            }
            await con.CloseAsync();
        }
    }
}
