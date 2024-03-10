using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("TestProject")]
namespace lab1
{
    internal class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"Value: {Value}, Weight: {Weight}";
        }
    }
}
