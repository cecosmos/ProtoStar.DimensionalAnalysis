using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.DimensionalAnalysis
{
    public interface IQuantity : 
        IDimensionDependent, IComparable, IComparable<IQuantity>, IEquatable<IQuantity>
    {
        double SIValue { get; set; }
        double this[IUnit unit] { get; set; }
    }
}
