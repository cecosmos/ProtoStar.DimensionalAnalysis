using System.Collections.Generic;
using Xunit;
using Xunit.Categories;

namespace ProtoStar.DimensionalAnalysis
{
    public class DimensionTests
    {
        [Fact]
        [UnitTest]
        public void CanInstantiateBaseDimension()
        {
            StubBaseDimension1 dimension = new StubBaseDimension1();
            Assert.NotNull(dimension);
        }

        [Fact]
        [UnitTest]
        public void CanInstantiateDimension()
        {
            Dimension dimension = new Dimension(new Dictionary<BaseDimension, double>() { { new StubBaseDimension1(), 2.0 } });
            Assert.NotNull(dimension);
        }

        [Fact]
        [UnitTest]
        public void DimensionEquality()
        {
            StubBaseDimension1 baseDimension = new StubBaseDimension1();

            StubBaseDimension1 dimension1 = new StubBaseDimension1();
            IDimension iDimension1 = dimension1;

            Dimension dimension2 = new Dimension(new Dictionary<BaseDimension, double>() { { new StubBaseDimension1(), 1.0 } });
            IDimension iDimension2 = dimension2;

            StubBaseDimension2 dimension3 = new StubBaseDimension2();
            IDimension iDimension3 = dimension3;

            Dimension dimension4 = new Dimension(new Dictionary<BaseDimension, double>() { { new StubBaseDimension1(), 2.0 } });
            IDimension iDimension4 = dimension4;

            Dimension dimension5 = new Dimension(new Dictionary<BaseDimension, double>() { { new StubBaseDimension2(), 1.0 } });
            IDimension iDimension5 = dimension5;

            IDimension nullDimension = null;
            StubBaseDimension1 nullBaseDimension = null;

            Assert.True(baseDimension.Equals(dimension1));
            Assert.True(dimension1.Equals(baseDimension));
            Assert.True(baseDimension.Equals(iDimension1));
            Assert.True(iDimension1.Equals(baseDimension));

            Assert.True(baseDimension.Equals(dimension2));
            Assert.True(dimension2.Equals(baseDimension));
            Assert.True(baseDimension.Equals(iDimension2));
            Assert.True(iDimension2.Equals(baseDimension));

            Assert.False(baseDimension.Equals(dimension3));
            Assert.False(dimension3.Equals(baseDimension));
            Assert.False(baseDimension.Equals(iDimension3));
            Assert.False(iDimension3.Equals(baseDimension));

            Assert.False(baseDimension.Equals(dimension4));
            Assert.False(dimension4.Equals(baseDimension));
            Assert.False(baseDimension.Equals(iDimension4));
            Assert.False(iDimension4.Equals(baseDimension));

            Assert.False(baseDimension.Equals(dimension5));
            Assert.False(dimension5.Equals(baseDimension));
            Assert.False(baseDimension.Equals(iDimension5));
            Assert.False(iDimension5.Equals(baseDimension));

            Assert.False(baseDimension.Equals(nullDimension));
            Assert.False(dimension2.Equals(nullDimension));
            Assert.False(baseDimension.Equals(nullBaseDimension));
            Assert.False(dimension2.Equals(nullBaseDimension));

        }

        [Fact]
        [UnitTest]
        [Category("Operator")]
        public void DimensionMultiplication()
        {
            StubBaseDimension1 base1 = new StubBaseDimension1();
            StubBaseDimension2 base2 = new StubBaseDimension2();
            IDimension iBase2 = new StubBaseDimension2();

            Dimension dimension1 = new Dimension(new Dictionary<BaseDimension, double>() { { new StubBaseDimension1(), 1.0 }, { new StubBaseDimension2(), 2.0 } });
            IDimension iDimension1 = dimension1;

            Assert.Equal(dimension1, base1 * base2 * base2);
            Assert.Equal(dimension1, base1 * iBase2 * base2);
            Assert.Equal(base1 * base1 * base2 * base2, dimension1 * base1);
            Assert.Equal(base1 * base1 * base2 * base2, base1 * iDimension1);
        }

        [Fact]
        [UnitTest]
        [Category("Operator")]
        public void DimensionDivision()
        {
            StubBaseDimension1 base1 = new StubBaseDimension1();
            IDimension iBase1 = new StubBaseDimension1();
            StubBaseDimension2 base2 = new StubBaseDimension2();
            IDimension iBase2 = new StubBaseDimension2();

            Dimension dimension1 = new Dimension(new Dictionary<BaseDimension, double>() { { new StubBaseDimension1(), 1.0 }, { new StubBaseDimension2(), -2.0 } });
            IDimension iDimension1 = dimension1;

            Assert.Equal(dimension1, base1 / base2 / base2);
            Assert.Equal(iDimension1, base1 / iBase2 / base2);
        }

    }
}
