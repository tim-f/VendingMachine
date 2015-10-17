﻿using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace VendingMachine.ApplicationLogic.AppModel
{
    public sealed class UserWallet : AppModel
    {
        [NotNull]
        public ObservableCollection<Coin> Coins { get; } = new ObservableCollection<Coin>();
    }
}