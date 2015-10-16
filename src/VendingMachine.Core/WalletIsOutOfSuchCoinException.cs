using System;

namespace VendingMachine.Core
{
    [Serializable]
    public class WalletIsOutOfSuchCoinException : Exception
    {
        private Coin Coin { get; }

        public WalletIsOutOfSuchCoinException(Coin coin)
        {
            Coin = coin;
        }

        public override string Message => $"A wallet has no coin(s) of such value '{Coin.Value}'.";
    }
}