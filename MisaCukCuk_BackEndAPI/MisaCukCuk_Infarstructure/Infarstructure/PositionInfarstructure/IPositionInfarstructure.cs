using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure.Infarstructure.PositionInfarstructure
{
    public interface IPositionInfarstructure : IMisaCukCukContext<Position>
    {
        Task<IEnumerable<Position>> getAllDataOfPosition();
    }
}
