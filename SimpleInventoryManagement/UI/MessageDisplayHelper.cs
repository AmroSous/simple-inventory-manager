using SimpleInventoryManagement.Util;

namespace SimpleInventoryManagement.UI
{
    public static class MessageDisplayHelper
    {
        /**
         * Show greating messages
         * to the application
         */
        public static void ShowWelcomeMessage()
        {
            ConsoleIO.Log("""
                               
                            ░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗
                            ░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝
                            ░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░
                            ░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░
                            ░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗
                            ░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝


                """, ConsoleColorType.Help);

            ConsoleIO.Log("""
                            Welcome to our Simple Inventory Management System. 
                            this application used to track number of products in inventory using 
                            friendly console interface. 
                """, ConsoleColorType.Success);
        }

        public static void ShowAppCommands()
        {
            ConsoleIO.Log("""


                            Instructions: 

                                - (NEW) you can use --abort command to abort current process 
                                        and return to the main menu.
                """, ConsoleColorType.Important);
        }

        /**
         * this function show a menu with supported operations 
         */
        public static void ShowMenu()
        {
            ConsoleIO.Log("""
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
        }

        /**
         * show message when user exit the program.
         */
        public static void ShowGoodByeMessage()
        {
            ConsoleIO.Log("""

                        Good bye ..
                """, ConsoleColorType.Success);
        }

        /**
         * pause the application until user press key.
         */
        public static void PressToContinue()
        {
            Console.WriteLine();
            ConsoleIO.LogPrompt("Press to continue.. ", ConsoleColorType.Information);
            Console.ReadLine();
        }
    }
}
