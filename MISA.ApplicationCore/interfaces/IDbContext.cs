using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IDbContext
    {
        IEnumerable<T> GetAll<T>(CommandType commandType = CommandType.Text);
        IEnumerable<T> GetData<T>(string sqlCommand, object parameters = null, CommandType commandType = CommandType.Text);
        int InsertData<T>(string sqlCommand, T entity, CommandType commandType = CommandType.Text);
        int DeleteData(string sqlCommand, object parameters = null, CommandType commandType = CommandType.Text);
    }
}
