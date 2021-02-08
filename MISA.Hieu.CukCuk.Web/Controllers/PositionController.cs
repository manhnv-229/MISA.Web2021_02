using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Hieu.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        IPositionService _positionService;
        #region Constructor
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách vị trí công việc
        /// </summary>
        /// <returns>Danh sách vị trí công việc</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _positionService.GetPositions();
            if (serviceResult.Data != null)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }
        #endregion
    }
}
