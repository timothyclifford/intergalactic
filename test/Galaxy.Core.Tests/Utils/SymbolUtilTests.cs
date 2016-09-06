using Xunit;

using Galaxy.Core.Models;
using Galaxy.Core.Utils;

namespace Galaxy.Core.Tests.Factories
{
    public class SymbolUtilTests
    {
        [Fact]
        public void GivenValidSymbolString_ParseSymbol_ReturnsSymbol()
        {
            var symbolString = "I";

            var symbol = SymbolUtil.ParseSymbol(symbolString);

            Assert.Equal(Symbol.I, symbol);
        }

        [Fact]
        public void GivenInvalidSymbolString_ParseSymbol_ReturnsUnknown()
        {
            var symbolString = "Z";

            var symbol = SymbolUtil.ParseSymbol(symbolString);

            Assert.Equal(Symbol.Unknown, symbol);
        }
    }
}