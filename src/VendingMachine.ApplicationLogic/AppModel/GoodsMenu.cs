using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class GoodsMenu : AppModel
    {
        [NotNull]
        public ObservableCollection<MenuItem> MenuItems { get; } = new ObservableCollection<MenuItem>();
    }
}