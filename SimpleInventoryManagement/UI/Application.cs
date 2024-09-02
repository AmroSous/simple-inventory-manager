using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.Models;
using SimpleInventoryManagement.Util;
using static SimpleInventoryManagement.UI.MessageDisplayHelper;

namespace SimpleInventoryManagement.UI
{
    /**
     * This class defines the user interface methods to 
     * deal with management system. 
     * 
     * defines the interactive process with user to take inputs 
     * from console and print outputs.
     */
    public sealed class Application(IInventoryService inventory)
    {
        /**
         * this is a readonly instance of IInventoryService interface 
         * injected by constructer.
         */
        private readonly IInventoryService _inventory = inventory;


        /**
         * this method invoked to start the application. 
         */
        public void Start()
        {
            ShowWelcomeMessage();
            ShowAppCommands();
            PressToContinue();

            int operation = -1;
            while (operation != 6)
            {
                try
                {
                    ShowMenu();
                    operation = GetUserOperation();
                    Console.WriteLine();
                    ExecuteOperation(operation);
                }
                catch (OperationAbortedException)
                {
                    HandleOperationAborted();
                }
                catch (InvalidOperationException ex)
                {
                    HandleInvalidOperation(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralException(ex);
                }
            }

            ShowGoodByeMessage();
            PressToContinue();
        }

        private void AddProduct()
        {
            var product = new Product
            {
                Name = ConsoleIO.ReadNotNull("Enter product name: "),
                Price = ConsoleIO.ReadNonNegativeDouble("Enter product price: ", false) ?? -1
            };

            _inventory.AddProduct(product);
            ConsoleIO.Log("Product added successfully.\n", ConsoleColorType.Success);
        }


        private void ViewAllProducts()
        {
            var list = _inventory.GetAllProducts();
            if (list.Count == 0)
            {
                ConsoleIO.Log("There is no products.\n", ConsoleColorType.Failure);
            }
            else 
            {
                int count = 1;
                foreach (var product in list)
                {
                    ConsoleIO.Log($"{count++}: {product}\n", ConsoleColorType.Success);
                }
            }
        }


        private void EditProduct()
        {
            string name = ConsoleIO.ReadNotNull("Enter product name to update: ");
            var product = _inventory.FindProduct(name) ?? throw new InvalidOperationException("Product not found.");
            
            var updated = new Product
            {
                Name = ConsoleIO.Read($"Enter new name: ({name}) ") ?? name,
                Price = ConsoleIO.ReadNonNegativeDouble($"Enter new price: ({product.Price}) ", true) ?? product.Price
            };

            _inventory.EditProduct(name, updated);
            ConsoleIO.Log("Updated successfully.\n", ConsoleColorType.Success);
        }

        private void DeleteProduct()
        {
            string name = ConsoleIO.ReadNotNull("Enter product name: ");
            if (_inventory.FindProduct(name) == null)
                throw new InvalidOperationException("Product not found.");

            string input = ConsoleIO.Read("Are you sure you want to delete this product ? (y/n) ", ConsoleColorType.Warning) ?? "n";
            if (input.ToLower().Equals("y"))
            {
                _inventory.DeleteProduct(name);
                ConsoleIO.Log("Deleted successfully.\n", ConsoleColorType.Success);
            }
            else
            {
                throw new OperationAbortedException();
            }
        }

        private void FindProduct()
        {
            string name = ConsoleIO.ReadNotNull("Enter name of product: ");
            var product = _inventory.FindProduct(name);
            ConsoleIO.Log($"{product}\n", ConsoleColorType.Success);
        }

        /**
         * take integer value (operation number) from user
         */
        private static int GetUserOperation()
        {
            string? input = ConsoleIO.Read("Enter operation number: ", ConsoleColorType.Help);
            if (int.TryParse(input, out int operation)) return operation;
            return -1;
        }

        /**
         * take operation number as param 
         * and perform the coressponding operation.
         */
        private void ExecuteOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    EditProduct();
                    break;
                case 3:
                    DeleteProduct();
                    break;
                case 4:
                    FindProduct();
                    break;
                case 5:
                    ViewAllProducts();
                    break;
                case 7:
                    Console.Clear();
                    return;
                case 6:
                    return; // Exit
                default:
                    ConsoleIO.Log("Invalid operation.", ConsoleColorType.Warning);
                    break;
            }
            PressToContinue();
        }

        private static void HandleOperationAborted()
        {
            ConsoleIO.Log("Operation aborted.\n", ConsoleColorType.Information);
        }

        private static void HandleInvalidOperation(InvalidOperationException ex)
        {
            ConsoleIO.Log($"{ex.Message}\n", ConsoleColorType.Failure);
        }

        private static void HandleGeneralException(Exception ex)
        {
            ConsoleIO.Log($"{ex.Message}\n", ConsoleColorType.Error);
        }
    }
}
