using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.interfaces
{
    public interface IPositionRepository
    {
        /// <summary>
        /// Lấy danh sách các vị trí
        /// </summary>
        /// <returns>Danh sách các vị trí</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        IEnumerable<EmployeePosition> GetPositions();
    }
}
