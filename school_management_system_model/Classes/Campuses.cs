﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class Campuses
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string status { get; set; }

        public List<Campuses> GetCampuses()
        {
            var list = new List<Campuses>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from campuses", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var campus = new Campuses
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    address = reader.GetString("address"),
                    status = reader.GetString("status")
                };
                list.Add(campus);
            }
            con.Close();
            return list;
        }
    }
}
