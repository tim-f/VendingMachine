using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class PrepareUserWalletCommand : IChainCommand
    {
        private readonly IVisualizer _visualizer;

        public PrepareUserWalletCommand(IVisualizer visualizer)
        {
            _visualizer = visualizer;
        }

        public void Execute()
        {
            var userWallet = _visualizer.GetVisualizedModel<UserWallet>();
            userWallet.Coins.Add(new Coin { Value = 1M, Count = 10, IsAvailable = true });
            userWallet.Coins.Add(new Coin { Value = 2M, Count = 10, IsAvailable = true });
            userWallet.Coins.Add(new Coin { Value = 5M, Count = 10, IsAvailable = true });
            userWallet.Coins.Add(new Coin { Value = 10M, Count = 10, IsAvailable = true });
        }
    }
}