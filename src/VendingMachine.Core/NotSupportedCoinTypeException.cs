using System;
using JetBrains.Annotations;

namespace VendingMachine.Core
{
    public class NotSupportedCoinTypeException : Exception
    {
        private Coin Coin { get; }

        public NotSupportedCoinTypeException([NotNull] Coin coin)
        {
            Coin = coin;
        }

        public override string Message => $"Not supported type of coin: '{Coin.Value}'.";
    }
}