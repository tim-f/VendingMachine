using System;

namespace VendingMachine.Core
{
    public class ProductTray
    {
        public ProductTray(Guid id, string name, decimal price, int count = 0)
        {
            Id = id;
            Name = name;
            Price = price;
            Count = count;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Count { get; private set; }
        public bool HasItems => Count > 0;

        public void TakeOne()
        {
            if (!HasItems)
            {
                throw new EmptyProductTrayException(Id, Name);
            }
            Count--;
        }
    }
}