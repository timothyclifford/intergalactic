using Xunit;

using Galaxy.Core.Utils;

namespace Galaxy.Core.Tests.Factories
{
    public class StringUtilTests
    {
        [Fact]
        public void GivenStringWithSpaces_SplitBySpaces_ReturnsListWithItems()
        {
            var withSpaces = "abc def ghi";

            var symbol = StringUtil.SplitBySpaces(withSpaces);

            Assert.NotNull(withSpaces);
            Assert.Equal(3, symbol.Length);
        }
        
        [Fact]
        public void GivenStringWithoutSpaces_SplitBySpaces_ReturnsListWithOneItem()
        {
            var withSpaces = "abc";

            var symbol = StringUtil.SplitBySpaces(withSpaces);

            Assert.NotNull(withSpaces);
            Assert.Equal(1, symbol.Length);
        }
    }
}