using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Model;
using MISA.Service;
using MISA.Service.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// controller cho khách hàng
    /// </summary>
    ///   CreatedBy: TQAnh (08/02/2021)
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer>
    {


        public CustomersController(ICustomerService _customerService) : base(_customerService)
        {
        }
    }

}
