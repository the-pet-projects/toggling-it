namespace Presentation.API.Tests
{
    using FluentAssertions;
    using Xunit;

    public class TogglesControllerTests
    {
        [Fact]
        public void Fake_Test_Passed()
        {
            var flag = true;

            flag.Should().BeTrue();
        }
    }
}