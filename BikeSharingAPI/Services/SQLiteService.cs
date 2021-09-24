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
        private readonly ILogService LogService;

        public SQLiteService(IConfiguration configuration, ILogService logService)
        {
            this.Configuration = configuration;
            this.LogService = logService;
        }
        public List<T> GetAll<T>(string fromTable, string whereCondition = "")
        {
            try
            {
                using (IDbConnection cnn = new SqliteConnection(GetConnectionString()))
                {
                    cnn.Open();

                    string query = $"SELECT * FROM {fromTable} ";
                    
                    if(whereCondition != "")
                    {
                        query = query + $"WHERE {whereCondition} ";
                    }

                    var output = cnn.Query<T>(query);

                    LogService.Log(SharedData.LogMessageSelectSuccess);

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                LogService.Log(ex.Message);
                return null;
            }
            
        }

        public bool Write<T>(string tableName, T model, string whereCondition = "")
        {
            try
            {
                using (IDbConnection cnn = new SqliteConnection(GetConnectionString()))
                {
                    cnn.Open();

                    string query = $"INSERT INTO {tableName} (";

                    foreach(var property in model.GetType().GetProperties())
                    {
                        query = query + property.Name + ",";
                    }

                    query = query.TrimEnd(',');

                    query = query + ") VALUES (";

                    foreach(var property in model.GetType().GetProperties())
                    {
                        query = query + "@" + property.Name + ",";
                    }
                    
                    query = query.TrimEnd(',');

                    query = query + ")";

                    if(whereCondition != "")
                    {
                        query = query + $" WHERE {whereCondition}";
                    }

                    var output = cnn.Execute(query, model);

                    LogService.Log(SharedData.LogMessageInsertSuccess);

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogService.Log(ex.Message);
                return false;
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
