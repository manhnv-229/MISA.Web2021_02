using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO
{
    public class PositionDAO : DbConnector<Position>, IPositionDAO
    {
        public IEnumerable<Position> getAllData()
        {
            var db = new DbConnector<Position>();
            return db.GetAllData();
        }

        public Position GetPositionByID(string id)
        {
            var db = new DbConnector<Position>();
            return db.getByID<Position>(id);
        }
    }
}
