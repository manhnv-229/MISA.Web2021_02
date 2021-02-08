using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class JobPositionService:BaseService<JobPosition>
    {
        public JobPositionService(IBaseData<JobPosition> DbContext) : base(DbContext)
        {

        }
    }
}
