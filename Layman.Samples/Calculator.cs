/*
 * This sample was adopted from SpecFlow's getting-started guide: http://www.specflow.org/getting-started/
 */
namespace Layman.Samples
{
    class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
    }
}
