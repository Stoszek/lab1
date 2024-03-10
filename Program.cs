using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using lab1;
[assembly: InternalsVisibleTo("TestProject")]
class Program
{
    static void Main(string[] args)
    {
        int seed = 123; // ziarno losowania
        Problem problem = new Problem(5, seed);
        Console.WriteLine("Przedmioty:");
        Console.WriteLine(problem);

        int capacity = 20; // Pojemność plecaka

        Result result = problem.Solve(capacity);

        Console.WriteLine($"\nRozwiązanie dla plecaka o pojemności {capacity}:");
        Console.WriteLine(result);
    }
}
