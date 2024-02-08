using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class InstructorRepository : IGenericRepository<Instructors>
    {
        MySqlConnection con = new MySqlConnection(connection.con());
        DepartmentRepository _departmentRepo = new DepartmentRepository();
        public async Task AddRecords(Instructors entity)
        {
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into instructors(fullname, department_id, position) values(@1,@2,@3)", con);
            cmd.Parameters.AddWithValue("@1", entity.fullname);
            cmd.Parameters.AddWithValue("@2", entity.department_id);
            cmd.Parameters.AddWithValue("@3", entity.position);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeleteRecords(Instructors entity)
        {
            await con.OpenAsync();
            var cmd = new MySqlCommand("delete from instructors where id='" + entity.id + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<Instructors>> GetAllAsync()
        {
            var list = new List<Instructors>();
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from instructors", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var a = await _departmentRepo.GetAllAsync();
                var department = a.FirstOrDefault(x => x.id == reader.GetInt32("department_id"));
                var instructors = new Instructors
                {
                    id = reader.GetInt32("id"),
                    fullname = reader.GetString("fullname"),
                    department_id = department.code,
                    position = reader.GetString("position"),
                };
                list.Add(instructors);
            }
            await con.CloseAsync();
            return list;
        }

        public async Task UpdateRecords(Instructors entity)
        {
            await con.OpenAsync();
            var cmd = new MySqlCommand("update instructors set fullname=@1, department_id=@2, position=@3 where id='" + entity.id + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.fullname);
            cmd.Parameters.AddWithValue("@2", entity.department_id);
            cmd.Parameters.AddWithValue("@3", entity.position);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}
