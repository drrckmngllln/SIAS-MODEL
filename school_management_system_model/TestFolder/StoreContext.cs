using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.TestFolder
{
    internal class StoreContext
    {
        

        public async Task<IReadOnlyList<SectionSubjectss>> SectionSubjects()
        {
            var list = new List<SectionSubjectss>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from section_subjects";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //var section_code_id = new sections().GetSections().FirstOrDefault(x => x.id == reader.GetInt32("section_code_id"));
                            var test = new SectionSubjectss
                            {
                                id = reader.GetInt32("id"),
                                unique_id = reader.GetString("unique_id"),
                                section_code = reader.GetString("section_code_id"), //section_code_id.section_code,
                                curriculum = reader.GetString("curriculum_id"),
                                course = reader.GetString("course_id"),
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
                                instructor = reader.GetString("instructor_id"),
                                status = reader.GetString("status"),
                            };
                            list.Add(test);
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }
    }
}
