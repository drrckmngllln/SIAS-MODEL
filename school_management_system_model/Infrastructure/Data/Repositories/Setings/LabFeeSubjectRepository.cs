using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class LabFeeSubjectRepository : IGenericRepository<LabFeeSubjects>
    {
        LabFeeRepository _labFeeRepo = new LabFeeRepository();
        public async Task AddRecords(LabFeeSubjects entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "insert into lab_fee_subjects(lab_fee_id, subject_code, descriptive_title, uid) " +
                    "values(@1,@2,@3,@4)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.lab_fee);
                    cmd.Parameters.AddWithValue("@2", entity.subject_code);
                    cmd.Parameters.AddWithValue("@3", entity.descriptive_title);
                    cmd.Parameters.AddWithValue("@4", entity.uid);
                    cmd.ExecuteNonQuery();
                }
                await con.CloseAsync();
            }
        }

        public async Task DeleteRecords(LabFeeSubjects entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var cmd = new MySqlCommand("delete from lab_fee_subjects where id='" + entity.id + "'", con);
                await cmd.ExecuteNonQueryAsync();
                await con.CloseAsync();
            }
        }

        public async Task<IReadOnlyList<LabFeeSubjects>> GetAllAsync()
        {
            var list = new List<LabFeeSubjects>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from lab_fee_subjects";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var lab_fee_id = await _labFeeRepo.GetByIdAsync(reader.GetInt32("lab_fee_id"));

                            if (lab_fee_id != null)
                            {
                                var labFeeSubjects = new LabFeeSubjects
                                {
                                    id = reader.GetInt32("id"),
                                    lab_fee = lab_fee_id.description,
                                    subject_code = reader.GetString("subject_code"),
                                    descriptive_title = reader.GetString("descriptive_title")
                                };
                                list.Add(labFeeSubjects);
                            }

                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public async Task<LabFeeSubjects> GetByIdAsync(int id)
        {
            var labFeeSubject = new LabFeeSubjects();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from lab_fee_subjects where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var lab_fee_id = await _labFeeRepo.GetByIdAsync(reader.GetInt32("lab_fee_id"));

                            labFeeSubject = new LabFeeSubjects
                            {
                                id = reader.GetInt32("id"),
                                lab_fee = lab_fee_id.description,
                                subject_code = reader.GetString("subject_code"),
                                descriptive_title = reader.GetString("descriptive_title")
                            };
                        }
                        await con.CloseAsync();
                        return labFeeSubject;
                    }
                }
            }
        }

        public Task UpdateRecords(LabFeeSubjects entity)
        {
            throw new NotImplementedException();
        }
    }
}
