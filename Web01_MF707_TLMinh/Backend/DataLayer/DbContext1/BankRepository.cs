using Dapper;
using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.DbContext1
{
    public class BankRepository<Bank>:DbContext<Bank>,IBankRepository<Bank>
    {
        /// <summary>
        /// Xóa 1 bản ghi(way:1- xóa theo Id của tài khoản ngân hàng; way:2- xóa theo Id của chủ tài khoản)
        /// </summary>
        /// <param name="entityId">Id của thực thể cần xóa</param>
        /// <param name="way">Id của chủ tài khoản ngân hàng</param>
        /// <returns>Số bản ghi bị xóa</returns>
        /// CreatedBy: TLMinh(21/02/2021)
        public override int Delete(string entityId,int way = 1)
        {
            string executeString;
            if (way == 1)
            {
                 executeString = $"DELETE FROM Bank WHERE BankId = '{entityId}'";
                return _dbConnection.Execute(executeString);
            }

            executeString = $"DELETE FROM Bank WHERE UserId = '{entityId}'";
            return _dbConnection.Execute(executeString);
        }
    }
}
