using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;

namespace VendingMachine.Core
{
    public class CoinStash
    {
        private SupportedCoinTypesInformant SupportedCoinTypesInformant { get; }
        private const int ZeroCoinCount = 0;
        private const int SingleCoinPiece = 1;

        private IDictionary<Coin, int> Coins { get; }

        public CoinStash(SupportedCoinTypesInformant supportedCoinTypesInformant)
        {
            SupportedCoinTypesInformant = supportedCoinTypesInformant;
            var coinTypes = supportedCoinTypesInformant.GetSupportedCoinTypes();
            Coins = new Dictionary<Coin, int>(coinTypes.ToDictionary(coin => coin, coin => ZeroCoinCount));

        }

        public void Put([NotNull] Coin coin, int count)
        {
            ThrowIfNotSupported(coin);
            Coins[coin] += count;
        }

        private void ThrowIfNotSupported(Coin coin)
        {
            if (!SupportedCoinTypesInformant.IsSupported(coin))
            {
                throw new NotSupportedCoinTypeException(coin);
            }
        }

        public void Put([NotNull] IReadOnlyDictionary<Coin, int> coins)
        {
            foreach (var coinType in coins)
            {
                Coins[coinType.Key] += coinType.Value;
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
    }
}