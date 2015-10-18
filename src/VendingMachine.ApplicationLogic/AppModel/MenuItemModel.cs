using JetBrains.Annotations;

namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class MenuItemModel : AppModel
    {
        private string _productName;
        private decimal _price;
        private int _count;
        private bool _isAvailable;

        [NotNull]
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (_productName == value) return;
                _productName = value;
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

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                if (_isAvailable == value) return;
                _isAvailable = value;
                OnPropertyChanged();
            }
        }
    }
}