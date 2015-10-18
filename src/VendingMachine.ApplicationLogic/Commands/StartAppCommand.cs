using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class StartAppCommand : IChainCommand
    {
        private IVisualizer Visualizer { get; }
        private IUserWallet UserWallet { get; }
        private IMachineOperations MachineOperations { get; }

        public StartAppCommand(IVisualizer visualizer, IUserWallet userWallet, IMachineOperations machineOperations)
        {
            Visualizer = visualizer;
            UserWallet = userWallet;
            MachineOperations = machineOperations;
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
            var availableCoins = UserWallet.GetAvailableCoins();
            foreach (var coinInfo in availableCoins.Coins)
            {
                userWallet.Coins.Add(new CoinModel { Value = coinInfo.Key.Value, Count = coinInfo.Value, IsAvailable = coinInfo.Value > 0 });
            }
        }

        private void PrepareCashDepositPage()
        {
            var cashDeposit = Visualizer.Visualize<CashDepositModel>();
            cashDeposit.Amount = 0M;
            cashDeposit.HasPositiveBalance = false;
        }

        private void PrepareMachineWalletPage()
        {
            var availableCoins = MachineOperations.GetAvailableCoins();
            var machineWallet = Visualizer.Visualize<MachineWalletModel>();
            foreach (var coinInfo in availableCoins.Coins)
            {
                machineWallet.Coins.Add(new CoinModel { Value = coinInfo.Key.Value, Count = coinInfo.Value, IsAvailable = coinInfo.Value > 0 });
            }
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