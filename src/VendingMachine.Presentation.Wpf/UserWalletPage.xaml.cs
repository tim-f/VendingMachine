using VendingMachine.Presentation.Wpf.AppModel;

namespace VendingMachine.Presentation.Wpf
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
