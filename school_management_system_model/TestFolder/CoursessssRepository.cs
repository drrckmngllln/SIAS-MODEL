using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.TestFolder
{
    internal class CoursessssRepository : IGenericRepository<Coursesss>
    {
        LevelsRepository _levelRepo = new LevelsRepository();
        CampusRepository _campusRepo = new CampusRepository();
        DepartmentRepository _departmentRepo = new DepartmentRepository();

        public Task AddRecords(Coursesss entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecords(Coursesss entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Coursesss>> GetAllAsync()
        {
            var list = new List<Coursesss>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from courses";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var courses = new Coursesss
                            {
                                id = reader.GetInt32("id"),
                                code = reader.GetString("code"),
                                description = reader.GetString("description"),
                                level_id = reader.GetString("level_id"),
                                campus_id = reader.GetString("campus_id"),
                                department_id = reader.GetString("department_id"),
                                max_units = reader.GetDecimal("max_units"),
                                status = reader.GetString("status"),
                            };
                            list.Add(courses);
                        }
                    }
                }
            }

            var levels = await _levelRepo.GetAllAsync();
            var campuses = await _campusRepo.GetAllAsync();
            var departments = await _departmentRepo.GetAllAsync();

            return list.Select(x => new Coursesss
            {
                id = x.id,
                code = x.code,
                description = x.description,
                level_id = levels.FirstOrDefault(lvl => lvl.id == Convert.ToInt32(x.level_id)).code,
                campus_id = campuses.FirstOrDefault(c => c.id == Convert.ToInt32(x.campus_id)).code,
                department_id = departments.FirstOrDefault(lvl => lvl.id == Convert.ToInt32(x.department_id)).code,
                max_units = x.max_units,
                status = x.status,
            }).ToList();
        }

        public Task UpdateRecords(Coursesss entity)
        {
            throw new NotImplementedException();
        }
    }
}
