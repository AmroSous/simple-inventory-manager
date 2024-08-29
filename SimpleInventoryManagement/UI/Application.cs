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

        private static string GetNonEmptyString (string msg)
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
