﻿using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Data.Interfaces;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Infrastructure.Data.Repositories.Transaction
{
    internal class FeeBreakdownRepository : IGenericRepository<FeeBreakdown>
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        public async Task AddRecords(FeeBreakdown entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("insert into fee_breakdown(id_number_id, school_year_id,prelim, midterm, semi_finals, finals, total, prelim_original, midterm_original, semi_finals_original,finals_original, " +
                "total_original, downpayment, downpayment_original) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14)", con);
            cmd.Parameters.AddWithValue("@1", entity.id_number);
            cmd.Parameters.AddWithValue("@2", entity.school_year);
            cmd.Parameters.AddWithValue("@3", entity.prelim);
            cmd.Parameters.AddWithValue("@4", entity.midterm);
            cmd.Parameters.AddWithValue("@5", entity.semi_finals);
            cmd.Parameters.AddWithValue("@6", entity.finals);
            cmd.Parameters.AddWithValue("@7", entity.total);
            cmd.Parameters.AddWithValue("@8", entity.prelim);
            cmd.Parameters.AddWithValue("@9", entity.midterm);
            cmd.Parameters.AddWithValue("@10", entity.semi_finals);
            cmd.Parameters.AddWithValue("@11", entity.finals);
            cmd.Parameters.AddWithValue("@12", entity.total);
            cmd.Parameters.AddWithValue("@13", entity.downpayment);
            cmd.Parameters.AddWithValue("@14", entity.downpayment);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public Task DeleteRecords(FeeBreakdown entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<FeeBreakdown>> GetAllAsync()
        {
            var list = new List<FeeBreakdown>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from fee_breakdown";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var studentAccounts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var schoolYears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));


                            var feeBreakdown = new FeeBreakdown
                            {
                                id = reader.GetInt32("id"),
                                id_number = studentAccounts.id_number,
                                school_year = schoolYears.code,
                                downpayment = reader.GetDecimal("downpayment"),
                                prelim = reader.GetDecimal("prelim"),
                                midterm = reader.GetDecimal("midterm"),
                                semi_finals = reader.GetDecimal("semi_finals"),
                                finals = reader.GetDecimal("finals"),
                                downpayment_original = reader.GetDecimal("downpayment_original"),
                                prelim_original = reader.GetDecimal("prelim_original"),
                                midterm_original = reader.GetDecimal("midterm_original"),
                                semi_finals_original = reader.GetDecimal("semi_finals_original"),
                                finals_original = reader.GetDecimal("finals_original"),
                                total_original = reader.GetDecimal("total_original")
                            };
                            list.Add(feeBreakdown);
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public async Task<FeeBreakdown> GetByIdAsync(int id)
        {
            var feeBreakdown = new FeeBreakdown();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from fee_breakdown where id='"+ id +"'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var studentAccounts = await _studentAccountRepo.GetByIdAsync(reader.GetInt32("id_number_id"));
                            var schoolYears = await _schoolYearRepo.GetByIdAsync(reader.GetInt32("school_year_id"));


                            feeBreakdown = new FeeBreakdown
                            {
                                id = reader.GetInt32("id"),
                                id_number = studentAccounts.id_number,
                                school_year = schoolYears.code,
                                downpayment = reader.GetDecimal("downpayment"),
                                prelim = reader.GetDecimal("prelim"),
                                midterm = reader.GetDecimal("midterm"),
                                semi_finals = reader.GetDecimal("semi_finals"),
                                finals = reader.GetDecimal("finals"),
                                downpayment_original = reader.GetDecimal("downpayment_original"),
                                prelim_original = reader.GetDecimal("prelim_original"),
                                midterm_original = reader.GetDecimal("midterm_original"),
                                semi_finals_original = reader.GetDecimal("semi_finals_original"),
                                finals_original = reader.GetDecimal("finals_original"),
                                total_original = reader.GetDecimal("total_original")
                            };
                        }
                        await con.CloseAsync();
                        return feeBreakdown;
                    }
                }
            }
        }

        public async Task UpdateRecords(FeeBreakdown entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update fee_breakdown set downpayment=@1, prelim=@2, midterm=@3, semi_finals=@4, finals=@5 " +
                "where id_number_id='" + entity.id_number + "' and school_year_id='" + entity.school_year + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.downpayment);
            cmd.Parameters.AddWithValue("@2", entity.prelim);
            cmd.Parameters.AddWithValue("@3", entity.midterm);
            cmd.Parameters.AddWithValue("@4", entity.semi_finals);
            cmd.Parameters.AddWithValue("@5", entity.finals);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IReadOnlyList<FeeBreakdown>> UpdateRecordsAsync(FeeBreakdown entity)
        {
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("update fee_breakdown set downpayment=@1, prelim=@2, midterm=@3, semi_finals=@4, finals=@5 " +
                "where id_number_id='" + entity.id_number + "' and school_year_id='" + entity.school_year + "'", con);
            cmd.Parameters.AddWithValue("@1", entity.downpayment);
            cmd.Parameters.AddWithValue("@2", entity.prelim);
            cmd.Parameters.AddWithValue("@3", entity.midterm);
            cmd.Parameters.AddWithValue("@4", entity.semi_finals);
            cmd.Parameters.AddWithValue("@5", entity.finals);
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return await GetAllAsync();
        }
    }
}
