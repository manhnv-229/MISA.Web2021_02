using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Controllers
{
    
    public class RulesController : BaseController<Rule>
    {
        #region constructor 
        /// <summary>
        /// Hàm khở tạo
        /// </summary>
        /// <param name="baseService">Truyền tham số cho hàm cha để hàm cha khởi tạo</param>
        public RulesController(IBaseService<Rule> baseService) : base(baseService)
        {

        }
        #endregion
    }
}
