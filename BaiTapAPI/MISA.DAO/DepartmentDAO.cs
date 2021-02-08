using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO
{
    public class DepartmentDAO : DbConnector<Department>, IDepartmentDAO
    {
        public IEnumerable<Department> getALLData()
        {
            var db = new DbConnector<Department>();
            return db.GetAllData();
        }

        public Department getByID(string id)
        {
            var db = new DbConnector<Department>();
            return db.getByID<Department>(id);
        }
    }
}
