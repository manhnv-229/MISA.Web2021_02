using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class PositionService : IPositionService
    {
        IPositionRepository _positionRepository;
        #region Constructor
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách vị trí 
        /// </summary>
        /// <returns>Danh sách vị trí </returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public ServiceResult GetPositions()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _positionRepository.GetPositions();
            return serviceResult;
        }
        #endregion

    }
}
