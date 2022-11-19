using Dapper;
using Microsoft.Extensions.Configuration;
using Entry.Domain.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Entity.Data.Abstracts;
using System;

namespace Entry.Data.Concretes
{
    public class EntryRepository : IEntryRepository
    {
        private readonly IConfiguration _configuration;
        public EntryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(EntryEntity entity)
        {
            var sql = "Insert into Entry (Id,Name,SurName,Entry) VALUES (@Id,@Name,@SurName,@Entry)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<int> Delete(string name)
        {
            var sql = "DELETE FROM Entry WHERE Name = @Name";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Name = name });
                return result;
            }

        }
        public async Task<List<EntryEntity>> GetAllAsync()
        {
            var sql = "SELECT * FROM Entry";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<EntryEntity>(sql);
                return result.ToList();
            }
        }
        public async Task<EntryEntity> GetAsync(string name)
        {
            var sql = "SELECT * FROM Entry WHERE Name = @Name";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<EntryEntity>(sql, new { Name = name });
                return result;
            }
        }
        public async Task<int> Update(EntryEntity entity)
        {
            var sql = "UPDATE Entry SET Entry = @Entry  WHERE Name = @Name";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}