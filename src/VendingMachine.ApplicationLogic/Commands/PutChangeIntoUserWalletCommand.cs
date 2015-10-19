using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class PutChangeIntoUserWalletCommand : IChainCommand<CoinSet>
    {
        private IUserWallet UserWallet { get; }
        private INavigator Navigator { get; }

        public PutChangeIntoUserWalletCommand(IUserWallet userWallet, INavigator navigator)
        {
            UserWallet = userWallet;
            Navigator = navigator;
        }

        public void Execute(CoinSet parameter)
        {
            UserWallet.PutChangeBack(parameter);
            var availableCoins = UserWallet.GetAvailableCoins();

            var userWalletModel = Navigator.GetNavigatedModel<UserWalletModel>();
            userWalletModel.Coins.Clear();
            foreach (var coinInfo in availableCoins.Coins)
            {
                userWalletModel.Coins.Add(new CoinModel { Value = coinInfo.Key.Value, Count = coinInfo.Value, IsAvailable = coinInfo.Value > 0 });
            }
        }
    }
}