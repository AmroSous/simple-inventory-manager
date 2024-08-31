using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.UI;

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
            int op;
            do
            {
                op = ShowMenu();
                switch (op)
                {
                    case 1: 
                        app.AddProduct(); break;
                    case 2:
                        app.EditProduct(); break;
                    case 3:
                        app.DeleteProduct(); break;
                    case 4:
                        app.FindProduct(); break;
                    case 5:
                        app.ViewAllProducts(); break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid operation."); break;
                }

            } while (op != 6);

            Console.WriteLine();
            Console.WriteLine("Good bye .. ");
            Console.ReadLine();
        }


        /**
         * Show welcome message
         * exits when user enter any key.
         */
        static void ShowWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("""
                               
                            ░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗
                            ░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝
                            ░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░
                            ░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░
                            ░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗
                            ░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝

                """);
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("""
                Welcome to our first version of Simple Inventory Management System. 
                this application used to track number of products in inventory using 
                friendly console interface. 

                """);
            Console.ResetColor();

            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("Enter any key to start the application.. ");
            Console.ResetColor();
            Console.ReadLine();
        }

        /**
         * this function show a menu with supported operations 
         * and prompt the user to number of operation and returned it. 
         * if user enter invalid number then return -1.
         */
        private static int ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("""
                ────────────────────────────────────────────────────────

                        ╔═══════════ ≪ Menu ≫ ══════════╗
                        ║                               ║
                        ║    1- Add product.            ║
                        ║    2- Edit product.           ║
                        ║    3- Delete product.         ║
                        ║    4- Find product.           ║
                        ║    5- View all products.      ║
                        ║    6- Exit.                   ║
                        ║                               ║
                        ╚═══════════ ^^^^^^^ ═══════════╝

                """);

            Console.Write("Enter the number of requested operation: ");
            Console.ResetColor();
            string? input = Console.ReadLine();
            return int.TryParse(input, out int choice) 
                && choice >= 1 && choice <= 6 ? choice : -1;
        }
    }
}