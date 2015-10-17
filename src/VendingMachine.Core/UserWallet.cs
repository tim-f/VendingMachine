using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace VendingMachine.Core
{
    public class UserWallet
    {
        private const int ZeroCoins = 0;
        private const int SingleCoinPiece = 1;

        private IDictionary<Coin, int> Coins { get; }

        public UserWallet(CoinSet coinSet)
        {
            var supportedCoinTypes = coinSet.GetSupportedCoinTypes();
            Coins = new Dictionary<Coin, int>(supportedCoinTypes.ToDictionary(coin => coin, coin => ZeroCoins));
            
        }

        public void Put([NotNull] Coin coin, int count)
        {
            Coins[coin] += count;
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
            return Coins[coin] > ZeroCoins;
        }


        public int Take([NotNull] Coin coin)
        {
            WithdrawSingle(coin);
            return SingleCoinPiece;
        }

        private void WithdrawSingle([NotNull] Coin coin)
        {
            if (!HasCoinsOf(coin))
            {
                throw new WalletIsOutOfSuchCoinException(coin);
            }

            Coins[coin] -= SingleCoinPiece;
        }
    }

    public class CoinSet
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