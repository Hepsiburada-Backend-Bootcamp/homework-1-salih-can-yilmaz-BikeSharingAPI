using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Users;
using BikeSharingAPI.Services.IServices;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Services
{
    public class SQLiteService : ISQLiteService
    {
        private readonly IConfiguration Configuration;

        public SQLiteService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public List<object> GetAll(string fromTable)
        {
            try
            {
                using (IDbConnection cnn = new SqliteConnection(GetConnectionString()))
                {
                    cnn.Open();
                    var output = cnn.Query<object>($"SELECT * FROM {fromTable}");
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        private string GetConnectionString()
        {
            var x = Configuration.GetConnectionString("SQLite");
            var c = Directory.GetCurrentDirectory();
            return x;
        }
    }
}
