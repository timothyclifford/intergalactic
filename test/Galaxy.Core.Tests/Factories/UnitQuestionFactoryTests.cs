using Xunit;

using Galaxy.Core.Factories;

namespace Galaxy.Core.Tests.Factories
{
    public class UnitQuestionFactoryTests
    {
        [Fact]
        public void GivenValidInput_Create_ReturnsPopulatedObject()
        {
            var factory = new UnitQuestionFactory(TestSettings.UnitQuestionPattern);

            var unitQuestion = factory.Create("how much is pish tegj glob glob ?");

            Assert.NotNull(unitQuestion);
            Assert.Equal("pish tegj glob glob", unitQuestion.Units);
        }

        [Fact]
        public void GivenInvalidInput_Create_ReturnsNull()
        {
            var factory = new UnitQuestionFactory(TestSettings.UnitQuestionPattern);

            var unitQuestion = factory.Create("how is pish tegj glob glob much ?");

            Assert.Null(unitQuestion);
        }
    }
}