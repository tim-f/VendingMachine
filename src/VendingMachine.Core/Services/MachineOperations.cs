using System;
using System.Collections.Generic;

namespace VendingMachine.Core.Services
{
    public class MachineOperations : IMachineOperations
    {
        private MachineWallet MachineWallet { get; } = new MachineWallet();
        private GoodsStore GoodsStore { get; } = new GoodsStore();

        public void DepositCoin(Coin coin)
        {
            MachineWallet.DepositCoin(coin);
        }

        public decimal GetDepositAmount()
        {
            return MachineWallet.GetDepositAmount();
        }

        public CoinSet RetrieveChange()
        {
            return MachineWallet.RequestCashBack();
        }

        public CoinSet GetAvailableCoins()
        {
            return MachineWallet.GetAvailableCoins();
        }

        public IReadOnlyCollection<ProductInfo> GetProductList()
        {
            return GoodsStore.GetAvailableProducts();
        }

        public bool HasProduct(Guid productId)
        {
            return GoodsStore.HasProduct(productId);
        }

        public bool CanBuyProduct(Guid productId)
        {
            var depositAmount = MachineWallet.GetDepositAmount();
            var productPrice = GoodsStore.GetProductPrice(productId);
            return depositAmount >= productPrice;
        }

        public void SellProduct(Guid productId)
        {
            GoodsStore.TakeProductItem(productId);
        }
    }
}