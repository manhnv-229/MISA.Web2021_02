using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    public interface IDbContext<MISAEntity>
    {
        IEnumerable<MISAEntity> GetAll();

        int InsertObject(MISAEntity entity);
    }
}
       
