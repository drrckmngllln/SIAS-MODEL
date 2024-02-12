using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class LevelsRepository : IGenericRepository<Levels>
    {
        MySqlConnection con = new MySqlConnection(connection.con());
        public async Task AddRecords(Levels entity)
        {
            await con.OpenAsync();
            var sql = "insert into levels(code, description, status) " +
                "values(@1,@2,@3)";
            using (var cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@1", entity.code);
                cmd.Parameters.AddWithValue("@2", entity.description);
                cmd.Parameters.AddWithValue("@3", entity.status);
                await cmd.ExecuteNonQueryAsync();
            }
            await con.CloseAsync();
        }

        public async Task DeleteRecords(Levels entity)
        {
            await con.OpenAsync();
            var cmd = new MySqlCommand("delete from levels where id='" + entity.id + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<Levels>> GetAllAsync()
        {
            var list = new List<Levels>();

            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from levels", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var level = new Levels
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    status = reader.GetString("status")
                };
                list.Add(level);
            }
            await con.CloseAsync();
            return list;
        }

        public async Task UpdateRecords(Levels entity)
        {
            await con.OpenAsync();
            var sql = "update levels set code=@1, description=@2, status=@3 where id='" + entity.id + "'";
            using (var cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@1", entity.code);
                cmd.Parameters.AddWithValue("@2", entity.description);
                cmd.Parameters.AddWithValue("@3", entity.status);
                await cmd.ExecuteNonQueryAsync();
            }
            await con.CloseAsync();
        }
    }
}
