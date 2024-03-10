using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lab1;

namespace TestProject
{
    [TestClass]
    public class ProblemTests
    {
        [TestMethod]
        public void OneValidItem_ReturnsNonEmptyResult()
        {
            
            Problem problem = new Problem(10, 123);
            int capacity = 50; // Pojemnoœæ plecaka wiêksza ni¿ waga przedmiotu

            
            Result solution = problem.Solve(capacity);

            
            Assert.IsNotNull(solution);
            Assert.IsTrue(solution.SelectedItems.Count > 0);
            Assert.IsTrue(solution.TotalValue > 0);
            Assert.IsTrue(solution.TotalWeight > 0);
        }

        [TestMethod]
        public void NoValidItem_ReturnsEmptyResult()
        {
            
            Problem problem = new Problem(3, 123);
            int capacity = 0; // Pojemnoœæ plecaka mniejsza ni¿ waga ka¿dego przedmiotu

            
            Result solution = problem.Solve(capacity);

            
            Assert.IsTrue(solution.TotalValue == 0 && solution.TotalWeight == 0);
            
        }

        [TestMethod]
        public void ItemsOrderDoesNotAffectResult()
        {
            
            Problem problem1 = new Problem(3, 123);
            Problem problem2 = new Problem(3, 123);
            int capacity = 10;
            problem2.ShuffleItems(); // Losowanie kolejnoœci przedmiotów w drugim takim samym zbiorze
            Result solution1 = problem1.Solve(capacity);
            Result solution2 = problem2.Solve(capacity);

            
            CollectionAssert.AreEqual(solution1.SelectedItems, solution2.SelectedItems);
            Assert.AreEqual(solution1.TotalValue, solution2.TotalValue);
            Assert.AreEqual(solution1.TotalWeight, solution2.TotalWeight);
        }

        [TestMethod]
        public void SpecificInstance_ReturnsCorrectResult()
        {
            
            Problem problem = new Problem(5, 123);
            int capacity = 10;

            
            Result solution = problem.Solve(capacity);

            
            Assert.IsNotNull(solution);
            Assert.AreEqual(8, solution.TotalValue); 
            Assert.AreEqual(1, solution.TotalWeight); 
        }

        [TestMethod]
        public void NoItems_EmptyResult()
        {
            
            Problem problem = new Problem(0, 123); // Brak przedmiotów
            int capacity = 10;

            
            Result solution = problem.Solve(capacity);

            
            Assert.IsNotNull(solution);
            CollectionAssert.AreEqual(new List<int>(), solution.SelectedItems); // Brak wybranych przedmiotów
            Assert.AreEqual(0, solution.TotalValue); 
            Assert.AreEqual(0, solution.TotalWeight); 
        }

        [TestMethod]
        public void SameSeed_GeneratesSameData()
        {
            
            int numberOfItems = 5;
            int seed = 123;

            
            Problem problem1 = new Problem(numberOfItems, seed);
            Problem problem2 = new Problem(numberOfItems, seed);

            
            List<Item> items1 = problem1.GetItems();
            List<Item> items2 = problem2.GetItems();

            Assert.AreEqual(items1.Count, items2.Count); // Liczba przedmiotów jest taka sama w obu problemach
            for (int i = 0; i < numberOfItems; i++)
            {
                Assert.AreEqual(items1[i].Value, items2[i].Value); 
                Assert.AreEqual(items1[i].Weight, items2[i].Weight); 
            }
        }

        [TestMethod]
        public void NumberOfItemsGenerated_EqualsNumberOfObjectsInList()
        {
            
            int numberOfItems = 5;
            int seed = 123;

            
            Problem problem = new Problem(numberOfItems, seed);

            
            Assert.AreEqual(numberOfItems, problem.GetItems().Count); // Liczba wygenerowanych przedmiotów jest równa liczbie obiektów na liœcie
        }

        [TestMethod]
        public void NoSpaceInKnapsack_NoItemsSelected()
        {
            
            Problem problem = new Problem(3, 123); 
            int capacity = 0; // Pojemnoœæ plecaka mniejsza ni¿ waga ka¿dego przedmiotu

            
            Result solution = problem.Solve(capacity);

            
            CollectionAssert.AreEqual(new List<int>(), solution.SelectedItems);
            Assert.AreEqual(0, solution.TotalValue);
            Assert.AreEqual(0, solution.TotalWeight);
        }
    }
}
