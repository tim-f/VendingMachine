﻿namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class CashDepositModel : AppModel
    {
        private decimal _amount;

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
    }
}