namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class CashDepositModel : AppModel
    {
        private decimal _amount;
        private bool _hasPositiveBalance;

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (_amount == value) return;
                _amount = value;
                OnPropertyChanged();
            }
        }

        public bool HasPositiveBalance
        {
            get { return _hasPositiveBalance; }
            set
            {
                if (_hasPositiveBalance == value) return;
                _hasPositiveBalance = value;
                OnPropertyChanged();
            }
        }
    }
}