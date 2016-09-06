using Xunit;

using Galaxy.Core.Factories;

namespace Galaxy.Core.Tests.Factories
{
    public class ResourceFactoryTests
    {
        [Fact]
        public void GivenValidInput_Create_ReturnsPopulatedObject()
        {
            var factory = new ResourceFactory(TestSettings.ResourcePattern);

            var resource = factory.Create("glob glob Silver is 34 Credits");

            Assert.NotNull(resource);
            Assert.Equal("Silver", resource.Name);
            Assert.Equal("glob glob", resource.Units);
            Assert.Equal(34, resource.Credits);
        }

        [Fact]
        public void GivenInvalidInput_ReturnsNull()
        {
            var factory = new ResourceFactory(TestSettings.ResourcePattern);

            var resource = factory.Create("glob glob Silver isn't Credits 63");

            Assert.Null(resource);
        }
    }
}