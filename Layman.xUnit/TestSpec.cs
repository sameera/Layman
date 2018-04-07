using System;
using System.Linq;
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

        protected internal void Given(string description) => Output.WriteLine($"GIVEN {description}");

        protected internal void Given(Action setupAction) => setupAction();

        protected internal void Given<T>(out T state, Action setupAction)
        {
            state = default(T);
            Given(setupAction);
        }

        protected internal void Given<T>(string description, out T state, Action setupAction)
        {
            state = default(T);
            Given(description, setupAction);
        }

        protected internal async Task<T> Given<T>(string description, Func<Task<T>> asyncAction)
        {
            Given(description);
            return await asyncAction();
        }

        protected internal async Task Given(string description, Func<Task> asyncAction)
        {
            Given(description);
            await asyncAction();
        }

        protected internal void Given(string description, Action setupAction)
        {
            Given(description);
            Given(setupAction);
        }

        protected internal void When(string description) => Output.WriteLine($"\tWHEN {description}");

        protected internal void When(Action act) => act();

        protected internal void When<T>(out T state, Action action)
        {
            state = default(T);
            When(action);
        }

        protected internal async Task<T> When<T>(string description, Func<Task<T>> asyncAction)
        {
            When(description);
            return await asyncAction();
        }

        protected internal void When<T>(string description, out T state, Action act)
        {
            state = default(T);
            When(description, act);
        }

        protected internal void When(string description, Action act)
        {
            When(description);
            When(act);
        }

        protected internal void It(string description, Func<bool> check)
        {
            AssertInternal(description, check());
        }

        protected internal void It(string description, params Func<bool>[] checks)
        {
            AssertInternal(description, checks.All(check => check()));
        }

        protected internal void It(string description, params bool[] checkResults)
        {
            AssertInternal(description, checkResults.All(c => c));
        }

        private void AssertInternal(string description, bool success)
        {
            Output.WriteLine(string.Concat("\t\tIT ", description, success ? string.Empty : " :FAILED:"));
            Assert.True(success, description + " :FAILED:");
        }

        protected internal async Task<T> It<T>(string description, Func<Task<T>> asyncAction)
        {
            It(description);
            return await asyncAction();
        }

        protected internal void It(string description, Action check)
        {
            It(description);
            check();
        }

        protected internal void It(Action check)
        {
            check();
        }

        private void It(string description)
        {
            Output.WriteLine($"\t\tIT {description}");
        }

        //protected struct Reaction<T>
        //{
        //    private readonly T subject;

        //    public void Which_results_in(Action<T> react)
        //    {
        //        react(subject);
        //    }

        //    public Reaction(T subject)
        //    {
        //        this.subject = subject;
        //    }
        //}
    }
}
