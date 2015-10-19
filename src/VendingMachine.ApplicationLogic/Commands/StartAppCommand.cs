using System;
using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class StartAppCommand : IChainCommand
    {
        private INavigator Navigator { get; }
        private IUserWallet UserWallet { get; }
        private IMachineOperations MachineOperations { get; }

        public StartAppCommand(INavigator navigator, IUserWallet userWallet, IMachineOperations machineOperations)
        {
            Navigator = navigator;
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
            var userWallet = Navigator.Navigate<UserWalletModel>();
            var availableCoins = UserWallet.GetAvailableCoins();
            foreach (var coinInfo in availableCoins.Coins)
            {
                userWallet.Coins.Add(new CoinModel { Value = coinInfo.Key.Value, Count = coinInfo.Value, IsAvailable = coinInfo.Value > 0 });
            }
        }

        private void PrepareCashDepositPage()
        {
            var cashDeposit = Navigator.Navigate<CashDepositModel>();
            cashDeposit.Amount = 0M;
            cashDeposit.HasPositiveBalance = false;
        }

        private void PrepareMachineWalletPage()
        {
            var availableCoins = MachineOperations.GetAvailableCoins();
            var machineWallet = Navigator.Navigate<MachineWalletModel>();
            foreach (var coinInfo in availableCoins.Coins)
            {
                machineWallet.Coins.Add(new CoinModel { Value = coinInfo.Key.Value, Count = coinInfo.Value, IsAvailable = coinInfo.Value > 0 });
            }
        }

        private void PrepareGoodsMenuPage()
        {

            var goodsMenu = Navigator.Navigate<GoodsMenuModel>();
            goodsMenu.MenuItems.Add(new MenuItemModel { ProductId = Guid.NewGuid(), ProductName = "Чай", Price = 13M, Count = 10, IsAvailable = true });
            goodsMenu.MenuItems.Add(new MenuItemModel { ProductId = Guid.NewGuid(), ProductName = "Кофе", Price = 18M, Count = 20, IsAvailable = true });
            goodsMenu.MenuItems.Add(new MenuItemModel { ProductId = Guid.NewGuid(), ProductName = "Кофе с молоком", Price = 21M, Count = 20, IsAvailable = true });
            goodsMenu.MenuItems.Add(new MenuItemModel { ProductId = Guid.NewGuid(), ProductName = "Сок", Price = 35M, Count = 15, IsAvailable = true });
        }
    }
}