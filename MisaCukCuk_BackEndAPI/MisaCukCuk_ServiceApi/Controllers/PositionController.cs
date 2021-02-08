using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisaCukCuk_ApplicationCore.ApplicationCore.PositionApplicationCore;
using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk_ServiceApi.Controllers
{
    public class PositionController : BaseController<Position>
    {
        IPositionApplicationCore _code;
        public PositionController(IPositionApplicationCore positionApplicationCore) : base(positionApplicationCore)
        {
            _code = positionApplicationCore;
        }
    }
}
