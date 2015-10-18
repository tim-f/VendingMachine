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

        public ICommand DepositCoinCommand
        {
            get
            {
                return new TakeCoinFromUserWalletCommand(Services.UserWallet, Services.Visualizer)
                    .ContinueWith(new PutCoinIntoMachineCommand(Services.MachineOperations, Services.Visualizer))
                    .Wrap();
            }
        }
    }
}