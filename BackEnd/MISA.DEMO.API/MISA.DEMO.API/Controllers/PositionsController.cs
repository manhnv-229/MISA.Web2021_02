using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.DEMO.API.Models;
using MISA.Service;
using MISA.Service.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.DEMO.API.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class PositionsController : BaseController<Position>
    {
        public PositionsController(IBaseService<Position> positionService) : base(positionService)
        {

        }
    }
}
