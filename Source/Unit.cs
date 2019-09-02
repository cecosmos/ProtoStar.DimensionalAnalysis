using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.DimensionalAnalysis
{
    public class Unit : IUnit
    {
        public Unit(
            IDimension dimension,
            double factor = 1.0,
            double displacement = 0.0,
            string symbol = "")
        {
            Dimension = dimension;
            Factor = factor;
            Displacement = displacement;
            Symbol = symbol;
        }

        public IDimension Dimension { get; }

        public double Factor { get; }

        public double Displacement { get; }

        public string Symbol { get; }
    }
}
