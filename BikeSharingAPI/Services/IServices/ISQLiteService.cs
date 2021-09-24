using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Services.IServices
{
    public interface ISQLiteService
    {
        List<T> GetAll<T>(string fromTable, string whereCondition = "");
        bool Write<T>(string tableName, T model, string whereCondition = "");
    }
}
