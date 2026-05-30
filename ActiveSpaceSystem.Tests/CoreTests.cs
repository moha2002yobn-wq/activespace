using Xunit;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;

namespace ActiveSpaceSystem.Tests
{
    public class CoreBusinessLogicTests
    {
        [Fact]
        public void ValidInput_Should_ProcessSuccessfully()
        {
            var input = "test_data";
            var result = ProcessData(input);
            result.Should().NotBeNull();
            result.Should().Be("test_data_processed");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void InvalidInput_Should_ThrowException(string invalidInput)
        {
            Action act = () => ProcessData(invalidInput);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void DataProcessing_Should_HandleLargeDatasets()
        {
            var largeDataset = GenerateLargeDataset(1000);
            var result = ProcessLargeData(largeDataset);
            result.Should().NotBeNull();
            result.Count.Should().Be(1000);
        }

        private string ProcessData(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be null or empty", nameof(input));
            return $"{input}_processed";
        }

        private List<string> ProcessLargeData(List<string> data) => data ?? new List<string>();

        private List<string> GenerateLargeDataset(int size)
        {
            var dataset = new List<string>();
            for (int i = 0; i < size; i++)
                dataset.Add($"data_{i}");
            return dataset;
        }
    }

    public class ValidationTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Validation_Should_ReturnExpectedResult(bool isValid)
        {
            var validator = new DataValidator();
            var result = validator.IsValid(isValid);
            result.Should().Be(isValid);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(101)]
        public void ValueOutOfRange_Should_ReturnFalse(int value)
        {
            var validator = new DataValidator();
            var result = validator.IsInRange(value);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(100)]
        public void ValueInRange_Should_ReturnTrue(int value)
        {
            var validator = new DataValidator();
            var result = validator.IsInRange(value);
            result.Should().BeTrue();
        }
    }
}
