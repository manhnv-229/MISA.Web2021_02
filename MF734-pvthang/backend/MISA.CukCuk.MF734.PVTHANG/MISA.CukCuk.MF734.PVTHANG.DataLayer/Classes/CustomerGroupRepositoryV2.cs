using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.DataLayer.Classes
{
    public class CustomerGroupRepositoryV2 : CustomerGroupRepository
    {
        /// <summary>
        /// Trả về 1 danh sách trống
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="procName"></param>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns>danh sách trống</returns>
        public override IEnumerable<TEntity> GetList<TEntity>(string procName, object input, CommandType type = CommandType.StoredProcedure)
        {
            var res = new List<TEntity>();
            return res;
        }
    }
}
