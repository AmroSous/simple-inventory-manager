using SimpleInventoryManagement.Models;

namespace SimpleInventoryManagement.Services
{
    /**
     * This is an interface for Inventory implementations 
     * this interface defines the main functionality that 
     * Inventory class should implement to use it in application. 
     * 
     * in this way we decouple the implementation of inventory class
     * from the client code in Application class, so that we can 
     * enhance the application in future by extending another implementation 
     * for this class.
     */
    public interface IInventoryService
    {
        /**
         * Add product function must take a product instance 
         * as parameter and add it to the products database. 
         */
        void AddProduct(Product product);

        /**
         * to delete a product from database. 
         * item is specified using its name as parameter.
         * if the item not exist nothing happen.
         */
        void DeleteProduct(string name);

        /**
         * find a product in database using its name 
         * and return a copy of this product to prevent
         * illegal update on database.
         * if the product does not exist return null
         */
        Product? FindProduct(string name);

        /**
         * return all products in database as a List
         * all products returned are copy for security.
         */
        List<Product> GetAllProducts();

        /**
         * to edit existing product. 
         * name: the name of product to be updated. 
         * updated: new version of this product.
         * 
         * if product not found nothing happend.
         */
        void EditProduct(string name, Product updated);
    }
}
