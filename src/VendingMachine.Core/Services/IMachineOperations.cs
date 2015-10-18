namespace VendingMachine.Core.Services
{
    public interface IMachineOperations
    {
        void DepositCoin(Coin coin);
        decimal GetDepositAmount();
        CoinSet RetrieveChange();
        CoinSet GetAvailableCoins();
    }
}