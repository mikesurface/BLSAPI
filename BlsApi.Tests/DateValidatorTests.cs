using CPIService.Core;
using Xunit;

namespace BlsApi.Tests
{
    public class DateValidatorTests
    {
        [Theory]
        [InlineData("2023", true)]
        [InlineData("1999", true)]
        [InlineData("1899", false)]
        [InlineData("abcd", false)]
        [InlineData("3025", false)]
        public void IsValidYear_ReturnsExpected(string year, bool expected)
        {
            var result = DateValidator.IsValidYear(year);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("January", true)]
        [InlineData("january", true)]
        [InlineData("Smarch", false)]
        [InlineData("13", false)]
        [InlineData("", false)]
        public void IsValidMonth_ReturnsExpected(string month, bool expected)
        {
            var result = DateValidator.IsValidMonth(month);
            Assert.Equal(expected, result);
        }
    }
}
