using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class GoodsMenu : AppModel
    {
        [NotNull]
        public ObservableCollection<GoodsPosition> GoodsList { get; } = new ObservableCollection<GoodsPosition>();
    }

    public sealed class GoodsPosition : AppModel
    {
        private string _name;
        private decimal _price;
        private int _count;

        [NotNull]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price == value) return;
                _price = value;
                OnPropertyChanged();
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                if (_count == value) return;
                _count = value;
                OnPropertyChanged();
            }
        }
    }
}