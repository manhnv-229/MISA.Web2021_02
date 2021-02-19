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
