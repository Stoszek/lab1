using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyrzykowski_item
{
    internal class Item
    {
        public int Value = 0;
        public int Weight = 0;
        public double ValueByWeight;

        public Item(int value, int weight)
        {
            Value = value;
            Weight = weight;
            ValueByWeight = value/weight;
        }

    }

}
