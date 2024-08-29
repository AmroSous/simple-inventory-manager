using SimpleInventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagement.Services
{
    public class Inventory : IInventory
    {
        private readonly List<Product> products = [];

        public void AddProduct(Product product)
        {
            if (product != null) products.Add(product);
        }

        public void DeleteProduct(string name)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(string name, Product updated)
        {
            throw new NotImplementedException();
        }

        public Product FindProduct(string name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
