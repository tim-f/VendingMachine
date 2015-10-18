using System;

namespace VendingMachine.Core
{
    public class Coin : IEquatable<Coin>
    {
        public decimal Value { get; }

        private Coin(decimal value)
        {
            Value = value;
        }

        public static Coin FromValue(decimal value)
        {
            SupportedCoinsInformant.ThrowIfNotSupported(value);
            return new Coin(value);
        }

        public bool Equals(Coin other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Coin)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Coin left, Coin right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Coin left, Coin right)
        {
            return !Equals(left, right);
        }
    }
}