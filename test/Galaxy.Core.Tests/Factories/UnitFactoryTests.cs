using Xunit;

using Galaxy.Core.Factories;
using Galaxy.Core.Models;

namespace Galaxy.Core.Tests.Factories
{
    public class UnitFactoryTests
    {
        [Fact]
        public void GivenValidInput_Create_ReturnsPopulatedObject()
        {
            var factory = new UnitFactory(TestSettings.UnitPattern);

            var unit = factory.Create("glob is I");

            Assert.NotNull(unit);
            Assert.Equal("glob", unit.Name);
            Assert.Equal(Symbol.I, unit.Symbol);
        }

        [Fact]
        public void GivenInvalidInput_Create_ReturnsNull()
        {
            var factory = new UnitFactory(TestSettings.UnitPattern);

            var unit = factory.Create("glob Z is");

            Assert.Null(unit);
        }
    }
}