using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class TakeCoinFromUserWalletCommand : IChainCommand<CoinModel, decimal>
    {
        private IUserWallet UserWallet { get; }

        public TakeCoinFromUserWalletCommand(IUserWallet userWallet)
        {
            UserWallet = userWallet;
        }

        public decimal Execute(CoinModel parameter)
        {
            UserWallet.TakeCoin(Coin.FromValue(parameter.Value));
            parameter.Count--;
            parameter.IsAvailable = parameter.Count > 0;
            return parameter.Value;
        }
    }
}