using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Layman
{
    public partial class TestSpec
    {
        protected readonly ITestOutputHelper Output;

        public TestSpec() : this(new DebugOutputHelper())
        {
        }

        public TestSpec(ITestOutputHelper outputHelper)
        {
            Output = outputHelper;
        }

        protected void Given(string description) => Output.WriteLine($"GIVEN {description}");

        protected void Given(Action setupAction) => setupAction();

        protected void Given<T>(out T state, Action setupAction)
        {
            state = default(T);
            Given(setupAction);
        }

        protected void Given<T>(string description, out T state, Action setupAction)
        {
            state = default(T);
            Given(description, setupAction);
        }

        protected async Task Given(string description, Func<Task> asyncAction)
        {
            Given(description);
            await asyncAction();
        }

        protected void Given(string description, Action setupAction)
        {
            Given(description);
            Given(setupAction);
        }

        protected void When(string description) => Output.WriteLine($"\tWHEN {description}");

        protected void When(Action act) => act();

        protected void When<T>(out T state, Action action)
        {
            state = default(T);
            When(action);
        }

        protected async Task When(string description, Func<Task> asyncAction)
        {
            Given(description);
            await asyncAction();
        }

        protected void When<T>(string description, out T state, Action act)
        {
            state = default(T);
            When(description, act);
        }

        protected void When(string description, Action act)
        {
            When(description);
            When(act);
        }

        protected void It(string description, Func<bool> check)
        {
            AssertInternal(description, check());
        }

        protected void It(string description, bool outcome)
        {
            AssertInternal(description, outcome);
        }

        private void AssertInternal(string description, bool success)
        {
            Output.WriteLine(string.Concat("\t\tIT ", description, success ? string.Empty : " :FAILED:"));
            Assert.True(success, description + " :FAILED:");
        }

        protected async Task It(string description, Func<Task> asyncAction)
        {
            It(description);
            await asyncAction();
        }

        protected void It(string description, Action check)
        {
            It(description);
            check();
        }

        protected void It(Action check)
        {
            check();
        }

        protected void It(string description)
        {
            Output.WriteLine($"\t\tIT {description}");
        }
    }
}
