using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Layman
{
    [TestClass]
    public partial class TestSpec
    {
        protected void Given(string description) => Console.WriteLine($"GIVEN {description}");

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

        protected void When(string description) => Console.WriteLine($"\tWHEN {description}");

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
            Console.WriteLine(string.Concat("\t\tIT ", description, success ? string.Empty : " :FAILED:"));
            Assert.IsTrue(success, description + " :FAILED:");
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
            Console.WriteLine($"\t\tIT {description}");
        }
    }
}
