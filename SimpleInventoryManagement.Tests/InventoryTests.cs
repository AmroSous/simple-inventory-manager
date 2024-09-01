using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.Models;

namespace SimpleInventoryManagement.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void Add_Product_Test()
        {
            Inventory inventory = new();

            var p1 = new Product() { Name = "product1", Price = 49.5 };
            var p2 = new Product() { Name = "product2", Price = 5.99 };
            inventory.AddProduct(p1);
            inventory.AddProduct(p2);

            var list = inventory.GetAllProducts();
            Assert.Equal(2, list.Count);
            Assert.Equal("product1", list[0].Name);
            Assert.Equal("product2", list[1].Name);
            Assert.Equal(49.5, list[0].Price);
            Assert.Equal(5.99, list[1].Price);
        }

        [Fact]
        public void Change_Added_Instance_Of_Product_Not_Affects_Database()
        {
            Inventory inventory = new();
            var p1 = new Product() { Name = "product1", Price = 49.5 };
            inventory.AddProduct(p1);

            Assert.True(Check_Immutability(p1, inventory));
        }

        [Fact]
        public void Check_Immutability_For_Returned_Products_List()
        {
            Inventory inventory = new();
            var p1 = new Product() { Name = "product1", Price = 49.5 };
            inventory.AddProduct(p1);

            var list = inventory.GetAllProducts();
            list[0] = new() { Name = "another", Price = 399 };

            var list2 = inventory.GetAllProducts();
            var prod1 = list2[0];
            Assert.Equal("product1", prod1.Name);
            Assert.Equal(49.5, prod1.Price);
        }

        [Fact]
        public void Edit_Product_Test()
        {
            Inventory inventory = new();
            var p1 = new Product() { Name = "product1", Price = 49.5 };
            inventory.AddProduct(p1);

            Product updated = new() { Name = "product2", Price = 59.0 };
            inventory.EditProduct(p1.Name, updated);
            var notExistProduct = inventory.FindProduct("product1");
            var existProduct = inventory.FindProduct("product2");
            Assert.Null(notExistProduct);
            Assert.NotNull(existProduct);
            Assert.Equal("product2", existProduct.Name);
            Assert.Equal(59.0, existProduct.Price);
            Assert.True(Check_Immutability(updated, inventory));
        }

        [Fact]
        public void Delete_Product_Test()
        {
            Inventory inventory = new();
            var p1 = new Product() { Name = "product1", Price = 49.5 };
            inventory.AddProduct(p1);

            inventory.DeleteProduct(p1.Name);
            Product? p11 = inventory.FindProduct(p1.Name);
            Assert.Null(p11);
        }

        [Fact]
        public void Find_Product_Test()
        {
            Inventory inventory = new();
            var p1 = new Product() { Name = "product1", Price = 49.5 };
            inventory.AddProduct(p1);

            Product? p11 = inventory.FindProduct("product1");
            Assert.NotNull(p11);
            Assert.True(Check_Immutability(p11, inventory));
            Assert.Equal(p1, p11);
        }

        /**
         * this function will used in unit tests.
         * it takes a product object and IInventory instance
         * and test if changes on this object
         * will not affect the database. 
         */
        private static bool Check_Immutability(Product product, IInventory inventory)
        {
            product.AddQuantity(4);
            var data = inventory.FindProduct(product.Name);
            if (data == null) return false;
            return data.Quantity == 0;
        }
    }
}