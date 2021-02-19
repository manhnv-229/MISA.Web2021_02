using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk.Controllers
{
    [Route("api/v1/banks")]
    [ApiController]
    public class BanksController : BasesController<Bank>
    {
        public BanksController(IBankService bankService) : base(bankService)
        {

        }
    }
}
