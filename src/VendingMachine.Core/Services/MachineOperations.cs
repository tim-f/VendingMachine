namespace VendingMachine.Core.Services
{
    public class MachineOperations : IMachineOperations
    {
        private MachineWallet MachineWallet { get; } = new MachineWallet();

        public void DepositCoin(Coin coin)
        {
            MachineWallet.DepositCoin(coin);
        }

        public decimal GetDepositAmount()
        {
            return MachineWallet.GetDepositAmount();
        }

        public CoinSet RetrieveChange()
        {
            return MachineWallet.RequestCashBack();
        }

        public CoinSet GetAvailableCoins()
        {
            return MachineWallet.GetAvailableCoins();
        }
    }
}