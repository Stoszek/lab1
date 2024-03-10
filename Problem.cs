using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("TestProject")]
namespace lab1
{
    internal class Problem
    {
        private List<Item> items;
        private Random rand;

        public Problem(int n, int seed)
        {
            items = new List<Item>();
            rand = new Random(seed);

            for (int i = 0; i < n; i++)
            {
                items.Add(new Item
                {
                    Value = rand.Next(1, 11), // wartość przedmiotu z zakresu [1, 10]
                    Weight = rand.Next(1, 11) // waga przedmiotu z zakresu [1, 10]
                });
            }
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public void ShuffleItems()
        {
            items = items.OrderBy(x => rand.Next()).ToList();
        }

        public Result Solve(int capacity)
        {
            items = items.OrderByDescending(x => (double)x.Value / x.Weight).ToList();
            List<int> selectedItems = new List<int>();
            int totalValue = 0;
            int totalWeight = 0;

            foreach (var item in items)
            {
                if (totalWeight + item.Weight <= capacity)
                {
                    selectedItems.Add(items.IndexOf(item) + 1); 
                    totalValue += item.Value;
                    totalWeight += item.Weight;
                }
                else
                {
                    break;
                }
            }

            return new Result
            {
                SelectedItems = selectedItems,
                TotalValue = totalValue,
                TotalWeight = totalWeight
            };
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, items.Select((item, index) => $"Item {index + 1}: {item}"));
        }
    }
}
