using VendingMachine.ApplicationLogic.AppModel;

namespace VendingMachine.Presentation.Wpf.Views
{
    /// <summary>
    /// Interaction logic for UserWalletPage.xaml
    /// </summary>
    public sealed partial class UserWalletPage
    {
        public UserWalletPage(UserWallet userWallet)
        {
            InitializeComponent();

            DataContext = userWallet;
        }
    }
}
