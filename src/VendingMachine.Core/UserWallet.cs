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

        private Dictionary<Coin, int> Coins { get; } = new Dictionary<Coin, int>();

        public UserWallet()
        {

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

        public bool HasThisTypeOfCoin([NotNull] Coin coin)
        {
            return Coins.ContainsKey(coin);
        }


        public int Take([NotNull] Coin coin)
        {
            WithdrawSingle(coin);
            return SingleCoinPiece;
        }

        private void WithdrawSingle([NotNull] Coin coin)
        {
            if (!HasThisTypeOfCoin(coin))
            {
                throw new WalletIsOutOfSuchCoinException(coin);
            }

            Coins[coin] -= SingleCoinPiece;
            if (Coins[coin] == ZeroCoins)
            {
                Coins.Remove(coin);
            }
        }
    }
}