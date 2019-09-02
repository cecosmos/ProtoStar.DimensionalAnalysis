using MoreLinq.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ProtoStar.DimensionalAnalysis
{
    public static class DimensionExtensions
    {
        internal static bool IsEquivalentTo(
            this IReadOnlyDictionary<BaseDimension, double> first,
            IReadOnlyDictionary<BaseDimension, double> second)
        {
            if (second == null) return false;
            return first.Keys.Union(second.Keys).All(dimension => first.GetValue(dimension, 0) == second.GetValue(dimension, 0));
        }

        internal static IReadOnlyDictionary<BaseDimension, double> Multiply(
            IReadOnlyDictionary<BaseDimension, double> left,
            IReadOnlyDictionary<BaseDimension, double> right) =>
            left.Keys.Union(right.Keys).
                ToDictionary(
                    dimension => dimension,
                    dimension => left.GetValue(dimension) + right.GetValue(dimension));

        internal static IReadOnlyDictionary<BaseDimension, double> Divide(
            IReadOnlyDictionary<BaseDimension, double> left,
            IReadOnlyDictionary<BaseDimension, double> right) =>
            left.Keys.Union(right.Keys).
                ToDictionary(
                    dimension => dimension,
                    dimension => left.GetValue(dimension) - right.GetValue(dimension));

        internal static IReadOnlyDictionary<BaseDimension, double> Power(
            IReadOnlyDictionary<BaseDimension, double> left,
            double power) =>
            left.Keys.ToDictionary(dimension => dimension, dimension => left[dimension] * power);

        internal static TValue GetValue<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> source,
            TKey key,
            TValue fallback = default) =>
            source.TryGetValue(key, out TValue result) ? result : fallback;

        public static bool IsDimensionalConsistent(this IDimensionDependent source, IDimensionDependent target) =>
            source.Dimension.Equals(target.Dimension);

    }
}
