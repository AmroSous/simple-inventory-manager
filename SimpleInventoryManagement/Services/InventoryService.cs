using SimpleInventoryManagement.Models;

namespace SimpleInventoryManagement.Services
{
    /**
     * This Inventory class is an implementation of IInventoryService interface 
     * 
     * this class uses a private data structure to store products in
     * volotaile memory and perform operations on them. 
     */
    public class InventoryService : IInventoryService
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
         * if passed products was null or
         * if product already exist it throws
         * InvalidOperationException("Product already exist.");
         */
        public void AddProduct(Product product)
        {
            if (product == null || _products.Contains(product)) 
                throw new InvalidOperationException("Product already exist.");
            else
                _products.Add((Product)product.Clone());
        }

        /**
         * 
         * take product name and delete it from the list. 
         * if the product does not exist throw 
         * InvalidOperationException("Product not found.");
         */
        public void DeleteProduct(string name)
        {
            var product = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) 
                ?? throw new InvalidOperationException("Product not found.");
            _products.Remove(product);
        }

        /**
         * 
         * Find the product with specified name in list. 
         * if it exist then replace it with a copy of passed product.
         * if not throw InvalidOperationException()
         */
        public void EditProduct(string name, Product updated)
        {
            int index = _products.FindIndex(p => p.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
            if (index == -1) throw new InvalidOperationException("Product not found.");
            _products[index] = (Product)updated.Clone();
        }

        /**
         * 
         * search for a product in the products list 
         * by name, and return copy of this product.
         * if product does not exist return null
         */
        public Product FindProduct(string name)
        {
            var product = _products.FirstOrDefault(
                p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidOperationException("Product not found.");
            return (Product)product.Clone();
        }

        /**
         * 
         * this method returns a deeply copied list of 
         * all products in products list.
         */
        public List<Product> GetAllProducts()
        {
            List<Product> copy = [];
            foreach (Product product in _products) { copy.Add((Product)product.Clone()); }
            return copy;
        }
    }
}
