namespace VendingMachine.Core.Services
{
    public sealed class UserWallet : IUserWallet
    {
        private readonly CoinStash _coinStash = StartupDefaults.CreateDefaultUserWallet();

        public void PutChangeBack(CoinSet coinSet)
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

        public CoinSet GetAvailableCoins()
        {
            return _coinStash.PeekInside();
        }
    }
}