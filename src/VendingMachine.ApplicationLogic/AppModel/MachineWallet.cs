using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class MachineWallet : AppModel
    {
        [NotNull]
        public ObservableCollection<Coin> Coins { get; } = new ObservableCollection<Coin>();
    }
}