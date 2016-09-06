using Galaxy.Core.Models;

using System.Collections.Generic;
using Xunit;

namespace Galaxy.Core.Tests.Models
{
    public class RomanNumeralTests
    {
        public class ValidateTests
        {
            [Fact]
            public void GivenValidSymbols_ReturnsTrue()
            {
                var symbols = new List<Symbol>();
                symbols.Add(Symbol.X);
                symbols.Add(Symbol.X);
                symbols.Add(Symbol.V);
                var romanNumeral = new RomanNumeral(symbols);

                var isValid = romanNumeral.IsValid();

                Assert.True(isValid);
            }

            [Fact]
            public void GivenFourXs_ReturnsFalse()
            {
                var symbols = new List<Symbol>();
                symbols.Add(Symbol.X);
                symbols.Add(Symbol.X);
                symbols.Add(Symbol.X);
                symbols.Add(Symbol.X);
                var romanNumeral = new RomanNumeral(symbols);

                var isValid = romanNumeral.IsValid();

                Assert.False(isValid);
            }

            [Fact]
            public void GivenTwoDs_ReturnsFalse()
            {
                var symbols = new List<Symbol>();
                symbols.Add(Symbol.D);
                symbols.Add(Symbol.D);
                var romanNumeral = new RomanNumeral(symbols);

                var isValid = romanNumeral.IsValid();

                Assert.False(isValid);
            }

            [Fact]
            public void GivenIL_ReturnsFalse()
            {
                var symbols = new List<Symbol>();
                symbols.Add(Symbol.I);
                symbols.Add(Symbol.L);
                var romanNumeral = new RomanNumeral(symbols);

                var isValid = romanNumeral.IsValid();

                Assert.False(isValid);
            }

            [Fact]
            public void GivenXD_ReturnsFalse()
            {
                var symbols = new List<Symbol>();
                symbols.Add(Symbol.X);
                symbols.Add(Symbol.D);
                var romanNumeral = new RomanNumeral(symbols);

                var isValid = romanNumeral.IsValid();

                Assert.False(isValid);
            }

            [Fact]
            public void GivenVX_ReturnsFalse()
            {
                var symbols = new List<Symbol>();
                symbols.Add(Symbol.V);
                symbols.Add(Symbol.X);
                var romanNumeral = new RomanNumeral(symbols);

                var isValid = romanNumeral.IsValid();

                Assert.False(isValid);
            }
        }

        public class CalculateTests
        {
            [Fact]
            public void GivenSymbolsWithoutSubtraction_ReturnsCorrectValue()
            {
                var symbols = new List<Symbol>();
                symbols.Add(Symbol.M);
                symbols.Add(Symbol.D);
                symbols.Add(Symbol.C);
                symbols.Add(Symbol.L);
                symbols.Add(Symbol.X);
                symbols.Add(Symbol.V);
                symbols.Add(Symbol.I);
                var romanNumeral = new RomanNumeral(symbols);

                var integerValue = romanNumeral.Calculate();

                Assert.Equal(1666, integerValue);
            }

            [Fact]
            public void GivenSymbolsWithSubtraction_ReturnsCorrectValue()
            {
                var symbols = new List<Symbol>();
                symbols.Add(Symbol.M);
                symbols.Add(Symbol.D);
                symbols.Add(Symbol.C);
                symbols.Add(Symbol.L);
                symbols.Add(Symbol.X);
                symbols.Add(Symbol.I);
                symbols.Add(Symbol.V);
                var romanNumeral = new RomanNumeral(symbols);

                var integerValue = romanNumeral.Calculate();

                Assert.Equal(1664, integerValue);
            }
        }
    }
}