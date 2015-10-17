using System.Collections.Generic;

namespace VendingMachine.Core
{
    public static class StartupDefaults
    {
        public static UserWallet CreateDefaultUserWallet()
        {
            var userWallet = new UserWallet(new CoinSet());
            userWallet.Put(new Dictionary<Coin, int>(4)
            {
                { Coin.FromValue(1M), 10 },
                { Coin.FromValue(2M), 30 },
                { Coin.FromValue(5M), 20 },
                { Coin.FromValue(10M), 15 },
            });
            return userWallet;
        }

        public static void CreateDefaultMachineWallet()
        {
            
        }
    }
}