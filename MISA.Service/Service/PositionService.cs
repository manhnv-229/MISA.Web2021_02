using MISA.Common.Models;
using MISA.DataLayer;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Service
{

    public class PositionService : BaseService<Position>, IPositionService
    {
        public PositionService(IDbContext<Position> _dbContext) : base(_dbContext)
        {

        }
        #region Method
        #endregion
    }

}
