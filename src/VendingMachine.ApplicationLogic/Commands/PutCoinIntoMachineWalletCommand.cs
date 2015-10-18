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
        private IVisualizer Visualizer { get; }

        public PutCoinIntoMachineWalletCommand([NotNull] IMachineOperations machineOperations, [NotNull] IVisualizer visualizer)
        {
            MachineOperations = machineOperations;
            Visualizer = visualizer;
        }

        public void Execute(decimal parameter)
        {
            MachineOperations.DepositCoin(Coin.FromValue(parameter));
            var cashDeposit = Visualizer.GetVisualizedModel<CashDepositModel>();
            var machineWallet = Visualizer.GetVisualizedModel<MachineWalletModel>();

            cashDeposit.Amount = MachineOperations.GetDepositAmount();
            machineWallet.Coins.Single(coin => coin.Value == parameter).Count++;
        }
    }
}