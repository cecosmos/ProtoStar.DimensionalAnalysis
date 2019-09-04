using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.DimensionalAnalysis
{
    public class Unit<T> : IUnit
        where T: IDimension, new()
    {
        public Unit(double factor, double displacement, string symbol)
        {
            Factor = factor;
            Displacement = displacement;
            Symbol = symbol;
        }

        public double Factor { get; }

        public double Displacement { get; }

        public string Symbol { get; }

        public IDimension Dimension { get; }
    }
}
