using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.UI;

namespace SimpleInventoryManagement
{
    internal class MainDriver
    {
        internal static void Main()
        {
            IInventoryService service = new InventoryService();
            Application app = new(service);
            app.Start();
        }
    }
}