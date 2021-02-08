using MisaCukCuk_ApplicationCore.BaseApplicationCore;
using MisaCukCuk_Entity.Models;
using MisaCukCuk_Infarstructure.Infarstructure.PositionInfarstructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_ApplicationCore.ApplicationCore.PositionApplicationCore
{
    public class PositionApplicationCore : BaseApplicationCore<Position>, IPositionApplicationCore
    {
        IPositionInfarstructure _positionInfarstructure;
        public PositionApplicationCore(IPositionInfarstructure positionInfarstructure) : base(positionInfarstructure)
        {
            _positionInfarstructure = positionInfarstructure;
        }
    }
}
