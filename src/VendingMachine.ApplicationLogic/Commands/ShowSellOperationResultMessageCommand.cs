using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class ShowSellOperationResultMessageCommand : IChainCommand<bool>
    {
        private readonly INavigator _navigator;

        public ShowSellOperationResultMessageCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public void Execute(bool parameter)
        {
            string message = parameter ? "Спасибо!" : "Недостаточно средств.";

            _navigator.ShowMessage(message);
        }
    }
}