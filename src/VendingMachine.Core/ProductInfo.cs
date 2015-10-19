using System;

namespace VendingMachine.Core
{
    public class ProductInfo
    {
        internal ProductInfo(Guid id, string name, decimal price, int count)
        {
            Id = id;
            Name = name;
            Price = price;
            Count = count;
        }

        public Guid Id { get; }

        public string Name { get; }

        public decimal Price { get; }
        public int Count { get; }
    }
}