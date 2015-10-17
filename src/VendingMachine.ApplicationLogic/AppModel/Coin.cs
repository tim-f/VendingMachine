namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class Coin : AppModel
    {
        private int _count;
        private decimal _value;
        private bool _hasAny;

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

        public bool HasAny
        {
            get { return _hasAny; }
            set
            {
                if (_hasAny == value) return;
                _hasAny = value;
                OnPropertyChanged();
            }
        }
    }
}