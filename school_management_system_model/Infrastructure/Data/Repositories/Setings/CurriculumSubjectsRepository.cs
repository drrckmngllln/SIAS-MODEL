using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class CurriculumSubjectsRepository : IGenericRepository<CurriculumSubjects>
    {
        CurriculumRepository _curriculumRepo = new CurriculumRepository();

        public async Task AddRecords(CurriculumSubjects entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into curriculum_subjects(uid, curriculum_id, year_level, semester, code, descriptive_title, total_units, lecture_units, lab_units, " +
                "pre_requisite, total_hrs_per_week) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)", con);
            cmd.Parameters.AddWithValue("@1", entity.uid);
            cmd.Parameters.AddWithValue("@2", entity.curriculum);
            cmd.Parameters.AddWithValue("@3", entity.year_level);
            cmd.Parameters.AddWithValue("@4", entity.semester);
            cmd.Parameters.AddWithValue("@5", entity.code);
            cmd.Parameters.AddWithValue("@6", entity.descriptive_title);
            cmd.Parameters.AddWithValue("@7", entity.total_units);
            cmd.Parameters.AddWithValue("@8", entity.lecture_units);
            cmd.Parameters.AddWithValue("@9", entity.lab_units);
            cmd.Parameters.AddWithValue("@10", entity.pre_requisite);
            cmd.Parameters.AddWithValue("@11", entity.total_hrs_per_week);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeleteRecords(CurriculumSubjects entity)
        {
            var con = new MySqlConnection(connection.con());

            await con.OpenAsync();
            var cmd = new MySqlCommand("delete from curriculum_subjects where curriculum_id='" + entity.curriculum + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<CurriculumSubjects>> GetAllAsync()
        {
            var con = new MySqlConnection(connection.con());

            var list = new List<CurriculumSubjects>();
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from curriculum_subjects", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var curriculumSubject = new CurriculumSubjects
                {
                    id = reader.GetInt32("id"),
                    uid = reader.GetString("uid"),
                    curriculum = reader.GetString("curriculum_id"),
                    year_level = reader.GetString("year_level"),
                    semester = reader.GetString("semester"),
                    code = reader.GetString("code"),
                    descriptive_title = reader.GetString("descriptive_title"),
                    total_units = reader.GetString("total_units"),
                    lecture_units = reader.GetString("lecture_units"),
                    lab_units = reader.GetString("lab_units"),
                    pre_requisite = reader.GetString("pre_requisite"),
                    total_hrs_per_week = reader.GetString("total_hrs_per_week")
                };
                list.Add(curriculumSubject);
            }
            await con.CloseAsync();
            return list;
        }

        public async Task<CurriculumSubjects> GetByIdAsync(int id)
        {
            var curriculumSubjects = new CurriculumSubjects();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from curriculum_subejcts where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var curriculums = await _curriculumRepo.GetByIdAsync(reader.GetInt32("curriculum_id"));
                            curriculumSubjects = new CurriculumSubjects
                            {
                                id = reader.GetInt32("id"),
                                uid = reader.GetString("uid"),
                                curriculum = curriculums.code,
                                year_level = reader.GetString("year_level"),
                                semester = reader.GetString("semester"),
                                code = reader.GetString("code"),
                                descriptive_title = reader.GetString("descriptive_title"),
                                total_units = reader.GetString("total_units"),
                                lecture_units = reader.GetString("lecture_units"),
                                lab_units = reader.GetString("lab_units"),
                                pre_requisite = reader.GetString("pre_requisite"),
                                total_hrs_per_week = reader.GetString("total_hrs_per_week")
                            };
                        }
                    }
                }
                await con.CloseAsync();
                return curriculumSubjects;
            }
        }

        public async Task UpdateRecords(CurriculumSubjects entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update curriculum_subjects set uid=@1, year_level=@3, semester=@4, code=@5, descriptive_title=@6, " +
                "total_units=@7, lecture_units=@8, lab_units=@9, pre_requisite=@10, total_hrs_per_week=@11 where id='" + entity.id + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.uid);
            cmd.Parameters.AddWithValue("@2", entity.curriculum);
            cmd.Parameters.AddWithValue("@3", entity.year_level);
            cmd.Parameters.AddWithValue("@4", entity.semester);
            cmd.Parameters.AddWithValue("@5", entity.code);
            cmd.Parameters.AddWithValue("@6", entity.descriptive_title);
            cmd.Parameters.AddWithValue("@7", entity.total_units);
            cmd.Parameters.AddWithValue("@8", entity.lecture_units);
            cmd.Parameters.AddWithValue("@9", entity.lab_units);
            cmd.Parameters.AddWithValue("@10", entity.pre_requisite);
            cmd.Parameters.AddWithValue("@11", entity.total_hrs_per_week);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}
