using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.DimensionalAnalysis
{
    public interface IUnit : IDimensionDependent
    {
        double Factor { get; }
        double Displacement { get; }
        string Symbol { get; }
    }
}
