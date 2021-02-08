using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.Interface
{
    /// <summary>
    /// Interface DbContext
    /// </summary>
    /// <typeparam name="T">Kiểu truyền vào</typeparam>
    /// CreatedBy VTThien 08/02/21
    public interface IDbContext<T> where T: class
    {
        // Dùng cho các câu SelectAll
        IEnumerable<T> Query(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text);
        //Dùng cho SelectByID
        T QueryFirst(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text);
        //Dùng cho Insert, Update, Delete
        int Excute(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text);
    }
}
