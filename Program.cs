using System;
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

            SelectEverything(itemsInStock);
            ListProductNames(itemsInStock);
            GetOverstock(itemsInStock);
            GetNamesAndDescriptions(itemsInStock);

            Array objs = GetProjectedSubset(itemsInStock);
            foreach (object o in objs)
                Console.WriteLine(o);

            GetCountFromQuery();

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
    }
}
