using System;

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

        public bool HasProduct(Guid productId)
        {
            return GoodsStore.HasProduct(productId);
        }

        public void SellProduct(Guid productId)
        {
            GoodsStore.TakeProductItem(productId);
        }
    }
}