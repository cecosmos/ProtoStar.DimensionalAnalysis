using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.DimensionalAnalysis
{
    public static class ValueConversions
    {
        public static double ConvertToSI(double value, IUnit unit)
        {
            return value * unit.Factor + unit.Displacement;
        }

        public static double ConvertFromSI(double value, IUnit unit)
        {
            return (value - unit.Displacement) / unit.Factor;
        }
    }
}
