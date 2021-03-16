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
    [Route("api/v1/positions")]
    [ApiController]
    public class PositionsController : BasesController<Position>
    {
        #region CONTRUCTOR
        public PositionsController(IPositionService positionService):base(positionService)
        {
            
        }
        #endregion
    }
}
