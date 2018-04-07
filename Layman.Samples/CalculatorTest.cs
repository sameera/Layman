using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Layman.Samples
{
    [TestClass]
    public class CalculatorTest : Layman.TestSpec
    {
        [TestMethod]
        public void Two_numbers_can_be_added()
        {
            Given("I've entered two numbers to the calculator", out Calculator the_calculator, () => {
                the_calculator = new Calculator {
                    FirstNumber = 10,
                    SecondNumber = 20
                };
            });

            When("I Add", out int calculated_result, () => calculated_result = the_calculator.Add());

            It("gives me the sum of the numbers", () => calculated_result.Should().Be(30));
        }

        [TestMethod]
        public void Affect_on_orignal_values_when_adding()
        {
            Given("I've entered two numbers to the calculator", out Calculator the_calculator, () => {
                the_calculator = new Calculator {
                    FirstNumber = 10,
                    SecondNumber = 20
                };
            });

            When("I Add", out int calculated_result, () => calculated_result = the_calculator.Add());

            // You can do more than one assertion like this:
            It("Leaves original values are unaffected", () => {
                the_calculator.FirstNumber.Should().Be(10);
                the_calculator.SecondNumber.Should().Be(20);
            });

            // When the asssertions are one liners (as in the above, you could alternatively write
            And("Leaves original values unaffected", () => {
                the_calculator.FirstNumber.Should().Be(10);
                the_calculator.SecondNumber.Should().Be(20);
            });
        }
    }
}
