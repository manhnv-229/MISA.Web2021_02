using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.DbContext2
{
    public class PositionRepositoryV2<Position> : DbContextV2<Position>,IPositionRepository<Position>
    {

    }
}
