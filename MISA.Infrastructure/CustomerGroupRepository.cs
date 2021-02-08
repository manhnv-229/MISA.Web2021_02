using Dapper;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces.Customer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerGroupRepository : ICustomerGroupRepository
    {
        #region DECLARE
        DbContext dbContext;
        #endregion

        #region CONSTRUCTOR
        public CustomerGroupRepository()
        {
            dbContext = new DbContext();
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy danh sách nhóm khách hàng
        /// </summary>
        /// <returns>Danh sách nhóm khách hàng</returns>
        /// CreatedBy: BDHIEU (07/02/2021)
        public IEnumerable<CustomerGroup> GetCustomerGroups()
        {
            var customerGroups = dbContext.GetAll<CustomerGroup>();
            return customerGroups;
        }

        /// <summary>
        /// Thêm mới nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">Dữ liệu thêm </param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: BDHIEU (08/02/2021)
        public int InsertCustomerGroup(CustomerGroup customerGroup)
        {
            var rowAffect = dbContext.InsertData<CustomerGroup>("Proc_InsertCustomerGroup", customerGroup, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }
        #endregion
    }
}
