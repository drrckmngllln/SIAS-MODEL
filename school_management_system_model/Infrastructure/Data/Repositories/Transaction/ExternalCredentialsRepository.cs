using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class ExternalCredentialsRepository : IGenericRepository<ExternalCredential>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();


        #region Fetching Side

        public async Task<IReadOnlyList<ExternalCredential>> GetAllAsync()
        {
            var list = new List<ExternalCredential>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from external_credentials";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id"));
                            var externalCred = new ExternalCredential
                            {
                                id = reader.GetInt32("id"),
                                id_number = student.id_number,
                                school_year = reader.GetString("school_year"),
                                subject_code = reader.GetString("subject_code"),
                                descriptive_title = reader.GetString("descriptive_title"),
                                pre_requisite = reader.GetString("pre_requisite"),
                                total_units = reader.GetDecimal("total_units"),
                                lecture_units = reader.GetDecimal("lecture_units"),
                                lab_units = reader.GetDecimal("lab_units"),
                                grade = reader.GetDecimal("grade"),
                                remarks = reader.GetString("remarks")
                            };
                            list.Add(externalCred);
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }


        public async Task<ExternalCredential> GetByIdAsync(int id)
        {
            var externalCred = new ExternalCredential();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from external_credentials where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id"));
                            externalCred = new ExternalCredential
                            {
                                id = reader.GetInt32("id"),
                                id_number = student.id_number,
                                school_year = reader.GetString("school_year"),
                                subject_code = reader.GetString("subject_code"),
                                descriptive_title = reader.GetString("descriptive_title"),
                                pre_requisite = reader.GetString("pre_requisite"),
                                total_units = reader.GetDecimal("total_units"),
                                lecture_units = reader.GetDecimal("lecture_units"),
                                lab_units = reader.GetDecimal("lab_units"),
                                grade = reader.GetDecimal("grade"),
                                remarks = reader.GetString("remarks")
                            };
                        }
                    }
                    await con.CloseAsync();
                    return externalCred;
                }
            }
        }


        public async Task<IReadOnlyList<ExternalCredential>> GetByIdNumberAsync(int id_number)
        {
            var list = new List<ExternalCredential>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from external_credentials where id_number_id='" + id_number + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var student = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id"));
                                var externalCred = new ExternalCredential
                                {
                                    id = reader.GetInt32("id"),
                                    id_number = student.id_number,
                                    school_year = reader.GetString("school_year"),
                                    subject_code = reader.GetString("subject_code"),
                                    descriptive_title = reader.GetString("descriptive_title"),
                                    pre_requisite = reader.GetString("pre_requisite"),
                                    total_units = reader.GetDecimal("total_units"),
                                    lecture_units = reader.GetDecimal("lecture_units"),
                                    lab_units = reader.GetDecimal("lab_units"),
                                    grade = reader.GetDecimal("grade"),
                                    remarks = reader.GetString("remarks")
                                };
                                list.Add(externalCred);
                            }
                        }

                    }
                }
                await con.CloseAsync();
                return list;
            }

        }


        #endregion



        #region Add Edit Delete


        public async Task AddRecords(ExternalCredential entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "insert into external_credentials(id_number_id, unique_id, school_year, subject_code, descriptive_title, pre_requisite, total_units, " +
                    "lecture_units, lab_units, grade, remarks) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.id_number);
                    cmd.Parameters.AddWithValue("@1", entity.unique_id);
                    cmd.Parameters.AddWithValue("@1", entity.school_year);
                    cmd.Parameters.AddWithValue("@1", entity.subject_code);
                    cmd.Parameters.AddWithValue("@1", entity.descriptive_title);
                    cmd.Parameters.AddWithValue("@1", entity.pre_requisite);
                    cmd.Parameters.AddWithValue("@1", entity.total_units);
                    cmd.Parameters.AddWithValue("@1", entity.lecture_units);
                    cmd.Parameters.AddWithValue("@1", entity.lab_units);
                    cmd.Parameters.AddWithValue("@1", entity.grade);
                    cmd.Parameters.AddWithValue("@1", entity.remarks);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public Task DeleteRecords(ExternalCredential entity)
        {
            throw new System.NotImplementedException();
        }


        public Task UpdateRecords(ExternalCredential entity)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
