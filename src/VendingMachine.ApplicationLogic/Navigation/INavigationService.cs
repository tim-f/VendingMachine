using VendingMachine.ApplicationLogic.AppModel;

namespace VendingMachine.ApplicationLogic.Navigation
{
    public interface INavigationService
    {
        void ShowUserWallet(UserWallet userWallet);
        void ShowMachineWallet(MachineWallet machineWallet);
        void ShowCashDeposit(CashDeposit cashDeposit);
        void ShowGoodsMenu(GoodsMenu goodsMenu);
    }
}