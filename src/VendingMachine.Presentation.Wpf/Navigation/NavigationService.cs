using System.Windows;
using System.Windows.Controls;
using JetBrains.Annotations;
using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.Presentation.Wpf.Views;

namespace VendingMachine.Presentation.Wpf.Navigation
{
    internal sealed class NavigationService : INavigationService
    {
        [NotNull]
        private MainWindow MainWindow => ((MainWindow)Application.Current.MainWindow);

        [NotNull]
        private Frame UserWalletFrame => MainWindow.UserWallet;

        [NotNull]
        private Frame MachineWalletFrame => MainWindow.MachineWallet;

        [NotNull]
        private Frame CashDepositFrame => MainWindow.CashDeposit;

        [NotNull]
        private Frame GoodsMenuFrame => MainWindow.GoodsMenu;


        public void ShowUserWallet(UserWallet userWallet)
        {
            UserWalletFrame.Navigate(new UserWalletPage(userWallet));
        }

        public void ShowMachineWallet(MachineWallet machineWallet)
        {
            MachineWalletFrame.Navigate(new MachineWalletPage(machineWallet));
        }

        public void ShowCashDeposit(CashDeposit cashDeposit)
        {
            CashDepositFrame.Navigate(new CashDepositPage(cashDeposit));
        }

        public void ShowGoodsMenu(GoodsMenu goodsMenu)
        {
            GoodsMenuFrame.Navigate(new GoodsMenuPage(goodsMenu));
        }
    }
}