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
                the_calculator = new Calculator {
                    FirstNumber = 10,
                    SecondNumber = 20
                };
            });

            When("I Add", () => calculated_result = the_calculator.Add());

            It("gives me the sum of the numbers", () => calculated_result.Should_be(30));
        }

        [Fact]
        public void Does_not_modify_orignal_values_when_adding()
        {
            Given("I've entered two numbers to the calculator", () => {
                the_calculator = new Calculator {
                    FirstNumber = 10,
                    SecondNumber = 20
                };
            });

            When("I Add", () => calculated_result = the_calculator.Add());

            // You can do more than one assertion like this:
            It("Leaves original values are unaffected",
                () => the_calculator.FirstNumber.Should_be(10),
                () => the_calculator.SecondNumber.Should_be(20)
            );

            // When the asssertions are one liners (as in the above, you could alternatively write
            It("Leaves original values are unaffected",
                the_calculator.FirstNumber.Should_be(10),
                the_calculator.SecondNumber.Should_be(20)
            );
        }

        #region Internal

        Calculator the_calculator;
        int calculated_result;

        public CalculatorTest(ITestOutputHelper output) : base(output)
        {
        }

        #endregion
    }
}
