using System.Linq;
using JetBrains.Annotations;
using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class PutCoinIntoMachineWalletCommand : IChainCommand<decimal>
    {
        private IMachineOperations MachineOperations { get; }
        private INavigator Navigator { get; }

        public PutCoinIntoMachineWalletCommand([NotNull] IMachineOperations machineOperations, [NotNull] INavigator navigator)
        {
            MachineOperations = machineOperations;
            Navigator = navigator;
        }

        public void Execute(decimal parameter)
        {
            MachineOperations.DepositCoin(Coin.FromValue(parameter));
            var cashDeposit = Navigator.GetNavigatedModel<CashDepositModel>();

            cashDeposit.Amount = MachineOperations.GetDepositAmount();
            cashDeposit.HasPositiveBalance = true;

            UpdateMachineWallet();
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