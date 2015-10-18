using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Core
{
    public static class SupportedCoinsInformant
    {
        private static readonly HashSet<decimal> Coins = new HashSet<decimal>(EnumerateSupportedValues());

        public static IReadOnlyCollection<decimal> GetSupportedValues()
        {
            return Coins.ToList();
        }

        public static bool IsSupported(decimal value)
        {
            return Coins.Contains(value);
        }

        private static IEnumerable<decimal> EnumerateSupportedValues()
        {
            yield return 1M;
            yield return 2M;
            yield return 5M;
            yield return 10M;
        }

        public static void ThrowIfNotSupported(decimal value)
        {
            if (!IsSupported(value))
            {
                throw new NotSupportedValueException(value);
            }
        }
    }
}