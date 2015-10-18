namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class Coin : AppModel
    {
        private int _count;
        private decimal _value;
        private bool _isAvailable;

        public decimal Value
        {
            get { return _value; }
            set
            {
                if (value == _value) return;
                _value = value;
                OnPropertyChanged();
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                if (value == _count) return;
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