using System;

namespace VendingMachine.Core
{
    public class EmptyProductTrayException : Exception
    {
        public EmptyProductTrayException(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; }

        public Guid Id { get; }
    }
}