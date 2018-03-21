using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Layman
{
    public partial class TestSpec
    {
        protected ITestOutputHelper Output;

        public TestSpec(ITestOutputHelper outputHelper)
        {
            Output = outputHelper;
        }

        protected void Given(string description, Action setupAction)
        {
            Output.WriteLine($"GIVEN {description}");
            Given(setupAction);
        }

        protected void Given(Action setupAction)
        {
            setupAction();
        }

        protected void When(string description, Action act)
        {
            Output.WriteLine($"\tWHEN {description}");
            When(act);
        }

        protected void When(Action act)
        {
            act();
        }

        protected void It(string description, Func<bool> check)
        {
            Assert.True(check(), description + " :FAILED:");
            Output.WriteLine($"\t\tIT {description}");
        }

        protected void It(string description, params Func<bool>[] checks)
        {
            Output.WriteLine($"\t\tIT {description}");
            Assert.True(checks.All(check => check()), description + " :FAILED:");
        }

        protected void It(string description, params bool[] checkResults)
        {
            Output.WriteLine($"\t\tIT {description}");
            Assert.True(checkResults.All(c => c), description + " :FAILED:");
        }

        protected void It(string description, Action check)
        {
            check();
            Output.WriteLine($"\t\tIT {description}");
        }

        protected void It(Action check)
        {
            check();
        }

        protected struct Reaction<T>
        {
            private readonly T subject;

            public void Which_results_in(Action<T> react)
            {
                react(subject);
            }

            public Reaction(T subject)
            {
                this.subject = subject;
            }
        }
    }
}
