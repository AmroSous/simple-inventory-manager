using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.Models;
using SimpleInventoryManagement.Util;

namespace SimpleInventoryManagement.UI
{
    /**
     * This class defines the user interface methods to 
     * deal with management system. 
     * 
     * defines the interactive process with user to take inputs 
     * from console and print outputs.
     */
    public sealed class Application(IInventory inventory)
    {
        /**
         * this object is an instance of IInventory interface 
         * it is injected using constructer and cannot be change.
         */
        private readonly IInventory _inventory = inventory;
        
        
        public void AddProduct()
        {
            // take product info from user
            string productName = IO.ReadNotNull("Enter product name: ");
            double productPrice = IO.ReadNonNegativeDouble("Enter product price: ", false) ?? -1;

            // add product to the list
            Product product = new() { Name = productName, Price = productPrice };
            _inventory.AddProduct(product);
            IO.Log("Product added successfully.\n", LogType.Success);
        }


        public void ViewAllProducts()
        {
            Console.WriteLine();
            var list = _inventory.GetAllProducts();
            if (list.Count == 0)
            {
                IO.Log("There is no products.\n", LogType.Fail);
            }
            else 
            {
                int count = 1;
                foreach (var product in list)
                {
                    IO.Log($"{count++}: {product}\n", LogType.Success);
                }
            }
            Console.WriteLine();
        }


        public void EditProduct()
        {
            string name = IO.ReadNotNull("Enter product name to update: ");
            var product = _inventory.FindProduct(name);
            if (product == null)
                throw new InvalidOperationException("Product not found.");

            string newName = IO.Read($"Enter new name: ({name}) ") ?? name;
            double newPrice = IO.ReadNonNegativeDouble($"Enter new price: ({product.Price}) ", true) ?? product.Price;

            Product updated = new() { Name = newName, Price = newPrice };
            _inventory.EditProduct(name, updated);

            IO.Log("Updated successfully.\n", LogType.Success);
        }

        public void DeleteProduct()
        {
            string name = IO.ReadNotNull("Enter product name: ");
            if (_inventory.FindProduct(name) == null)
                throw new InvalidOperationException("Product not found.");

            IO.Log("Are you sure you want to delete this product ? (y/n) ", LogType.Warning);
            string input = IO.Read() ?? "n";
            input = input.ToLower();
            if (input.Equals("y"))
            {
                _inventory.DeleteProduct(name);
                IO.Log("Deleted successfully.\n", LogType.Success);
            }
            else
            {
                throw new OperationAbortedException();
            }
        }

        public void FindProduct()
        {
            string name = IO.ReadNotNull("Enter name of product: ");
            var product = _inventory.FindProduct(name);
            IO.Log($"{product}\n", LogType.Success);
        }
    }
}
