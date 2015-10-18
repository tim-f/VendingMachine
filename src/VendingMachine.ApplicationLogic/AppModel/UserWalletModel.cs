using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class UserWalletModel : AppModel
    {
        [NotNull]
        public ObservableCollection<CoinModel> Coins { get; } = new ObservableCollection<CoinModel>();
    }
}