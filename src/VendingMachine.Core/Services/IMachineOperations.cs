using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace VendingMachine.Core.Services
{
    public interface IMachineOperations
    {
        void DepositCoin(Coin coin);
        decimal GetDepositAmount();
        [NotNull]
        CoinSet RetrieveChange();
        [NotNull]
        CoinSet GetAvailableCoins();
        [NotNull, ItemNotNull]
        IReadOnlyCollection<ProductInfo> GetProductList();
        bool HasProduct(Guid productId);
        void SellProduct(Guid productId);
    }
}