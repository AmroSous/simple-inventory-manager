
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
        {
            return new Product() { Name = Name, Price = Price };
        }

        public bool Equals(Product? other)
        {
            if (other == null) return false;
            return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return Equals(obj as Product);
        }

        public override int GetHashCode()
        {
            return Name.ToLower().GetHashCode();
        }
    }
}
