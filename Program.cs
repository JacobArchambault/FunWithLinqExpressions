using System;
using System.Collections.Generic;
using System.Linq;

namespace FunWithLinqExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Query Expressions *****");

            // This array will be the basis of our testing...
            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo{Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24 },
                new ProductInfo{Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100 },
                new ProductInfo{Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120 },
                new ProductInfo{Name = "Cruncy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2 },
                new ProductInfo{Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100 },
                new ProductInfo{Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", NumberInStock = 73 },
            };
            // The Simplest LINQ query.
            SelectEverything(itemsInStock);

            // Queries for only select fields.
            ListProductNames(itemsInStock);
            GetNamesAndDescriptions(itemsInStock);

            // Query with a where clause
            GetOverstock(itemsInStock);

            // Query making use of conversion to array.
            Array objs = GetProjectedSubset(itemsInStock);
            foreach (object o in objs)
                Console.WriteLine(o);
            

            // Queries involving ordering:
            ReverseEverything(itemsInStock);
            AlphabetizeProductNames(itemsInStock);

            // Venn diagram operations.
            DisplayDiff();
            DisplayIntersection();
            DisplayUnion();

            // Concatenations.
            DisplayConcat();
            DisplayConcatNoDups();

            // Aggregation operations.
            GetCountFromQuery();
            AggregateOps();

            Console.ReadLine();
        }

        static void SelectEverything(ProductInfo[] products)
        {
            Console.WriteLine("All product details:");
            var allProducts = from p in products select p;
            foreach (var prod in allProducts)
                Console.WriteLine(prod.ToString());
        }
        static void ListProductNames(ProductInfo[] products)
        {
            // Now get only the names of the products.
            Console.WriteLine("Only product names:");
            var names = from p in products select p.Name;

            foreach (var n in names)
                Console.WriteLine($"Name: {n}");
        }
        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items:");

            // Get only the items where we have more than 25 in stock.
            var overstock = from p in products where p.NumberInStock > 25 select p;
            foreach (ProductInfo c in overstock)
                Console.WriteLine(c.ToString());
        }
        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };

            foreach (var item in nameDesc)
                Console.WriteLine(item.ToString());
        }
        static Array GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };
            // Map set of anonymous objects to an Array object.
            return nameDesc.ToArray();
        }
        static void GetCountFromQuery()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Get count from the query.
            int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();

            // Print out the number of items.
            Console.WriteLine("{0} items honor LINQ query.", numb);
        }
        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Products in reverse:");
            var allProducts = from p in products select p;
            foreach (var prod in allProducts.Reverse())
                Console.WriteLine(prod.ToString());
        }
        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            // Get names of products, alphabetized.
            var subset = from p in products orderby p.Name select p;

            Console.WriteLine("Ordered by Name:");
            foreach (var p in subset)
                Console.WriteLine(p.ToString());
        }
        static void DisplayDiff()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);

            Console.WriteLine("Here is what I have but you don't");
            foreach(string s in carDiff)
                Console.WriteLine(s); // Prints Yugo
        }
        static void DisplayIntersection()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            // Get common members.
            var carIntersect = (from c in myCars select c).Intersect(from c2 in yourCars select c2);

            Console.WriteLine("Here is what we have in common");
            foreach (string s in carIntersect)
                Console.WriteLine(s); // Prints Aztec and BMW
        }
        static void DisplayUnion()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            // Get common members.
            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);

            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
                Console.WriteLine(s); // Prints Aztec and BMW
        }
        static void DisplayConcat()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            // Get common members.
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);

            Console.WriteLine("Here is our list of cars concatenated");
            foreach (string s in carConcat)
                Console.WriteLine(s); // Prints Aztec and BMW
        }
        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            // Get common members.
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);

            Console.WriteLine("Here is our list of cars concatenated with duplicates removed:");
            foreach (string s in carConcat.Distinct())
                Console.WriteLine(s); // Prints Aztec and BMW
        }
        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            // Various aggregation examples.
            Console.WriteLine("Max temp: {0}", (from t in winterTemps select t).Max());
            Console.WriteLine("Min temp: {0}", (from t in winterTemps select t).Min());
            Console.WriteLine("Average temp: {0}", (from t in winterTemps select t).Average());
            Console.WriteLine("Sum of all temps: {0}", (from t in winterTemps select t).Sum());
        }
    }
}
