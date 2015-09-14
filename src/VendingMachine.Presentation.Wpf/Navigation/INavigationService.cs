using System.Windows;
using System.Windows.Controls;
using JetBrains.Annotations;

namespace VendingMachine.Presentation.Wpf.Navigation
{
    public interface INavigationService
    {
        void ShowUserWallet();
        void ShowVendingMachineWallet();
        void ShowVendingMachineMenu();
    }

    internal sealed class NavigationService : INavigationService
    {
        [NotNull]
        private MainWindow MainWindow => ((MainWindow)Application.Current.MainWindow);

        [NotNull]
        private Frame UserWalletFrame => MainWindow.Wallet;

        [NotNull]
        private Frame VendingMachineWalletFrame => MainWindow.VendingMachine;


        public void ShowVendingMachineWallet()
        {
            throw new System.NotImplementedException();
        }

        public void ShowVendingMachineMenu()
        {
            throw new System.NotImplementedException();
        }

        public void ShowUserWallet()
        {
            throw new System.NotImplementedException();
        }
    }
}