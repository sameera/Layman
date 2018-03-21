# Layman
Layman is a very simple BDD framework for .NET that's built on top of xUnit as well as Visual Studio Unit Tests. 
The main objective of the framework is to help you write readable, BDD style tests.

Layman was initially inspired by [NSpec](https://github.com/mattflo/NSpec) which is a great, feature-packed framework.
We wrote Layman because NSpec [was not strong named](https://github.com/mattflo/NSpec/issues/72) which as a requirement
for our project and we didn't want to give up on the nice readable test codes that we were able to write with NSpec. 

Feature-wise, Layman has very little; most notably, it doesn't generate nice to read test reports (at least for now). 
The goal was to enable developers to write readable tests which has been the only focus so far.

## Quick Start
1. Start a Visual Studio Test Project.
2. Add Layman using NuGet
	`PM> Install-Package Layman`
3. Add a Unit Test class inherited by Layman.TestSpec

## Sample code

```C#
/*
 * This sample was adopted from SpecFlow's getting-started guide: http://www.specflow.org/getting-started/
 */
namespace Layman.Samples
{
    class Calculator
    {
        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
    }
}
```
```C#
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Layman.Samples
{
    [TestClass]
    public class CalculatorTest : Layman.TestSpec
    {
        [TestMethod]
        public void Two_numbers_can_be_added()
        {
            given("I've entered two numbers to the calculator", () => {
                the_calculator = new Calculator {
                    FirstNumber = 10,
                    SecondNumber = 20
                };
            });

            when("I Add", () => calculated_result = the_calculator.Add());

            it("gives me the sum of the numbers", () => calculated_result.Should_be(30));
        }

        #region Internal

        Calculator the_calculator;
        int calculated_result;

        #endregion
    }
}
```

```C#
// Sample: xUnit / .NET Core

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

        public CalculatorTest(ITestOutputHelper output): base(output)
        {
        }

        #endregion
    }
}


```