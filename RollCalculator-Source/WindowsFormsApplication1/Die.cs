using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCalculator
{
    class Die
    {
        private Random result = new Random();
        private int x;
        protected StringBuilder outputString = new StringBuilder();

        public int Roll(int d)
        {
            x = result.Next(1, d+1);
            outputString.Append(x);
            return x;
        }
        public string OutputString()
        {
            return outputString.ToString();
        }
    } 
}
