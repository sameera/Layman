using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Layman
{
    [TestClass]
    public partial class TestSpec
    {
        /*
        protected void MockLogging()
        {
            var config = new LoggingConfiguration();
            config.AddTarget(new NLog.Targets.NullTarget());
            NLog.LogManager.Configuration = config;
        }
        */

        protected void given(string description, Action setupAction)
        {
            Console.WriteLine(description);
            given(setupAction);
        }

        protected void given(Action setupAction)
        {
            setupAction();
        }

        protected void when(string description, Action act)
        {
            Console.WriteLine(description);
            when(act);
        }

        protected void when(Action act)
        {
            act();
        }

        protected void it(string description, Func<bool> check)
        {
            Assert.IsTrue(check(), description + " :FAILED:");
            Console.WriteLine(description);
        }

        protected void it(Func<bool> check)
        {
            it(check.Method.Name, check);
        }

        protected void it(string description, Action check)
        {
            check();
            Console.WriteLine(description);
        }

        protected void it(Action check)
        {
            check();
        }

        protected struct Reaction<T>
        {
            private readonly T subject;

            public void which_results_in(Action<T> react)
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
