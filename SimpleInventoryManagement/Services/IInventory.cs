using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInventoryManagement.Models;

namespace SimpleInventoryManagement.Services
{
    public interface IInventory
    {
        void AddProduct(Product product);
        void DeleteProduct(string name);
        Product FindProduct(string name);
        List<Product> GetAllProducts();
        void EditProduct(string name, Product updated);
    }
}
