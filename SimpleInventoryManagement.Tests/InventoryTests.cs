using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.Models;

namespace SimpleInventoryManagement.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void AddProductTest()
        {
            Inventory inventory = new();

            var p1 = new Product() { Name = "product1", Price = 49.5 };
            var p2 = new Product() { Name = "product2", Price = 5.99 };

            inventory.AddProduct(p1);
            inventory.AddProduct(p2);

            var list = inventory.GetAllProducts();
            Assert.Equal(2, list.Count);
            
            var prod1 = list[0];
            var prod2 = list[1];
            Assert.Equal("product1", prod1.Name);
            Assert.Equal("product2", prod2.Name);
            Assert.Equal(49.5, prod1.Price);
            Assert.Equal(5.99, prod2.Price);
        }

        [Fact]
        public void Change_Added_Instance_Of_Product_Not_Affects_Database()
        {
            Inventory inventory = new();
            var p1 = new Product() { Name = "product1", Price = 49.5 };
            inventory.AddProduct(p1);

            p1.AddQuantity(5);

            var list = inventory.GetAllProducts();
            var prod1 = list[0];
            Assert.Equal(0, prod1.Quantity);
        }

        [Fact]
        public void CheckImmutabilityForReturnedProductsList()
        {
            Inventory inventory = new();
            var p1 = new Product() { Name = "product1", Price = 49.5 };
            var p2 = new Product() { Name = "product2", Price = 5.99 };
            inventory.AddProduct(p1);
            inventory.AddProduct(p2);

            var list = inventory.GetAllProducts();
            list[0].AddQuantity(3);
            list[1] = new() { Name = "another", Price = 399 };

            var list2 = inventory.GetAllProducts();
            Assert.Equal(2, list2.Count);
            var prod1 = list2[0];
            var prod2 = list2[1];
            Assert.Equal("product2", prod2.Name);
            Assert.Equal(5.99, prod2.Price);
            Assert.Equal(0, prod1.Quantity);
        }
    }
}