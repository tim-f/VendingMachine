using System.Collections.ObjectModel;

namespace VendingMachine.Presentation.Wpf.AppModel
{
    public class Wallet : AppModelBase
    {
        public ObservableCollection<Coin> Coins { get; private set; } = new ObservableCollection<Coin>();
    }
}