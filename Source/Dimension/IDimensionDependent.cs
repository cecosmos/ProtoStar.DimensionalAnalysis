using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.DimensionalAnalysis
{
    public interface IDimensionDependent
    {
        IDimension Dimension { get; }
    }
}
