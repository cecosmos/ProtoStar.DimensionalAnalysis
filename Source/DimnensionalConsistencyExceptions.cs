using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.DimensionalAnalysis
{
    public class DimnensionalConsistencyExceptions : ArithmeticException
    {
        public IDimension Expected { get; set; }
        public IDimension Actual { get; set; }
    }
}
