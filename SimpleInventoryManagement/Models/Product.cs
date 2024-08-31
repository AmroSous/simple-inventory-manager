
namespace SimpleInventoryManagement.Models
{
    public class Product : ICloneable
    {
        public required string Name { get; init; }

        public required double Price { get; init; }

        public int Quantity { get; private set; }


        public void AddQuantity(int quantity)
            => Quantity += quantity;

        public void RemoveQuantity(int quantity)
            => Quantity -= quantity;

        public override string ToString()
            => $"Product {{ Name: {Name}, Price: {Price}, Quantity: {Quantity} }}";

        public object Clone()
        {
            return new Product() { Name = Name, Price = Price };
        }
    }
}
