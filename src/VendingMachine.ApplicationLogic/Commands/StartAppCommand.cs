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
            var userWallet = Visualizer.Visualize<UserWallet>();
            userWallet.Coins.Add(new Coin { Value = 1M, Count = 10, IsAvailable = true });
            userWallet.Coins.Add(new Coin { Value = 2M, Count = 10, IsAvailable = true });
            userWallet.Coins.Add(new Coin { Value = 5M, Count = 10, IsAvailable = true });
            userWallet.Coins.Add(new Coin { Value = 10M, Count = 10, IsAvailable = true });
        }

        private void PrepareCashDepositPage()
        {
            var cashDeposit = Visualizer.Visualize<CashDeposit>();
            cashDeposit.Amount = 0M;
        }

        private void PrepareMachineWalletPage()
        {
            var machineWallet = Visualizer.Visualize<MachineWallet>();
            machineWallet.Coins.Add(new Coin { Value = 1M, Count = 100, IsAvailable = true });
            machineWallet.Coins.Add(new Coin { Value = 2M, Count = 100, IsAvailable = true });
            machineWallet.Coins.Add(new Coin { Value = 5M, Count = 100, IsAvailable = true });
            machineWallet.Coins.Add(new Coin { Value = 10M, Count = 100, IsAvailable = true });
        }

        private void PrepareGoodsMenuPage()
        {
            var goodsMenu = Visualizer.Visualize<GoodsMenu>();
            goodsMenu.MenuItems.Add(new MenuItem { ProductName = "Чай", Price = 13M, Count = 10, IsAvailable = true });
            goodsMenu.MenuItems.Add(new MenuItem { ProductName = "Кофе", Price = 18M, Count = 20, IsAvailable = true });
            goodsMenu.MenuItems.Add(new MenuItem { ProductName = "Кофе с молоком", Price = 21M, Count = 20, IsAvailable = true });
            goodsMenu.MenuItems.Add(new MenuItem { ProductName = "Сок", Price = 35M, Count = 15, IsAvailable = true });
        }
    }
}