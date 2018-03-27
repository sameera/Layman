using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Layman.Samples
{
    [TestClass]
    public class CalculatorTest : Layman.TestSpec
    {
        [TestMethod]
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

        #region Internal

        Calculator the_calculator;
        int calculated_result;

        #endregion
    }
}
