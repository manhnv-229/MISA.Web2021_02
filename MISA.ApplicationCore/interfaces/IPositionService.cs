using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IPositionService
    {
        /// <summary>
        /// Lấy danh sách các vị trí
        /// </summary>
        /// <returns>Danh sách các vị trí</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        ServiceResult GetPositions();
    }
}
