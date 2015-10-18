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
}