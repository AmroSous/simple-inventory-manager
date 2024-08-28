﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagement.Entities
{
    public class Product
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
    }
}
