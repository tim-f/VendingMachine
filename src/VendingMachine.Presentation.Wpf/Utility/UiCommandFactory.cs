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

        public ICommand StartApp => new StartAppCommand(Services.Visualizer, Services.UserWallet).Wrap();

        public ICommand DepositCoin => new TakeCoinFromUserWalletCommand(Services.UserWallet)
            .ContinueWith(new PutCoinIntoMachineWalletCommand(Services.MachineOperations, Services.Visualizer))
            .Wrap();

        public ICommand TakeChange => new RequestChangeCommand(Services.MachineOperations).Wrap();
    }
}