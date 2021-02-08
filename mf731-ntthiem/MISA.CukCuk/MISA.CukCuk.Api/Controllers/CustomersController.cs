using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;
using MISA.Common.Models;
using MISA.Service.Interfaces;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customers")]
    public class CustomersController : BaseController<Customer>
    {
        /// <summary>
        /// Khởi tạo biến kết nối với CustomerService và truyền thông tin lên base
        /// </summary>
        /// <param name="customerService">mBiến để truyền lên base </param>
        /// CreatedBy: NTTHIEM
        /// CreatedDate: 08/02/2021
        public CustomersController(ICustomerService _customerService) :base(_customerService)
        {

        }
    }
}
