using MoreLinq.Extensions;
using System.Collections.Generic;
using System.Linq;
using static ProtoStar.DimensionalAnalysis.DimensionExtensions;

namespace ProtoStar.DimensionalAnalysis
{
    public class Dimension : IDimension
    {
        public Dimension(IReadOnlyDictionary<BaseDimension, double> value, string name)
        {
            Value = value.Where(kv => kv.Value != 0.0).ToDictionary(kv => kv.Key, kv => kv.Value);
            Name = name;
        }

        public Dimension(IReadOnlyDictionary<BaseDimension, double> value) : this(value, "") { }

        public IReadOnlyDictionary<BaseDimension, double> Value { get; }

        public string Name { get; }

        public bool Equals(IDimension other)
        {
            return Value.IsEquivalentTo(other?.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is IDimension dimension ? Equals(dimension) : false;
        }

        public override int GetHashCode()
        {
            return Value.Select(kv => kv.Key.GetHashCode() ^ kv.Value.GetHashCode()).Aggregate((l, r) => l ^ r);
        }

        public static Dimension operator *(Dimension left, IDimension right)
        {
            return new Dimension(Multiply(left.Value, right.Value));
        }

        public static Dimension operator /(Dimension left, IDimension right)
        {
            return new Dimension(Divide(left.Value, right.Value));
        }
    }
}
