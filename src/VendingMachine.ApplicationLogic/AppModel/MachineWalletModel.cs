using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class MachineWalletModel : AppModel
    {
        [NotNull]
        public ObservableCollection<CoinModel> Coins { get; } = new ObservableCollection<CoinModel>();
    }
}