﻿using MySql.Data.MySqlClient;
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
                var a = await _levelsRepo.GetAllAsync();
                var level = a.FirstOrDefault(x => x.id == reader.GetInt32("level_id")).code;

                var b = await _campusRepo.GetAllAsync();
                var campus = b.FirstOrDefault(x => x.id == reader.GetInt32("campus_id")).code;

                var c = await _departmentRepo.GetAllAsync();
                var department = c.FirstOrDefault(x => x.id == reader.GetInt32("department_id")).code;

                var course = new Courses
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    level = level,
                    campus = campus,
                    department = department,
                    max_units = reader.GetString("max_units"),
                    status = reader.GetString("status")
                };
                list.Add(course);
            }
            await con.CloseAsync();
            return list;
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