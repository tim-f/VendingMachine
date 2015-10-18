using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class RequestChangeCommand : IChainCommand<CashDepositModel, CoinSet>
    {
        private IMachineOperations MachineOperations { get; }

        public RequestChangeCommand(IMachineOperations machineOperations)
        {
            MachineOperations = machineOperations;
        }

        public CoinSet Execute(CashDepositModel parameter)
        {
            CoinSet change = MachineOperations.RetrieveChange();
            parameter.Amount = decimal.Zero;
            parameter.HasPositiveBalance = false;
            return change;
        }
    }
}