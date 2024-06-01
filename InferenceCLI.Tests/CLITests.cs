using System.Threading.Tasks;
using Xunit;
using InferenceCLI.CLI;

namespace InferenceCLI.Tests
{
    public class CLITests
    {
        [Theory]
        [InlineData(new string[] { "--model", "Phi3-Mini-128K", "--precision", "INT4" }, "Phi3-Mini-128K", "INT4")]
        [InlineData(new string[] { "--model", "Phi3-Mini-4K" }, "Phi3-Mini-4K", "INT4")]
        [InlineData(new string[] { "--precision", "INT4" }, "Phi3-Mini-4K", "INT4")]
        [InlineData(new string[] { }, "Phi3-Mini-4K", "INT4")]
        public async Task Parse_ShouldReturnExpectedModelAndPrecision(string[] args, string expectedModel, string expectedPrecision)
        {
            // Arrange
            var parser = new Parser();

            // Act
            (string model, string precision) = await parser.Parse(args);

            // Assert
            Assert.Equal(expectedModel, model);
            Assert.Equal(expectedPrecision, precision);
        }
    }
}
