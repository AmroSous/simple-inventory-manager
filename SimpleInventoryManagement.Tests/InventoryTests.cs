using SimpleInventoryManagement.Services;
using SimpleInventoryManagement.Models;

namespace SimpleInventoryManagement.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void AddProductTest()
        {
            IInventory inventory = new Inventory();

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
    }
}