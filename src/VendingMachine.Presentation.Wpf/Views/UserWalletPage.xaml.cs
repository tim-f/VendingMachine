using System.Windows.Input;

namespace VendingMachine.Presentation.Wpf.Views
{
    /// <summary>
    /// Interaction logic for UserWalletPage.xaml
    /// </summary>
    public sealed partial class UserWalletPage
    {
        public UserWalletPage()
        {
            InitializeComponent();
        }

        public ICommand DepositCoinCommand => App.CommandFactory.DepositCoinCommand;

    }
}
