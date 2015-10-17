using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Core
{
    public static class SupportedCoinsInformant
    {
        private static readonly HashSet<Coin> Coins = new HashSet<Coin>(EnumerateSupportedCoins());

        public static IReadOnlyCollection<Coin> GetSupportedCoins()
        {
            return Coins.ToList();
        }

        public static bool IsSupported(Coin coin)
        {
            return Coins.Contains(coin);
        }

        private static IEnumerable<Coin> EnumerateSupportedCoins()
        {
            yield return Coin.FromValue(1M);
            yield return Coin.FromValue(2M);
            yield return Coin.FromValue(5M);
            yield return Coin.FromValue(10M);
        }
    }
}