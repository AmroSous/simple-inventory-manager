using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.Models;

namespace SimpleInventoryManagement.UI
{
    public class Application(IInventory inventory)
    {
        private readonly IInventory _inventory = inventory;

        public void AddProduct()
        {
            // take product info from user
            string productName = GetNonEmptyString("Enter product name:");
            double productPrice = GetPositiveDouble("Enter product price:");

            // add product to the list
            Product product = new() { Name = productName, Price = productPrice };
            _inventory.AddProduct(product);
        }

        public void ViewAllProducts()
        {
            Console.WriteLine();
            var list = _inventory.GetAllProducts();
            if (list.Count == 0)
            {
                Console.WriteLine("There is no products.");
            }
            else 
            {
                int count = 1;
                foreach (var product in list)
                {
                    Console.WriteLine($"{count++}: {product}");
                }
            }
            Console.WriteLine();
        }

        private static string GetNonEmptyString(string msg)
        {
            string? input = null; 
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write($"{msg} ");
                input = Console.ReadLine();
            }
            return input;
        }

        private static double GetPositiveDouble(string msg)
        {
            string? input = null;
            double value;
            while (!double.TryParse(input, out value) || value < 0.0)
            {
                Console.Write($"{msg} ");
                input = Console.ReadLine();
            }
            return value;
        }
    }
}
