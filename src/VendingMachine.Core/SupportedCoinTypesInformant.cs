using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Core
{
    public class SupportedCoinTypesInformant
    {
        private HashSet<Coin> Coins { get; } = new HashSet<Coin>(EnumerateSupportedCoinTypes());

        public IReadOnlyCollection<Coin> GetSupportedCoinTypes()
        {
            return Coins.ToList();
        }

        public bool IsSupported(Coin coin)
        {
            return Coins.Contains(coin);
        }

        private static IEnumerable<Coin> EnumerateSupportedCoinTypes()
        {
            yield return Coin.FromValue(1M);
            yield return Coin.FromValue(2M);
            yield return Coin.FromValue(5M);
            yield return Coin.FromValue(10M);
        }
    }
}