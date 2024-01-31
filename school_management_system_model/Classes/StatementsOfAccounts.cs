﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class StatementsOfAccounts
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string date { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public int reference_no { get; set; }
        public string particulars { get; set; }
        public decimal debit { get; set; }
        public decimal credit { get; set; }
        public decimal balance { get; set; }
        public string cashier_in_charge { get; set; }

        public List<StatementsOfAccounts> GetStatementsOfAccounts()
        {
            var list = new List<StatementsOfAccounts>();
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "select * from statemets_of_accounts";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id_number_id = new StudentAccount().GetStudentAccounts().FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));
                            var school_year_id = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.id == reader.GetInt32("school_year_id"));
                            var course_id = new Courses().GetCourses().FirstOrDefault(x => x.id == reader.GetInt32("course_id"));
                            if (id_number_id != null && school_year_id != null && course_id != null)
                            {
                                var soa = new StatementsOfAccounts
                                {
                                    id = reader.GetInt32("id"),
                                    id_number = id_number_id.id_number,
                                    school_year = school_year_id.code,
                                    date = reader.GetString("date"),
                                    course = course_id.code,
                                    year_level = reader.GetString("year_level"),
                                    semester = reader.GetString("semester"),
                                    reference_no = reader.GetInt32("reference_no"),
                                    particulars = reader.GetString("particulars"),
                                    debit = reader.GetDecimal("debit"),
                                    credit = reader.GetDecimal("credit"),
                                    balance = reader.GetDecimal("balance"),
                                    cashier_in_charge = reader.GetString("cashier_in_charge")
                                };
                                list.Add(soa);
                            }
                        }
                    }
                }
                con.Close();
                return list;
            }
        }

        public int referenceNumber()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from reference_number_setup order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["reference_number"]) + 1;
        }
        public void incrementReferenceNumber(int referenceNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update reference_number_setup set reference_number='" + referenceNumber + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void saveStatementOfAccount(string idNumber, string schoolYear)
        {
            reference_no = referenceNumber();
            incrementReferenceNumber(reference_no);
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into statements_of_accounts(id_number, date, reference_no, particulars, debit, credit, balance, cashier_in_charge, school_year, " +
                "course, year_level, semester) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)", con);
            cmd.Parameters.AddWithValue("@1", idNumber);
            cmd.Parameters.AddWithValue("@2", DateTime.Now.ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@3", reference_no);
            cmd.Parameters.AddWithValue("@4", particulars);
            cmd.Parameters.AddWithValue("@5", debit);
            cmd.Parameters.AddWithValue("@6", credit);
            cmd.Parameters.AddWithValue("@7", balance);
            cmd.Parameters.AddWithValue("@8", cashier_in_charge);
            cmd.Parameters.AddWithValue("@9", schoolYear);
            cmd.Parameters.AddWithValue("@10", course);
            cmd.Parameters.AddWithValue("@11", year_level);
            cmd.Parameters.AddWithValue("@12", semester);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable loadLatestSOA(string idNumber, string schoolYear)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from statements_of_accounts where id_number='" + idNumber + "' and school_year='" + schoolYear + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadStudentRecords(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable searchRecords(string idNumber, string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from statements_of_accounts where concat(date, reference_no, particulars) like '%" + search + "%' and id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadSchoolYear()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from school_year", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
