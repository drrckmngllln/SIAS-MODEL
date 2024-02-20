using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings.Section
{
    internal class SectionSubjectRepository : IGenericRepository<SectionSubjects>
    {
        SectionRepository _sectionRepo = new SectionRepository();
        CurriculumRepository _curriculumRepo = new CurriculumRepository();
        public async Task AddRecords(SectionSubjects entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var cmd = new MySqlCommand("insert into section_subjects(unique_id, section_code, year_level, semester, subject_code, " +
                    "descriptive_title, total_units, lecture_units, lab_units, pre_requisite, time, day, room, instructor, curriculum_id) " +
                    "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)", con);
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
                cmd.Parameters.AddWithValue("@15", entity.curriculum);
                await cmd.ExecuteNonQueryAsync();
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
                            curriculum = reader.GetString("curriculum_id"),
                            year_level = reader.GetString("year_level"),
                            semester = reader.GetString("semester"),
                            subject_code = reader.GetString("subject_code"),
                            descriptive_title = reader.GetString("descriptive_title"),
                            total_units = reader.GetDecimal("total_units"),
                            lecture_units = reader.GetDecimal("lecture_units"),
                            lab_units = reader.GetDecimal("lab_units"),
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

                var curriculums = await _curriculumRepo.GetAllAsync();

                return list.Select(x => new SectionSubjects
                {
                    id = x.id,
                    unique_id = x.unique_id,
                    section_code = x.section_code,
                    curriculum = curriculums.FirstOrDefault(c => c.id == Convert.ToInt32(x.curriculum)).code,
                    year_level = x.year_level,
                    semester = x.semester,
                    subject_code = x.subject_code,
                    descriptive_title = x.descriptive_title,
                    total_units = x.total_units,
                    lecture_units = x.lecture_units,
                    lab_units = x.lab_units,
                    pre_requisite = x.pre_requisite,
                    time = x.time,
                    day = x.day,
                    room = x.room,
                    instructor = x.instructor,
                }).ToList();
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
