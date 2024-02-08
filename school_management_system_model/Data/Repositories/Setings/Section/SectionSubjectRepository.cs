using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings.Section
{
    internal class SectionSubjectRepository : IGenericRepository<SectionSubjects>
    {
        SectionRepository _sectionRepo = new SectionRepository();
        public async Task AddRecords(SectionSubjects entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var cmd = new MySqlCommand("insert into section_subjects(unique_id, section_code, year_level, semester, subject_code, " +
                    "descriptive_title, total_units, lecture_units, lab_units, pre_requisite, time, day, room, instructor) " +
                    "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14)", con);
                cmd.Parameters.AddWithValue("@1", entity.unique_id);
                cmd.Parameters.AddWithValue("@2", entity.section_code);
                cmd.Parameters.AddWithValue("@3", entity.year_level);
                cmd.Parameters.AddWithValue("@4", entity.semester);
                cmd.Parameters.AddWithValue("@5", entity.subject_code);
                cmd.Parameters.AddWithValue("@6", entity.descriptive_title);
                cmd.Parameters.AddWithValue("@7", entity.total_units);
                cmd.Parameters.AddWithValue("@8", entity.lecture_units);
                cmd.Parameters.AddWithValue("@9", entity.lab_units);
                cmd.Parameters.AddWithValue("@10", entity.pre_requisite);
                cmd.Parameters.AddWithValue("@11", "Not Set");
                cmd.Parameters.AddWithValue("@12", "Not Set");
                cmd.Parameters.AddWithValue("@13", "Not Set");
                cmd.Parameters.AddWithValue("@14", "Not Set");
                cmd.ExecuteNonQuery();
                await con.CloseAsync();
            }
        }

        public Task DeleteRecords(SectionSubjects entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<SectionSubjects>> GetAllAsync()
        {
            var list = new List<SectionSubjects>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                using (var cmd = new MySqlCommand("select * from section_subjects", con))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var sectionSubjects = new SectionSubjects
                        {
                            id = reader.GetInt32("id"),
                            unique_id = reader.GetString("unique_id"),
                            section_code = reader.GetString("section_code"),
                            year_level = reader.GetString("year_level"),
                            semester = reader.GetString("semester"),
                            subject_code = reader.GetString("subject_code"),
                            descriptive_title = reader.GetString("descriptive_title"),
                            total_units = reader.GetString("total_units"),
                            lecture_units = reader.GetString("lecture_units"),
                            lab_units = reader.GetString("lab_units"),
                            pre_requisite = reader.GetString("pre_requisite"),
                            time = reader.GetString("time"),
                            day = reader.GetString("day"),
                            room = reader.GetString("room"),
                            instructor = reader.GetString("instructor"),
                        };
                        list.Add(sectionSubjects);
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }
        public async Task UpdateRecords(SectionSubjects entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update section_subjects set time=@1, day=@2, room=@3, instructor_id=@4 where id='" + entity.id + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.time);
            cmd.Parameters.AddWithValue("@2", entity.day);
            cmd.Parameters.AddWithValue("@3", entity.room);
            cmd.Parameters.AddWithValue("@4", entity.instructor);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}
