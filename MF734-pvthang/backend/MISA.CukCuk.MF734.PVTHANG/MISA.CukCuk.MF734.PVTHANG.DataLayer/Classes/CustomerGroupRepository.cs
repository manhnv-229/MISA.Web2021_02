using MISA.CukCuk.MF734.PVTHANG.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.DataLayer.Classes
{
    public class CustomerGroupRepository : DatabaseConnector, ICustomerGroupRepository
    {
        /// <summary>
        /// trả về 0
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns>0</returns>
        public override int Change(string procName, object input, CommandType type = CommandType.StoredProcedure)
        {
            return 0;
        }
    }
}
