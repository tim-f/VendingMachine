namespace VendingMachine.Core.Services
{
    public sealed class UserWallet : IUserWallet
    {
        private readonly CoinStash _coinStash = new CoinStash();

        public void PutCoinSet(CoinSet coinSet)
        {
            _coinStash.Put(coinSet);
        }

        public void TakeCoin(Coin coin)
        {
            _coinStash.Take(coin);
        }

        public decimal CalculateTotalAmount()
        {
            return _coinStash.CalculateTotalAmount();
        }
    }
}