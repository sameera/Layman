using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Layman.Samples
{
    [TestClass]
    public class AsyncTests: TestSpec
    {
        [TestMethod]
        public async Task Async_test_setup()
        {
            int variable_to_be_setup = 0;

            await 
            Given("The setup has to be done asynchronously", async () => {
                await Task.Delay(1000);
                variable_to_be_setup = 10;
            });

            It("Waits for the the setup to compelte before executing the checks", () => {
                variable_to_be_setup.Should().Be(10);
            });
        }

        [TestMethod]
        public async Task Async_execution()
        {
            int variable_to_be_modified = 0;

            await 
            When("The execution happens asynchronously", async () => {
                await Task.Delay(1000);
                variable_to_be_modified = 100;
            });

            It("Waits for the execution to complete before executing the checks", () => {
                variable_to_be_modified.Should().Be(100);
            });
        }

        [TestMethod]
        public async Task Async_checking()
        {
            bool wasChecked = false;

            await 
            It("Execute all aync checks", async () => {
                await Task.Delay(1000);
                wasChecked = true;
            });

            And("Will end only after that", () => {
                wasChecked.Should().BeTrue();
            });
        }

        [TestMethod]
        public async Task Async_test_with_simpler_statements()
        {
            int the_variable = 0;

            Given("that the test needs async setup");
            {
                await Task.Delay(1000);
                the_variable = 10;
            }

            When("the execution is also async");
            {
                await Task.Delay(1000);
                the_variable++;
            }

            It("Can wait for setup and execution and then execute the checks");
            {
                the_variable.Should().Be(11);
                await Task.Delay(1000);

                the_variable++;
            }
            And("Even do a follow up");
            {
                await Task.Delay(1000);
                the_variable.Should().Be(12);
            }
        }
    }
}
