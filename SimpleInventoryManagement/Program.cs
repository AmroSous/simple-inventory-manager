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

            // TODO: start taking inputs.
        }


        /**
         * Show welcome message
         * exits when user enter any key.
         */
        static void ShowWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("""
                               
                ░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗
                ░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝
                ░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░
                ░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░
                ░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗
                ░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝

                """);
            Console.WriteLine();

            Console.ResetColor();
            Console.WriteLine("This app is under development .. ");
            Console.WriteLine("wait for the first version SOON ..");
            Console.WriteLine();
            Console.Write("Enter any key to exit. "); 
            Console.ReadLine();
        }
    }
}