using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Model;
using MISA.Service;
using MISA.Service.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Controller Customer được kế thừa từ basecontroller để quản lý các phương thức gọi API customer
    /// </summary>
    public class CustomersController : BasesController<Customer>
    {
        public CustomersController(ICustomerService _customerService) : base(_customerService)
        {

        }
    }
}
