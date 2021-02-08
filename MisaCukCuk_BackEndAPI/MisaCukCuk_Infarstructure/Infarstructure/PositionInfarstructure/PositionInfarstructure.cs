using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure.Infarstructure.PositionInfarstructure
{
    public class PositionInfarstructure : MisaCukCukContext<Position>, IPositionInfarstructure
    {
        MisaCukCukContext<Position> _db = new MisaCukCukContext<Position>();
        public async Task<IEnumerable<Position>> getAllDataOfPosition()
        {
            return await _db.GetAllData();
        }
    }
}
