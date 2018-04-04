﻿using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Layman.xUnit.Samples
{
    public class StatementPatternTests: TestSpec
    {
        [Fact]
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
            And("doesn't return just the either of the given values", () => {
                // This test is just to demonstrte the Not() function. Otherwise, it's pretty silly to write
                // a test like this :)
                calculated_result.Should().NotBe(10);
                calculated_result.Should().NotBe(20);
            });
        }

        [Fact]
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

        #region Internal

        public StatementPatternTests(ITestOutputHelper output) : base(output)
        {
        }

        #endregion
    }
}