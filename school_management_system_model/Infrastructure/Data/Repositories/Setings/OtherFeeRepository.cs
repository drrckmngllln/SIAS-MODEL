﻿using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace school_management_system_model.Data.Repositories.Setings
{
    internal class OtherFeeRepository : IGenericRepository<OtherFee>
    {
        LevelsRepository _levelRepo = new LevelsRepository();
        CampusRepository _campusRepo = new CampusRepository();

        public async Task AddRecords(OtherFee entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "insert into other_fees(uid, category, description, campus_id, level_id, year_level, semester, amount) " +
                    "values(@1,@2,@3,@4,@5,@6,@7,@8)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.uid);
                    cmd.Parameters.AddWithValue("@2", entity.category);
                    cmd.Parameters.AddWithValue("@3", entity.description);
                    cmd.Parameters.AddWithValue("@4", entity.campus);
                    cmd.Parameters.AddWithValue("@5", entity.level);
                    cmd.Parameters.AddWithValue("@6", entity.year_level);
                    cmd.Parameters.AddWithValue("@7", entity.semester);
                    cmd.Parameters.AddWithValue("@8", entity.amount);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public async Task DeleteRecords(OtherFee entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("delete from other_fees where id='" + entity.id + "'", con);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<OtherFee>> GetAllAsync()
        {
            var list = new List<OtherFee>();
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from other_fees", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var a = await _campusRepo.GetAllAsync();
                var campus_id = a.FirstOrDefault(x => x.id == reader.GetInt32("campus_id"));

                var b = await _levelRepo.GetAllAsync();
                var level_id = b.FirstOrDefault(x => x.id == reader.GetInt32("level_id"));
                var misc = new OtherFee
                {
                    id = reader.GetInt32("id"),
                    uid = reader.GetString("uid"),
                    category = reader.GetString("category"),
                    description = reader.GetString("description"),
                    campus = campus_id.code,
                    level = level_id.code,
                    year_level = reader.GetString("year_level"),
                    semester = reader.GetString("semester"),
                    amount = reader.GetDecimal("amount")
                };
                list.Add(misc);
            }
            await con.CloseAsync();
            return list;
        }

        public async Task UpdateRecords(OtherFee entity)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "update other_fees set uid=@1, category=@2, description=@3, campus_id=@4, level_id=@5, year_level=@6, semester=@7, amount=@8 " +
                    "where id='" + entity.id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", entity.uid);
                    cmd.Parameters.AddWithValue("@2", entity.category);
                    cmd.Parameters.AddWithValue("@3", entity.description);
                    cmd.Parameters.AddWithValue("@4", entity.campus);
                    cmd.Parameters.AddWithValue("@5", entity.level);
                    cmd.Parameters.AddWithValue("@6", entity.year_level);
                    cmd.Parameters.AddWithValue("@7", entity.semester);
                    cmd.Parameters.AddWithValue("@8", entity.amount);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }
    }
}