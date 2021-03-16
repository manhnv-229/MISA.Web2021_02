using Common;
using MISA.Common;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class OfficeService:BaseService<Office>,IOfficeService
    {
        #region CONTRUCTOR
        public OfficeService(IOfficeRepository<Office> officeRepository):base(officeRepository)
        {
            
        }
        #endregion
    }
}
