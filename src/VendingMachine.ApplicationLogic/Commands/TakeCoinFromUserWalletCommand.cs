using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class TakeCoinFromUserWalletCommand : IChainCommand<CoinModel, decimal>
    {
        private IUserWallet UserWallet { get; }
        private IVisualizer Visualizer { get; }

        public TakeCoinFromUserWalletCommand(IUserWallet userWallet, IVisualizer visualizer)
        {
            UserWallet = userWallet;
            Visualizer = visualizer;
        }

        public decimal Execute(CoinModel parameter)
        {
            UserWallet.TakeCoin(Coin.FromValue(parameter.Value));
            //var visualizedModel = Visualizer.GetVisualizedModel<UserWalletModel>();
            parameter.Count--;
            parameter.IsAvailable = parameter.Count > 0;
            return parameter.Value;
        }
    }
}