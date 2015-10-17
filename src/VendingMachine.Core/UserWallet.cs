﻿using System.Collections.Generic;
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

        public decimal CalculateTotalAmount()
        {
            return Coins.Sum(pair => pair.Key.Value * pair.Value);
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
}