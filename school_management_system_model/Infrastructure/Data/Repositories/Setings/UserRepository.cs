using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class UserRepository : IGenericRepository<User>
    {
        MySqlConnection con = new MySqlConnection(connection.con());
        public async Task AddRecords(User entity)
        {
            MySqlConnection con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into users(last_name, first_name, middle_name, fullname, employee_id, email, password, access_level, " +
                "is_add, is_edit, is_delete, department, is_administrator) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)", con);
            cmd.Parameters.AddWithValue("@1", entity.last_name);
            cmd.Parameters.AddWithValue("@2", entity.first_name);
            cmd.Parameters.AddWithValue("@3", entity.middle_name);
            cmd.Parameters.AddWithValue("@4", entity.fullname);
            cmd.Parameters.AddWithValue("@5", entity.employee_id);
            cmd.Parameters.AddWithValue("@6", entity.email);
            cmd.Parameters.AddWithValue("@7", entity.password);
            cmd.Parameters.AddWithValue("@8", entity.access_level);
            cmd.Parameters.AddWithValue("@9", entity.add);
            cmd.Parameters.AddWithValue("@10", entity.edit);
            cmd.Parameters.AddWithValue("@11", entity.delete);
            cmd.Parameters.AddWithValue("@12", entity.department);
            cmd.Parameters.AddWithValue("@13", entity.administrator);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeleteRecords(User entity)
        {
            MySqlConnection con = new MySqlConnection(connection.con());


            await con.OpenAsync();
            var cmd = new MySqlCommand("delete from users where id='" + entity.id + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            MySqlConnection con = new MySqlConnection(connection.con());

            var list = new List<User>();
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from users", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var user = new User
                {
                    id = reader.GetInt32("id"),
                    last_name = reader.GetString("last_name"),
                    first_name = reader.GetString("first_name"),
                    middle_name = reader.GetString("middle_name"),
                    fullname = reader.GetString("fullname"),
                    employee_id = reader.GetString("employee_id"),
                    email = reader.GetString("email"),
                    password = reader.GetString("password"),
                    department = reader.GetString("department"),
                    access_level = reader.GetString("access_level"),
                    add = reader.GetInt32("is_add"),
                    edit = reader.GetInt32("is_edit"),
                    delete = reader.GetInt32("is_delete"),
                    administrator = reader.GetInt32("is_administrator"),
                };
                list.Add(user);
            }
            await con.CloseAsync();
            return list;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = new User();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from users where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                id = reader.GetInt32("id"),
                                last_name = reader.GetString("last_name"),
                                first_name = reader.GetString("first_name"),
                                middle_name = reader.GetString("middle_name"),
                                fullname = reader.GetString("fullname"),
                                employee_id = reader.GetString("employee_id"),
                                email = reader.GetString("email"),
                                password = reader.GetString("password"),
                                department = reader.GetString("department"),
                                access_level = reader.GetString("access_level"),
                                add = reader.GetInt32("is_add"),
                                edit = reader.GetInt32("is_edit"),
                                delete = reader.GetInt32("is_delete"),
                                administrator = reader.GetInt32("is_administrator"),
                            };
                        }
                        await con.CloseAsync();
                        return user;
                    }
                }
            }
        }

        public async Task UpdateRecords(User entity)
        {
            MySqlConnection con = new MySqlConnection(connection.con());

            await con.OpenAsync();
            var cmd = new MySqlCommand("update users set last_name=@1, first_name=@2, middle_name=@3, fullname=@4, employee_id=@5, email=@6, password=@7, " +
                "access_level=@8, is_add=@9, is_edit=@10, is_delete=@11, department=@12, is_administrator=@13 where id='" + entity.id + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.last_name);
            cmd.Parameters.AddWithValue("@2", entity.first_name);
            cmd.Parameters.AddWithValue("@3", entity.middle_name);
            cmd.Parameters.AddWithValue("@4", entity.fullname);
            cmd.Parameters.AddWithValue("@5", entity.employee_id);
            cmd.Parameters.AddWithValue("@6", entity.email);
            cmd.Parameters.AddWithValue("@7", entity.password);
            cmd.Parameters.AddWithValue("@8", entity.access_level);
            cmd.Parameters.AddWithValue("@9", entity.add);
            cmd.Parameters.AddWithValue("@10", entity.edit);
            cmd.Parameters.AddWithValue("@11", entity.delete);
            cmd.Parameters.AddWithValue("@12", entity.department);
            cmd.Parameters.AddWithValue("@13", entity.administrator);

            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}
