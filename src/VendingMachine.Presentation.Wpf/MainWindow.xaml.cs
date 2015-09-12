using VendingMachine.Presentation.Wpf.AppModel;

namespace VendingMachine.Presentation.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Wallet wallet = new Wallet();
            wallet.Coins.Add(new CoinSet { Value = 1M, Count = 10 });
            wallet.Coins.Add(new CoinSet { Value = 2M, Count = 10 });
            wallet.Coins.Add(new CoinSet { Value = 5M, Count = 10 });
            wallet.Coins.Add(new CoinSet { Value = 10M, Count = 10 });

            Wallet.NavigationService.Navigate(new WalletPage(wallet));
        }
    }
}
