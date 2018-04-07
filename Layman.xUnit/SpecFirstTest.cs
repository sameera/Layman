//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Layman
//{
//    public class SpecFirstTest: TestSpec
//    {
//        protected Description Describe(out Spec spec)
//        {
//            spec = new Spec(this, new Description());
//            return spec.description;
//        }

//        protected Execution Execute(Spec spec)
//        {
//            return new Execution(spec);
//        }

//        public class Description
//        {
//            internal Queue<string> givens = new Queue<string>();
//            internal Queue<string> whens = new Queue<string>();
//            internal Queue<string> its = new Queue<string>();

//            public Description Given(string description)
//            {
//                givens.Enqueue(description);
//                return this;
//            }

//            public Description When(string description)
//            {
//                whens.Enqueue(description);
//                return this;
//            }

//            public Description It(string description)
//            {
//                its.Enqueue(description);
//                return this;
//            }

//            public Description And(string description)
//            {
//                its.Enqueue(description);
//                return this;
//            }
//        }

//        public class Spec
//        {
//            internal readonly TestSpec testSpec;
//            internal readonly Description description;

//            public Spec(TestSpec testSpec, Description description)
//            {
//                this.testSpec = testSpec;
//                this.description = description;
//            }
//        }

//        public class Execution
//        {
//            private readonly Description description;
//            private readonly TestSpec testSpec;

//            public Execution(Spec spec)
//            {
//                this.testSpec = spec.testSpec;
//                this.description = spec.description;
//            }

//            public Execution Given(Action action)
//            {
//                this.testSpec.Given(this.description.givens.Dequeue(), action);
//                return this;
//            }

//            public async Task<Execution> Given(Func<Task> asyncAction)
//            {
//                await this.testSpec.Given(this.description.givens.Dequeue(), asyncAction);
//                return this;
//            }
//        }
//    }
//}
