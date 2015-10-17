namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class CoinSet : AppModel
    {
        private int _count;
        private decimal _value;

        public decimal Value
        {
            get { return _value; }
            set
            {
                if (value == _value) return;
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                if (value == _count) return;
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
    }
}