using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Layman
{
    [TestClass]
    public partial class TestSpec
    {
        protected void Given(string description, Action setupAction)
        {
            Console.WriteLine($"GIVEN {description}");
            Given(setupAction);
        }

        protected void Given(Action setupAction)
        {
            setupAction();
        }

        protected void When(string description, Action act)
        {
            Console.WriteLine($"\tWHEN {description}");
            When(act);
        }

        protected void When(Action act)
        {
            act();
        }

        protected void It(string description, Func<bool> check)
        {
            Assert.IsTrue(check(), description + " :FAILED:");
            Console.WriteLine($"\t\tIT {description}");
        }

        protected void It(Func<bool> check)
        {
            It(check.Method.Name, check);
        }

        protected void It(string description, Action check)
        {
            check();
            Console.WriteLine($"\t\tIT {description}");
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
