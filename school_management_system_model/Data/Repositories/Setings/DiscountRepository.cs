using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class DiscountRepository : IGenericRepository<Discount>
    {
        public async Task AddRecords(Discount entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into discount_setup(code, description, discount_percentage, discount_target) " +
                "values(@1,@2,@3,@4)", con);
            cmd.Parameters.AddWithValue("@1", entity.code);
            cmd.Parameters.AddWithValue("@2", entity.description);
            cmd.Parameters.AddWithValue("@3", entity.discount_percentage);
            cmd.Parameters.AddWithValue("@4", entity.discount_target);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeleteRecords(Discount entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("delete from discount_setup where id='" + entity.id + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<Discount>> GetAllAsync()
        {
            var list = new List<Discount>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from discount_setup";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var discount = new Discount
                            {
                                id = reader.GetInt32("id"),
                                code = reader.GetString("code"),
                                description = reader.GetString("description"),
                                discount_target = reader.GetString("discount_target"),
                                discount_percentage = reader.GetInt32("discount_percentage")
                            };
                            list.Add(discount);
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public async Task UpdateRecords(Discount entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update discount_setup set code=@1, description=@2, discount_percentage=@3, discount_target=@4 " +
                "where id='" + entity.id + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.code);
            cmd.Parameters.AddWithValue("@2", entity.description);
            cmd.Parameters.AddWithValue("@3", entity.discount_percentage);
            cmd.Parameters.AddWithValue("@4", entity.discount_target);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}
