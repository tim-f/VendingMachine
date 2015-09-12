using VendingMachine.Presentation.Wpf.AppModel;

namespace VendingMachine.Presentation.Wpf
{
    /// <summary>
    /// Interaction logic for WalletPage.xaml
    /// </summary>
    public partial class WalletPage
    {
        public WalletPage(Wallet wallet)
        {
            InitializeComponent();

            DataContext = wallet;
        }
    }
}
