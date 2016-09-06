using Xunit;

using Galaxy.Core.Factories;

namespace Galaxy.Core.Tests.Factories
{
    public class ResourceQuestionFactoryTests
    {
        [Fact]
        public void GivenValidInput_Create_ReturnsPopulatedObject()
        {
            var factory = new ResourceQuestionFactory(TestSettings.ResourceQuestionPattern);

            var question = factory.Create("how many Credits is glob prok Silver ?");

            Assert.NotNull(question);
            Assert.Equal("Silver", question.Resource);
            Assert.Equal("glob prok", question.Units);
        }

        [Fact]
        public void GivenInvalidInput_Create_ReturnsNull()
        {
            var factory = new ResourceQuestionFactory(TestSettings.ResourceQuestionPattern);

            var question = factory.Create("how many Invalid is bla bla bla ?");

            Assert.Null(question);
        }
    }
}