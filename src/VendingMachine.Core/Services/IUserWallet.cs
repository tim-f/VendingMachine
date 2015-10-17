using JetBrains.Annotations;

namespace VendingMachine.Core.Services
{
    public interface IUserWallet
    {
        void PutCoinSet([NotNull] CoinSet coinSet);
        void TakeCoin([NotNull] Coin coin);
        decimal CalculateTotalAmount();
    }
}