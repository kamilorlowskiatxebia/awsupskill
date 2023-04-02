using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Upskill.Contracts.Models;

namespace Upskill.AwsApi.Tests.Models
{
    [TestFixture]
    public class RawImageTests
    {
        public const uint OverLimit = RawImage.MaxSize + 1;

        [Test]
        public void ShouldThrow_ArgumentNullException_WhenRawDataIsNullOrEmpty()
        {
            // Arrange
            var inputSize = 4U;

            // Act
            // Assert
            Assert.Throws(typeof(ArgumentNullException), () => new RawImage(inputSize, inputSize, null));
        }

        [TestCase(0U, 16U)]
        [TestCase(16U, 0U)]
        [TestCase(OverLimit, 16U)]
        [TestCase(16U, OverLimit)]
        public void ShouldThrow_ArgumentException_WhenWidthOrHeightIsNotWithinTheLimit(uint inputWidth, uint inputHeight)
        {
            // Arrange
            var inputRawData = new byte[0];

            // Act
            // Assert
            Assert.Throws(typeof(ArgumentException), () => new RawImage(inputWidth, inputHeight, inputRawData));
        }

        [Test]
        public void ShouldThrow_ArgumentException_WhenImageSizeDoesNotMatchDataLength()
        {
            // Arrange
            var inputSize = 4U;
            var inputRawData = new byte[inputSize * inputSize + 1];

            // Act
            // Assert
            Assert.Throws(typeof(ArgumentException), () => new RawImage(inputSize, inputSize, inputRawData));
        }

        [Test]
        public void ShouldReturn_DifferentReferenceFromSource_WhenGetRawDataIsUsed()
        {
            // Arrange
            var inputSize = 4U;
            var inputRawData = new byte[inputSize * inputSize];
            var rawImage = new RawImage(inputSize, inputSize, inputRawData);

            // Act
            var result = rawImage.Data;

            // Assert
            Assert.AreNotSame(inputRawData, result);
        }

        [Test]
        public void ShouldNotModifyRawData_WhenReturnedRawDataIsModified()
        {
            // Arrange
            byte exampleValue = 0x01; 
            var inputSize = 4U;
            var inputRawData = new byte[inputSize * inputSize];
            for(int i = 0; i < inputSize; i++)
            {
                inputRawData[i] = exampleValue;
            }

            var rawImage = new RawImage(inputSize, inputSize, inputRawData);

            // Act
            var result1 = rawImage.Data;
            for(int i = 0; i < result1.Length; i++)
            {
                result1[i] = 0xFF;
            }

            var result2 = rawImage.Data;
            var resultMask = 0U;
            for(int i = 0; i < result2.Length; i++)
            {
                resultMask |= result2[i];
            }

            // Assert
            Assert.AreEqual(exampleValue, resultMask);

        }
    }
}
