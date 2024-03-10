using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("TestProject")]
namespace lab1
{
    internal class Result
    {
        public List<int> SelectedItems { get; set; }
        public int TotalValue { get; set; }
        public int TotalWeight { get; set; }

        public override string ToString()
        {
            return $"Selected items: {string.Join(", ", SelectedItems)}, Total value: {TotalValue}, Total weight: {TotalWeight}";
        }
    }
}
