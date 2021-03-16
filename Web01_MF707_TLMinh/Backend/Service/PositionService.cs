using Common;
using MISA.Common;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class PositionService:BaseService<Position>,IPositionService
    {
        #region CONTRUCTOR
        public PositionService(IPositionRepository<Position> positionRepository):base(positionRepository)
        {
            
        }
        #endregion
    }
}
