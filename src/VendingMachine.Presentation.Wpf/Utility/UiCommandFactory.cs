using System.Windows.Input;
using VendingMachine.ApplicationLogic.Commands;
using VendingMachine.ApplicationLogic.Utility;

namespace VendingMachine.Presentation.Wpf.Utility
{
    public class UiCommandFactory
    {
        private AppServices Services { get; }

        public UiCommandFactory(AppServices services)
        {
            Services = services;
        }

        public ICommand StartAppCommand => new StartAppCommand(Services.Visualizer, Services.UserWallet).Wrap();

        public ICommand DepositCoinCommand => new TakeCoinFromUserWalletCommand(Services.UserWallet, Services.Visualizer)
            .ContinueWith(new PutCoinIntoMachineCommand(Services.MachineOperations, Services.Visualizer))
            .Wrap();
    }
}