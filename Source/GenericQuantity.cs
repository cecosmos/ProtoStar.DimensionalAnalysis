using System;
using System.Collections.Generic;
using System.Text;
using static ProtoStar.DimensionalAnalysis.ValueConversions;

namespace ProtoStar.DimensionalAnalysis
{
    public struct Quantity<T> : IQuantity
        where T : IDimension, new()
    {
        public double this[IUnit unit] {get => ConvertFromSI(SIValue,unit);set => SIValue = ConvertToSI(value,unit);}

        public double this[Unit<T> unit] {get => ConvertFromSI(SIValue,unit);set => SIValue = ConvertToSI(value,unit);}

        public double SIValue { get; set; }

        public IDimension Dimension { get => new T(); }

        public int CompareTo(object obj)
        {
            return obj is IQuantity other ? CompareTo(other) : throw new ArgumentException("Object must be of type IQuantity.", nameof(obj));
        }

        public int CompareTo(IQuantity other)
        {
            return SIValue.CompareTo(other?.SIValue);
        }

        public bool Equals(IQuantity other)
        {
            return this.IsDimensionallyConsistent(other) && SIValue.Equals(other.SIValue);
        }
    }
}
