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
            return new CoinSet(coins);
        }
    }
}