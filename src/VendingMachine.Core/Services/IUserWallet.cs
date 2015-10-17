using JetBrains.Annotations;

namespace VendingMachine.Core.Services
{
    public interface IUserWallet
    {
        void PutChangeBack([NotNull] CoinSet coinSet);
        void TakeCoin([NotNull] Coin coin);
        decimal CalculateTotalAmount();
        [NotNull]
        CoinSet GetAvailableCoins();
    }
}