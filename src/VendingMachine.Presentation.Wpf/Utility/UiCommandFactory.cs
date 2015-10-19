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

        public ICommand StartApp => new StartAppCommand(Services.Navigator, Services.UserWallet, Services.MachineOperations)
            .Wrap();

        public ICommand DepositCoin => new TakeCoinFromUserWalletCommand(Services.UserWallet)
            .ContinueWith(new PutCoinIntoMachineWalletCommand(Services.MachineOperations, Services.Navigator))
            .Wrap();

        public ICommand TakeChange => new RequestChangeCommand(Services.MachineOperations, Services.Navigator)
            .ContinueWith(new PutChangeIntoUserWalletCommand(Services.UserWallet, Services.Navigator))
            .Wrap();

        public ICommand BuyProduct => new TryBuyProductCommand(Services.MachineOperations, Services.Navigator)
            .ContinueWith(new ShowSellOperationResultMessageCommand(Services.Navigator))
            .Wrap();
    }
}