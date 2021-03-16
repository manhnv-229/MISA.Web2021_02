using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common;
using MISA.Service;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk.Controllers
{
    [Route("api/v1/offices")]
    [ApiController]
    public class OfficesController : BasesController<Office>
    {
        #region CONTRUCTOR
        public OfficesController(IOfficeService officeService):base(officeService)
        { 
            
        }
        #endregion
    }
}
