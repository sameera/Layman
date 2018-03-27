using System.Diagnostics;
using Xunit.Abstractions;

namespace Layman
{
    class DebugOutputHelper : ITestOutputHelper
    {
        public void WriteLine(string message)
        {
            Debug.WriteLine(message);
        }

        public void WriteLine(string format, params object[] args)
        {
            Debug.WriteLine(format, args);
        }
    }
}
