using NUnit.Framework;
using Upskill.Contracts.Definitions;
using Upskill.Contracts.Services;

namespace Upskill.AwsApi.Tests.Services
{
    public class GreyscaleImageFilterTests
    {
        private static class Colors
        {
            public const uint Green = 0x00FF00;
            public const uint Grey = 0xFFFFFF;
            public const uint Magenta = 0xFF00FF;
            public const uint Black = 0x000000;
        }

        private IImageFilter _filter;

        [SetUp]
        public void Setup()
        {
            _filter = new GreyscaleImageFilter(); 
        }

        [Test]
        public void GivenGreenImage_ShouldReturnGreyImage_WithGreenAsKeyColor()
        {
            Assert.Fail();
        }

        [Test]
        public void GivenMagentaImage_ShouldReturnBlackImage_WithGreenAsKeyColor()
        {
            Assert.Fail();
        }
    }
}