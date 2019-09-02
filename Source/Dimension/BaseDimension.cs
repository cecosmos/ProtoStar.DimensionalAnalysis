using System;
using System.Collections.Generic;
using static ProtoStar.DimensionalAnalysis.DimensionExtensions;

namespace ProtoStar.DimensionalAnalysis
{
    public abstract class BaseDimension :
        IDimension, IEquatable<BaseDimension>
    {

        protected BaseDimension(string name)
        {
            Value = new Dictionary<BaseDimension, double>() { { this, 1.0 } };
            Name = name;
        }

        public IReadOnlyDictionary<BaseDimension, double> Value { get; }
        public string Name { get; }

        public bool Equals(IDimension other)
        {
            if (other is BaseDimension @base) return Equals(@base);
            return Value.IsEquivalentTo(other?.Value);
        }

        public bool Equals(BaseDimension other)
        {
            return GetType() == other?.GetType();
        }

        public override bool Equals(object obj)
        {
            if (obj is IDimension dimension) return Equals(dimension);
            return false;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        public static Dimension operator *(BaseDimension left, IDimension right)
        {
            return new Dimension(Multiply(left.Value, right.Value));
        }

        public static Dimension operator /(BaseDimension left, IDimension right)
        {
            return new Dimension(Divide(left.Value, right.Value));
        }
    }
}
