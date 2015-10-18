using System;

namespace VendingMachine.Core
{
    public sealed class NotSupportedValueException : Exception
    {
        public decimal Value { get; }

        public NotSupportedValueException(decimal value)
        {
            Value = value;
        }

        public override string Message => $"Not supported coin value: '{Value}'.";
    }
}