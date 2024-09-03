
namespace SimpleInventoryManagement.Models
{
    public class Product : ICloneable, IEquatable<Product>
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
            => new Product() { Name = Name, Price = Price };

        public bool Equals(Product? other)
            => other != null && Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);

        public override bool Equals(object? obj)
            => obj != null && GetType() == obj.GetType() && Equals(obj as Product);

        public override int GetHashCode()
            => Name.ToLower().GetHashCode();
    }
}
