using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wyrzykowski_item;

namespace Wyrzykowski_problem
{
    internal class Problem
    {
        public int n { get; set; }  
        public int seed { get; set; }
        public List<Item> items;
        public Problem(int n, int seed)
        {
            this.n = n;
            Random rand = new Random(seed);
            items = new List<Item>();
            for (int i = 0; i < n; i++) 
            {
                items[i].Value = rand.Next(1,11);
                items[i].Weight = rand.Next(1, 11);
                Console.WriteLine(items[i].ValueByWeight);
            }
        }
        static void Main()
        {
            Problem x = new Problem(10, 200);
            
        }

    }
    
}
