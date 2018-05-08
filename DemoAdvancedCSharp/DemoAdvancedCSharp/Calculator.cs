using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAdvancedCSharp
{
    class Calculator
    {
        public int Add(int x, int y)
        {
            Thread.Sleep(x * 1000);
            return x + y;
        }

        public Task<int> AddAsync(int x, int y)
        {
            // Same as the Add function but now in the background, so not blocking
            var t = new Task<int>(() => Add(x, y));
            t.Start();
            return t;
        }
    }
}
