using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class StartAppCommand : IChainCommand
    {
        private INavigationService NavigationService { get; }

        public StartAppCommand(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void Execute()
        {
            NavigationService.ShowUserWallet(new UserWallet());
            NavigationService.ShowCashDeposit(new CashDeposit());
            NavigationService.ShowMachineWallet(new MachineWallet());
            NavigationService.ShowGoodsMenu(new GoodsMenu());
        }
    }
}