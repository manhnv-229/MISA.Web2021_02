using MISA.Common.Models;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer
{
    public class PositionContext: DbContext<Position>, IPositionContext
    {
    }
}
