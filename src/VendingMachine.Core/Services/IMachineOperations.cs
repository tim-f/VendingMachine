namespace VendingMachine.Core.Services
{
    public interface IMachineOperations
    {
        void DepositCoin(Coin coin);
        decimal GetDepositAmount();
    }

    public class MachineOperations : IMachineOperations
    {
        private IMachineWallet MachineWallet { get; } = new MachineWallet();

        public void DepositCoin(Coin coin)
        {
            MachineWallet.DepositCoin(coin);
        }

        public decimal GetDepositAmount()
        {
            return MachineWallet.GetDepositAmount();
        }
    }
}