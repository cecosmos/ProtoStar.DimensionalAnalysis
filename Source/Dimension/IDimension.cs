using System;
using System.Collections.Generic;

namespace ProtoStar.DimensionalAnalysis
{
    public interface IDimension :
        IEquatable<IDimension>
    {
        IReadOnlyDictionary<BaseDimension, double> Value { get; }
        string Name { get; }
    }
}
