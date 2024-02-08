﻿using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Forms.transactions.StudentAssessment
{
    internal class StudentAssessments
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string fee_type { get; set; }
        public decimal amount { get; set; }
        public decimal units { get; set; }
        public decimal computation { get; set; }

        public async Task<List<StudentAssessments>> GetStudentAssessments()
        {
            var _studentAccountRepo = new StudentAccountRepository();
            var _schoolYearRepo = new SchoolYearRepository();
            var list = new List<StudentAssessments>();
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from student_assessment", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var a = await _studentAccountRepo.GetAllAsync();
                var id_number_id = a.FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));

                var b = await _schoolYearRepo.GetAllAsync(); 
                var school_year_id = b.FirstOrDefault(x => x.id == reader.GetInt32("school_year_id"));
                var student = new StudentAssessments
                {
                    id = reader.GetInt32("id"),
                    id_number = id_number_id.id.ToString(),
                    school_year = school_year_id.code,
                    fee_type = reader["fee_type"].ToString(),
                    amount = reader.GetDecimal("amount"),
                    units = reader.GetDecimal("units"),
                    computation = reader.GetDecimal("computation")
                };
                list.Add(student);
            }
            await con.CloseAsync();
            return list;
        }

        public void SaveStudentAssessment()
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "insert into student_assessment(id_number_id, school_year_id, fee_type, amount, units, computation) " +
                    "values(@1,@2,@3,@4,@5,@6)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", id_number);
                    cmd.Parameters.AddWithValue("@2", school_year);
                    cmd.Parameters.AddWithValue("@3", fee_type);
                    cmd.Parameters.AddWithValue("@4", amount);
                    cmd.Parameters.AddWithValue("@5", units);
                    cmd.Parameters.AddWithValue("@6", computation);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}