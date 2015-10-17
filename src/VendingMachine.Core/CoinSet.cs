using System.Collections.Generic;
using JetBrains.Annotations;

namespace VendingMachine.Core
{
    public sealed class CoinSet
    {
        public IReadOnlyDictionary<Coin, int> Coins { get; }

        private CoinSet([NotNull] IReadOnlyDictionary<Coin, int> coins)
        {
            Coins = coins;
        }

        public static CoinSet FromDictionary([NotNull] IReadOnlyDictionary<Coin, int> coins)
        {
            foreach (var coin in coins.Keys)
            {
                if (!SupportedCoinsInformant.IsSupported(coin))
                {
                    throw new NotSupportedCoinTypeException(coin);
                }
            }
            return new CoinSet(coins);
        }
    }
}