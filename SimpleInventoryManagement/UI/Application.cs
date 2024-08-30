using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.Models;

namespace SimpleInventoryManagement.UI
{
    /**
     * This class defines the user interface methods to 
     * deal with management system. 
     * 
     * defines the interactive process with user to take inputs 
     * from console and print outputs.
     */
    public class Application(IInventory inventory)
    {
        /**
         * this object is an instance of IInventory interface 
         * it is injected using constructer and cannot be change.
         */
        private readonly IInventory _inventory = inventory;
        
        
        public void AddProduct()
        {
            // take product info from user
            string productName = GetNonEmptyString("Enter product name:");
            double productPrice = GetNonNegativeDouble("Enter product price:");

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


        public void EditProduct()
        {
            string name = GetNonEmptyString("Enter product name to update:");
            var product = _inventory.FindProduct(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            string? newName = GetNullableInput($"Enter new name: ({name})");
            double? newPrice = GetNullableNonNegativeDouble($"Enter new price: ({product.Price})");

            Product updated = new() { Name = newName ?? name, Price = newPrice ?? product.Price };
            _inventory.EditProduct(name, updated);

            Console.WriteLine("Updated successfully.");
        }

        public void DeleteProduct()
        {
            string name = GetNonEmptyString("Enter product name:");
            if (_inventory.FindProduct(name) == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                Console.Write("Are you sure you want to delete this product ? (y/n) ");
                string input = Console.ReadLine() ?? "y";
                if (string.IsNullOrWhiteSpace(input))  input = "y";
                input = input.ToLower();
                if (input.Equals("y"))
                {
                    _inventory.DeleteProduct(name);
                    Console.WriteLine("Deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Operation aborted.");
                }
            }
        }

        /**
         * utility method that
         * prompt the user to enter a string or null.
         */
        private static string? GetNullableInput(string msg)
        {
            Console.Write($"{msg} ");
            string? input = Console.ReadLine();
            return (string.IsNullOrWhiteSpace(input) ? null : input);
        }

        /**
         * utility method to
         * prompt the user to enter positive double 
         * or null
         */
        private static double? GetNullableNonNegativeDouble(string msg)
        {
            Console.Write($"{msg} ");
            string? input = Console.ReadLine();
            double value = 0.0;
            while (!string.IsNullOrWhiteSpace(input) && (!double.TryParse(input, out value) || value < 0)) 
            {
                Console.Write($"{msg} ");
                input = Console.ReadLine();
            }
            if (string.IsNullOrWhiteSpace(input)) return null; 
            return value;
        }

        /**
         * this is a utility method to take a non empty string 
         * from the user. 
         * if user enter empty or white spaces it will prompt the user 
         * again with a message to enter value.
         */
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

        /**
         * this is a utility method to take a non positive double 
         * alue from the user.
         * it prompt the user with a message and reads input. 
         * if input is negative or null it will replay the process.
         */
        private static double GetNonNegativeDouble(string msg)
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
