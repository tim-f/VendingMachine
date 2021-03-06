﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;

namespace VendingMachine.Core
{
    public class CoinStash
    {
        private const int ZeroCoinCount = 0;

        private IDictionary<Coin, int> Coins { get; }

        public CoinStash()
        {
            var supportedValues = SupportedCoinsInformant.GetSupportedValues();
            Coins = new Dictionary<Coin, int>(supportedValues.ToDictionary(value => Coin.FromValue(value), _ => ZeroCoinCount));

        }

        public void Put([NotNull] Coin coin, int count = 1)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than zero.");
            }
            Coins[coin] += count;
        }

        public void Put([NotNull] CoinSet coinSet)
        {
            foreach (var coinGroup in coinSet.Coins)
            {
                Put(coinGroup.Key, coinGroup.Value);
            }
        }

        public bool HasCoinsOf([NotNull] Coin coin, int count = 1)
        {
            return GetCountFor(coin) >= count;
        }

        public int GetCountFor([NotNull] Coin coin)
        {
            return Coins[coin];
        }

        public void Take([NotNull] Coin coin, int count = 1)
        {
            if (!HasCoinsOf(coin, count))
            {
                throw new StashIsOutOfSuchCoinException(coin);
            }

            Coins[coin] -= count;
        }

        public CoinSet PeekInside()
        {
            return CoinSet.FromDictionary(new ReadOnlyDictionary<Coin, int>(Coins));
        }

        public decimal CalculateTotalAmount()
        {
            return Coins.Sum(pair => pair.Key.Value * pair.Value);
        }
    }
}