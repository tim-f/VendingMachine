namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class CashDeposit : AppModel
    {
        private decimal _amount;
        private bool _hasSufficientFunds;

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

        public bool HasSufficientFunds
        {
            get { return _hasSufficientFunds; }
            set
            {
                if (_hasSufficientFunds == value) return;
                _hasSufficientFunds = value;
                OnPropertyChanged();
            }
        }
    }
}