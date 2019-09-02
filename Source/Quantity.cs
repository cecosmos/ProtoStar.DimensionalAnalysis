using System;
using System.Collections.Generic;
using System.Text;
using static ProtoStar.DimensionalAnalysis.ValueConversions;
using static ProtoStar.DimensionalAnalysis.DimensionExtensions;

namespace ProtoStar.DimensionalAnalysis
{
    public struct Quantity : IQuantity
    {

        public Quantity(double sIValue) : this()
        {
            SIValue = sIValue;
        }

        public Quantity(IDimension dimension) : this(dimension,0) { }

        public Quantity(IDimension dimension, double sIValue)
        {
            Dimension = dimension;
            SIValue = sIValue;
        }

        public double this[IUnit unit]
        {
            get => this.IsDimensionalConsistent(unit) ? ConvertFromSI(SIValue,unit) : throw new Exception();
            set => SIValue = this.IsDimensionalConsistent(unit) ? ConvertToSI(value,unit) : throw new Exception();
        }

        public double SIValue { get; set; }

        public IDimension Dimension { get; }

        public int CompareTo(object obj)
        {
            return obj is IQuantity other ? CompareTo(other) : throw new Exception();
        }

        public int CompareTo(IQuantity other)
        {
            return SIValue.CompareTo(other.SIValue);
        }

        public bool Equals(IQuantity other)
        {
            return this.IsDimensionalConsistent(other) && SIValue.Equals(other.SIValue);
        }
    }
}
