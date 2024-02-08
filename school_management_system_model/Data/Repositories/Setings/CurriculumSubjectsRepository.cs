using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class CurriculumSubjectsRepository : IGenericRepository<CurriculumSubjects>
    {
        MySqlConnection con = new MySqlConnection(connection.con());
        public Task AddRecords(CurriculumSubjects entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRecords(CurriculumSubjects entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<CurriculumSubjects>> GetAllAsync()
        {
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
                    curriculum_id = reader.GetString("curriculum_id"),
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

        public Task UpdateRecords(CurriculumSubjects entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
