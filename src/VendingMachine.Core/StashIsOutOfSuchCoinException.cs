using System;

namespace VendingMachine.Core
{
    [Serializable]
    public class StashIsOutOfSuchCoinException : Exception
    {
        private Coin Coin { get; }

        public StashIsOutOfSuchCoinException(Coin coin)
        {
            Coin = coin;
        }

        public override string Message => $"A wallet has no coin(s) of such value '{Coin.Value}'.";
    }
}