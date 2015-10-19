using System;
using System.Collections.Generic;

namespace VendingMachine.Core
{
    public static class StartupDefaults
    {
        public static CoinStash CreateDefaultUserWallet()
        {
            var userWallet = new CoinStash();
            var coinSet = CoinSet.FromDictionary(new Dictionary<Coin, int>(4)
            {
                { Coin.FromValue(1M), 10 },
                { Coin.FromValue(2M), 30 },
                { Coin.FromValue(5M), 20 },
                { Coin.FromValue(10M), 15 },
            });
            userWallet.Put(coinSet);
            return userWallet;
        }

        public static CoinStash CreateDefaultMachineWallet()
        {
            var stash = new CoinStash();
            var coinSet = CoinSet.FromDictionary(new Dictionary<Coin, int>(4)
            {
                { Coin.FromValue(1M), 100 },
                { Coin.FromValue(2M), 100 },
                { Coin.FromValue(5M), 100 },
                { Coin.FromValue(10M), 100 },
            });
            stash.Put(coinSet);
            return stash;
        }

        public static IReadOnlyCollection<ProductTray> CreateDefaultProductTrayList()
        {
            return new List<ProductTray>
            {
                new ProductTray(Guid.NewGuid(), "Чай", 13M, 10),
                new ProductTray(Guid.NewGuid(), "Кофе", 18M, 20),
                new ProductTray(Guid.NewGuid(), "Кофе с молоком", 21M, 20),
                new ProductTray(Guid.NewGuid(), "Сок", 35M, 15),
            };
        }
    }
}