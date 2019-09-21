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

            Console.ReadLine();
        }

        static void SelectEverything(ProductInfo[] products)
        {
            Console.WriteLine("All product details:");
            var allProducts = from p in products select p;
            foreach (var prod in allProducts)
                Console.WriteLine(prod.ToString());
        }
    }
}
