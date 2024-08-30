using SimpleInventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagement.Services
{
    /**
     * This Inventory class is an implementation of IInventory interface 
     * 
     * this class uses a private data structure to store products in memory 
     * temporarily and perform operations on them. 
     * 
     * if the program terminated the changes made no longer exists.
     */
    public class Inventory : IInventory
    {
        /**
         * private List data structure to store products 
         * and make operations on it. 
         */
        private readonly List<Product> _products = [];

        /**
         * 
         * take a product param and store a copy of it 
         * in _products list. 
         * if passed products was null nothing happen.
         */
        public void AddProduct(Product product)
        {
            if (product != null) _products.Add(product.Clone());
        }

        public void DeleteProduct(string name)
        {
            int index = -1;
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Name == name)
                {
                    index = i;
                    break; 
                }
            }
            if (index != -1) _products.RemoveAt(index);
        }

        /**
         * 
         * Find the product with specified name in list. 
         * if it exist then replace it with a copy of passed product.
         */
        public void EditProduct(string name, Product updated)
        {
            int index = -1; 
            for (int i = 0; i <  _products.Count; i++)
            {
                if (_products[i].Name.Equals(name))
                {
                    index = i;
                    break; 
                }
            }
            if (index != -1) _products[index] = updated.Clone();
        }

        public Product? FindProduct(string name)
        {
            foreach (var p in  _products)
            {
                if (p.Name.Equals(name)) return p.Clone();
            }
            return null;
        }

        /**
         * 
         * this method returns a deeply copied list of 
         * all products in products list.
         */
        public List<Product> GetAllProducts()
        {
            List<Product> copy = [];
            foreach (Product product in _products) { copy.Add(product.Clone()); }
            return copy;
        }
    }
}
