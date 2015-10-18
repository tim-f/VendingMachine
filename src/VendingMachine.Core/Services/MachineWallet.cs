using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Core.Services
{
    public sealed class MachineWallet : IMachineWallet
    {
        private readonly CoinStash _coinStash = new CoinStash();
        private decimal DepositAmount { get; set; }

        public void PutCoins(CoinSet coinSet)
        {
            _coinStash.Put(coinSet);
        }

        public void DepositCoin(Coin coin)
        {
            DepositAmount += coin.Value;
            _coinStash.Put(coin);
        }

        public CoinSet RequestCashBack()
        {
            var availableCoinSet = GetAvailableCoins();
            var orderedCoins = availableCoinSet.Coins.OrderByDescending(coin => coin.Key.Value);

            var cashBackCoins = new Dictionary<Coin, int>();

            decimal sumToGiveBack = DepositAmount;

            foreach (var coin in orderedCoins)
            {
                if (sumToGiveBack < coin.Key.Value)
                {
                    continue;
                }

                for (int numberOfCoins = 1; numberOfCoins <= coin.Value; numberOfCoins++)
                {
                    sumToGiveBack -= coin.Key.Value;
                    if (sumToGiveBack < coin.Key.Value)
                    {
                        cashBackCoins.Add(coin.Key, numberOfCoins);

                        break;
                    }
                }
            }

            foreach (var cashBackCoin in cashBackCoins)
            {
                _coinStash.Take(cashBackCoin.Key, cashBackCoin.Value);
            }

            return CoinSet.FromDictionary(cashBackCoins);
        }

        public decimal GetDepositAmount()
        {
            return DepositAmount;
        }

        public CoinSet GetAvailableCoins()
        {
            return _coinStash.PeekInside();
        }
    }
}