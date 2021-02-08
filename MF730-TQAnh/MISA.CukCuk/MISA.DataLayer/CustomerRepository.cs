using Dapper;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer
{
    /// <summary>
    /// kho lưu trữ cho khách hàng
    /// </summary>
    /// CreatedBy: TQAnh ( 08/02/2021)
    public class CustomerRepository : MariaDbContextV2<Customer>,ICustomerRepository
    {


   


    }
}
