using VendingMachine.Presentation.Wpf.AppModel;

namespace VendingMachine.Presentation.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Wallet wallet = new Wallet();
            wallet.Coins.Add(new Coin { Value = 1M, Count = 10 });
            wallet.Coins.Add(new Coin { Value = 2M, Count = 10 });
            wallet.Coins.Add(new Coin { Value = 5M, Count = 10 });
            wallet.Coins.Add(new Coin { Value = 10M, Count = 10 });

            Wallet.NavigationService.Navigate(new WalletPage(wallet));
        }
    }
}
