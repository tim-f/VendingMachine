using System.Collections.ObjectModel;

namespace VendingMachine.Presentation.Wpf.AppModel
{
    public sealed class UserWallet : AppModel
    {
        public ObservableCollection<CoinSet> Coins { get; } = new ObservableCollection<CoinSet>();
    }
}