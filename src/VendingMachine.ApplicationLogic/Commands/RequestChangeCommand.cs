using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class RequestChangeCommand : IChainCommand<CashDepositModel, CoinSet>
    {
        private IMachineOperations MachineOperations { get; }
        private INavigator Navigator { get; }

        public RequestChangeCommand(IMachineOperations machineOperations, INavigator navigator)
        {
            MachineOperations = machineOperations;
            Navigator = navigator;
        }

        public CoinSet Execute(CashDepositModel parameter)
        {
            CoinSet change = MachineOperations.RetrieveChange();
            UpdateMachineWallet();

            parameter.Amount = decimal.Zero;
            parameter.HasPositiveBalance = false;
            return change;
        }

        private void UpdateMachineWallet()
        {
            var availableCoins = MachineOperations.GetAvailableCoins();
            var machineWallet = Navigator.GetNavigatedModel<MachineWalletModel>();
            machineWallet.Coins.Clear();
            foreach (var coinInfo in availableCoins.Coins)
            {
                machineWallet.Coins.Add(new CoinModel { Value = coinInfo.Key.Value, Count = coinInfo.Value, IsAvailable = coinInfo.Value > 0 });
            }
        }
    }
}