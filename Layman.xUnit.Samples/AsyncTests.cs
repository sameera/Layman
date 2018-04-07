using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Layman.xUnit.Samples
{
    public class AsyncTests: TestSpec
    {
        [Fact]
        public async void Async_test_setup()
        {
            int variable_to_be_setup = 0;

            await Given("The setup has to be done asynchronously", async () => {
                await Task.Delay(1000);
                return variable_to_be_setup = 10;
            });

            It("Waits for the the setup to compelte before executing the checks", () => {
                variable_to_be_setup.Should().Be(10);
            });
        }

        [Fact]
        public async void Async_execution()
        {
            int variable_to_be_modified = 0;

            await When("The execution happens asynchronously", async () => {
                await Task.Delay(1000);
                return variable_to_be_modified = 100;
            });

            It("Waits for the execution to complete before executing the checks", () => {
                variable_to_be_modified.Should().Be(100);
            });
        }

        [Fact]
        public async void Async_checking()
        {
            bool wasChecked = false;

            await It("Execute all aync checks", async () => {
                await Task.Delay(1000);
                wasChecked = true;
                return true;
            });

            And("Will end only after that", () => {
                wasChecked.Should().BeTrue();
            });
        }
    }
}
