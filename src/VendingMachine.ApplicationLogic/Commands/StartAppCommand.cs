using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class StartAppCommand : IChainCommand
    {
        private IVisualizer Visualizer { get; }

        public StartAppCommand(IVisualizer visualizer)
        {
            Visualizer = visualizer;
        }

        public void Execute()
        {
            PrepareUserWalletPage();
            PrepareCashDepositPage();
            PrepareMachineWalletPage();
            PrepareGoodsMenuPage();
        }

        private void PrepareUserWalletPage()
        {
            var userWallet = Visualizer.Visualize<UserWalletModel>();
            userWallet.Coins.Add(new CoinModel { Value = 1M, Count = 10, IsAvailable = true });
            userWallet.Coins.Add(new CoinModel { Value = 2M, Count = 10, IsAvailable = true });
            userWallet.Coins.Add(new CoinModel { Value = 5M, Count = 10, IsAvailable = true });
            userWallet.Coins.Add(new CoinModel { Value = 10M, Count = 10, IsAvailable = true });
        }

        private void PrepareCashDepositPage()
        {
            var cashDeposit = Visualizer.Visualize<CashDepositModel>();
            cashDeposit.Amount = 0M;
        }

        private void PrepareMachineWalletPage()
        {
            var machineWallet = Visualizer.Visualize<MachineWalletModel>();
            machineWallet.Coins.Add(new CoinModel { Value = 1M, Count = 100, IsAvailable = true });
            machineWallet.Coins.Add(new CoinModel { Value = 2M, Count = 100, IsAvailable = true });
            machineWallet.Coins.Add(new CoinModel { Value = 5M, Count = 100, IsAvailable = true });
            machineWallet.Coins.Add(new CoinModel { Value = 10M, Count = 100, IsAvailable = true });
        }

        private void PrepareGoodsMenuPage()
        {
            var goodsMenu = Visualizer.Visualize<GoodsMenuModel>();
            goodsMenu.MenuItems.Add(new MenuItemModel { ProductName = "Чай", Price = 13M, Count = 10, IsAvailable = true });
            goodsMenu.MenuItems.Add(new MenuItemModel { ProductName = "Кофе", Price = 18M, Count = 20, IsAvailable = true });
            goodsMenu.MenuItems.Add(new MenuItemModel { ProductName = "Кофе с молоком", Price = 21M, Count = 20, IsAvailable = true });
            goodsMenu.MenuItems.Add(new MenuItemModel { ProductName = "Сок", Price = 35M, Count = 15, IsAvailable = true });
        }
    }
}