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
    public class CustomerRepository : ICustomerRepository
    {
        #region DECLARE
        DbContext dbContext;
        #endregion

        #region CONSTRUCTOR
        public CustomerRepository()
        {
            dbContext = new DbContext();
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: BDHIEU (07/02/2021)
        public IEnumerable<Customers> GetCustomers()
        {
            var customers = dbContext.GetAll<Customers>();
            return customers;
        }

        
        #endregion
    }
}
