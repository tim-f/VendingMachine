using JetBrains.Annotations;

namespace VendingMachine.Core.Services
{
    public interface IMachineWallet
    {
        CoinSet GetAvailableCoins();
        void PutCoins(CoinSet coinSet);
        void DepositCoin([NotNull] Coin coin);
        CoinSet RequestCashBack();
        decimal GetDepositAmount();
    }

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
            throw new System.NotImplementedException();
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