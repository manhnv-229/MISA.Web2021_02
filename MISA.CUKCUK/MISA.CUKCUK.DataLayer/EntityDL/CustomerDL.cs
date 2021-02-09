using Dapper;
using MISA.Common.Model;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer.EntityDL
{
    /// <summary>
    /// entity customerdatalayer kế thừa từ ICustomerDL
    /// </summary>
    public class CustomerDL: BaseDL<Customer>, ICustomerDL
    {
        private readonly IDbContext<Customer> _dbContext;

        public CustomerDL(IDbContext<Customer> dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Thực thi kiểm tra mã khách hàng đã tồn tại trong db hay chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <returns>true: đã có/ false: chưa có</returns>
        /// CreatedBy Vtthien 08/02/21
        public bool CheckCustomerCodeExisted(string customerCode)
        {
            var sqlCheckCustomerCode = $"Select CustomerCode From Customer c Where c.CustomerCode = '{customerCode}'";
            var result = _dbContext.Query(sqlCheckCustomerCode).FirstOrDefault();
            return result != null;
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại trong database chưa
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại cần kiểm tra</param>
        /// <returns>true: đã có/ false: chưa có</returns>
        /// CreatedBy Vtthien 08/02/21
        public bool CheckPhoneNumberExisted(string phoneNumber)
        {
            var sqlCheckphoneNumber = $"Select PhoneNumber From Customer c Where c.PhoneNumber = '{phoneNumber}'";
            var result = _dbContext.Query(sqlCheckphoneNumber).FirstOrDefault();
            return result != null;
        }
    }
}
