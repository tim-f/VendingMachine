using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class BuyProductCommand : IChainCommand<MenuItemModel>
    {
        private IMachineOperations MachineOperations { get; }

        public BuyProductCommand(IMachineOperations machineOperations)
        {
            MachineOperations = machineOperations;
        }

        public void Execute(MenuItemModel parameter)
        {
            var depositAmount = MachineOperations.GetDepositAmount();
            if (depositAmount > parameter.Price)
            {
                
            }
        }
    }
}