using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.UI;
using SimpleInventoryManagement.Util;

namespace SimpleInventoryManagement
{
    internal class MainDriver
    {
        /**
         * Entry point for our application. 
         * show welcome message and start taking inputs 
         * from user, to provide the requested service.
         */
        static void Main()
        {
            // create instance of Inventory
            IInventory inventory = new Inventory();
            // create Application object and inject inventory into it.
            Application app = new(inventory);
            
            ShowWelcomeMessage();

            // taking inputs from user and perform operation required.
            int op = 0;
            do
            {
                try
                {
                    op = ShowMenu();
                    switch (op)
                    {
                        case 1: 
                            app.AddProduct();
                            PressToContinue();
                            break;
                        case 2:
                            app.EditProduct();
                            PressToContinue();
                            break;
                        case 3:
                            app.DeleteProduct();
                            PressToContinue();
                            break;
                        case 4:
                            app.FindProduct();
                            PressToContinue();
                            break;
                        case 5:
                            app.ViewAllProducts();
                            PressToContinue();
                            break;
                        case 6:
                            break;
                        case 7:
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Invalid operation."); 
                            break;
                    }
                }
                catch (OperationAbortedException)
                {
                    IO.Log("Operation aborted.\n", ConsoleColorType.Information);
                }
                catch (InvalidOperationException ex)
                {
                    IO.Log($"{ex.Message}\n", ConsoleColorType.Failure);
                }
                catch (Exception ex)
                {
                    IO.Log($"{ex.Message}\n", ConsoleColorType.Error);
                }

            } while (op != 6);

            IO.Log("""

                        Good bye ..

                """, ConsoleColorType.Information);
            Console.ReadLine();
        }


        /**
         * Show welcome message
         * exits when user enter any key.
         */
        static void ShowWelcomeMessage()
        {
            IO.Log("""
                               
                            ░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗
                            ░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝
                            ░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░
                            ░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░
                            ░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗
                            ░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝



                """, ConsoleColorType.Information);

            IO.Log("""
                            Welcome to our first version of Simple Inventory Management System. 
                            this application used to track number of products in inventory using 
                            friendly console interface. 

                            commands: 
                                - (NEW) you can use --abort command to abort current process and return 
                                  to the main menu. 


                """, ConsoleColorType.Success);

            IO.Log("Enter any key to start the application.. ", ConsoleColorType.Default);
            Console.ReadLine();
        }

        /**
         * this function show a menu with supported operations 
         * and prompt the user to number of operation and returned it. 
         * if user enter invalid number then return -1.
         */
        private static int ShowMenu()
        {
            IO.Log("""
                ────────────────────────────────────────────────────────

                        ╔═══════════ ≪ Menu ≫ ══════════╗
                        ║                               ║
                        ║    1- Add product.            ║
                        ║    2- Edit product.           ║
                        ║    3- Delete product.         ║
                        ║    4- Find product.           ║
                        ║    5- View all products.      ║
                        ║    6- Exit.                   ║
                        ║    7- Clear console.          ║
                        ║                               ║
                        ╚═══════════ ^^^^^^^ ═══════════╝


                """, ConsoleColorType.Warning);

            IO.Log("Enter the number of requested operation: ", ConsoleColorType.Default);
            string? input = Console.ReadLine();
            return int.TryParse(input, out int choice) 
                && choice >= 1 && choice <= 7 ? choice : -1;
        }

        private static void PressToContinue()
        {
            IO.Log("Press to continue.. ", ConsoleColorType.Information);
            Console.ReadLine();
        }
    }
}