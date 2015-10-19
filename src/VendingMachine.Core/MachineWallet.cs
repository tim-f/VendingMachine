using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Core
{
    public sealed class MachineWallet
    {
        private readonly CoinStash _coinStash = StartupDefaults.CreateDefaultMachineWallet();
        private decimal DepositAmount { get; set; }

        public void DepositCoin(Coin coin)
        {
            _coinStash.Put(coin);
            DepositAmount += coin.Value;
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
            DepositAmount = decimal.Zero;

            return CoinSet.FromDictionary(cashBackCoins);
        }

        public decimal GetDepositAmount()
        {
            return DepositAmount;
        }

        public void SubtractFromDeposit(decimal amount)
        {
            if (amount > DepositAmount)
            {
                throw new InvalidOperationException("Requested amount is more than available on deposit.");
            }
            DepositAmount -= amount;
        }

        public CoinSet GetAvailableCoins()
        {
            return _coinStash.PeekInside();
        }
    }
}