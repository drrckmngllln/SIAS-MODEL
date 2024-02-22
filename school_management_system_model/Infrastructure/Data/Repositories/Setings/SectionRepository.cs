using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings.Section
{
    internal class SectionRepository : IGenericRepository<Sections>
    {
        public async Task AddRecords(Sections entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into sections(section_code, course, year_level, section, number_of_students, max_number_of_students, " +
                "status, remarks, semester, unique_id) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)", con);
            cmd.Parameters.AddWithValue("@1", entity.section_code);
            cmd.Parameters.AddWithValue("@2", entity.course);
            cmd.Parameters.AddWithValue("@3", entity.year_level);
            cmd.Parameters.AddWithValue("@4", entity.section);
            cmd.Parameters.AddWithValue("@5", entity.number_of_students);
            cmd.Parameters.AddWithValue("@6", entity.max_number_of_students);
            cmd.Parameters.AddWithValue("@7", entity.status);
            cmd.Parameters.AddWithValue("@8", entity.remarks);
            cmd.Parameters.AddWithValue("@9", entity.semester);
            cmd.Parameters.AddWithValue("@10", entity.unique_id);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeleteRecords(Sections entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("delete from sections where section_code='" + entity.section_code + "'", con);
            cmd.ExecuteNonQuery();

            cmd = new MySqlCommand("delete from section_subjects where section_code='" + entity.section_code + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<Sections>> GetAllAsync()
        {
            var list = new List<Sections>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from sections";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var sections = new Sections
                            {
                                id = reader.GetInt32("Id"),
                                unique_id = reader.GetString("unique_id"),
                                section_code = reader.GetString("section_code"),
                                course = reader.GetString("course"),
                                year_level = reader.GetInt32("year_level"),
                                section = reader.GetString("section"),
                                semester = reader.GetString("semester"),
                                number_of_students = reader.GetInt32("number_of_students"),
                                max_number_of_students = reader.GetInt32("max_number_of_students"),
                                status = reader.GetString("status"),
                                remarks = reader.GetString("remarks")
                            };
                            list.Add(sections);
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public async Task UpdateRecords(Sections entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update sections set section_code=@1, course=@2, year_level=@3, section=@4, number_of_students=@5, " +
                "max_number_of_students=@6, status=@7, remarks=@8, semester=@9, unique_id=@10 where id='" + entity.id + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.section_code);
            cmd.Parameters.AddWithValue("@2", entity.course);
            cmd.Parameters.AddWithValue("@3", entity.year_level);
            cmd.Parameters.AddWithValue("@4", entity.section);
            cmd.Parameters.AddWithValue("@5", entity.number_of_students);
            cmd.Parameters.AddWithValue("@6", entity.max_number_of_students);
            cmd.Parameters.AddWithValue("@7", entity.status);
            cmd.Parameters.AddWithValue("@8", entity.remarks);
            cmd.Parameters.AddWithValue("@9", entity.semester);
            cmd.Parameters.AddWithValue("@10", entity.unique_id);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public void IncrementNumberOfStudent(int id, int numberOfStudents)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update sections set number_of_students='" + numberOfStudents + "' where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void FullStudent(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update sections set status='Full' where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
