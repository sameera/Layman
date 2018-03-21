using Xunit;
using Xunit.Abstractions;

namespace Layman.xUnit.Samples
{
    public class CalculatorTest : TestSpec
    {
        [Fact]
        public void Two_numbers_can_be_added()
        {
            Given("I've entered two numbers to the calculator", () => {
                    the_calculator = new Calculator();
                    the_calculator.FirstNumber = 10;
                    the_calculator.SecondNumber = 20;
                });

            When("I Add", () => calculated_result = the_calculator.Add());

            It("gives me the sum of the numbers", () => calculated_result.Should_be(30));
        }

        #region Internal

        Calculator the_calculator;
        int calculated_result;

        public CalculatorTest(ITestOutputHelper output): base(output)
        {
        }

        #endregion
    }
}
