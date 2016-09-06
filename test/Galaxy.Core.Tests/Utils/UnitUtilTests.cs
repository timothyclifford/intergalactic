using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using Galaxy.Core.Models;
using Galaxy.Core.Utils;

namespace Galaxy.Core.Tests.Factories
{
    public class UnitUtilTests
    {
        [Fact]
        public void GivenValidSymbolString_GetByNames_ReturnsSymbol()
        {
            var names = "abc def";
            var unitDefinitions = new List<Unit>
            {
                new Unit("abc", Symbol.X),
                new Unit("def", Symbol.V)
            };

            var units = UnitUtil.GetByNames(names, unitDefinitions);

            Assert.NotNull(units);
            Assert.Equal(2, units.Count());
        }

        [Fact]
        public void GivenMissingDefinitions_GetByNames_ThrowsException()
        {
            var names = "abc def";
            var unitDefinitions = new List<Unit>
            {
                new Unit("abc", Symbol.X)
            };

            var exception = Record.Exception(() => UnitUtil.GetByNames(names, unitDefinitions).ToArray());
            
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }
    }
}