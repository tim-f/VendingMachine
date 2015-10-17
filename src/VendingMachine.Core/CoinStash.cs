using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;

namespace VendingMachine.Core
{
    public class CoinStash
    {
        private const int ZeroCoinCount = 0;
        private const int SingleCoinPiece = 1;

        private IDictionary<Coin, int> Coins { get; }

        public CoinStash()
        {
            var coinTypes = SupportedCoinsInformant.GetSupportedCoins();
            Coins = new Dictionary<Coin, int>(coinTypes.ToDictionary(coin => coin, coin => ZeroCoinCount));

        }

        public void Put([NotNull] Coin coin, int count)
        {
            ThrowIfNotSupported(coin);
            Coins[coin] += count;
        }

        public void Put([NotNull] CoinSet coinSet)
        {
            foreach (var coinGroup in coinSet.Coins)
            {
                Put(coinGroup.Key, coinGroup.Value);
            }
        }

        public bool HasCoinsOf([NotNull] Coin coin)
        {
            ThrowIfNotSupported(coin);
            return Coins[coin] > ZeroCoinCount;
        }


        public void Take([NotNull] Coin coin)
        {
            ThrowIfNotSupported(coin);
            if (!HasCoinsOf(coin))
            {
                throw new StashIsOutOfSuchCoinException(coin);
            }

            Coins[coin] -= SingleCoinPiece;
        }

        public IReadOnlyDictionary<Coin, int> PeekInside()
        {
            return new ReadOnlyDictionary<Coin, int>(Coins);
        }

        public decimal CalculateTotalAmount()
        {
            return Coins.Sum(pair => pair.Key.Value * pair.Value);
        }

        private void ThrowIfNotSupported(Coin coin)
        {
            if (!SupportedCoinsInformant.IsSupported(coin))
            {
                throw new NotSupportedCoinTypeException(coin);
            }
        }
    }
}