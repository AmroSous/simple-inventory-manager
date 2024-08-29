using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInventoryManagement.Services;

namespace SimpleInventoryManagement.UI
{
    public class Application(IInventory inventory)
    {
        private readonly IInventory inventory = inventory;
    }
}
