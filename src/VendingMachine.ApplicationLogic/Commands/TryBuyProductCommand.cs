using System.Linq;
using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.ApplicationLogic.Utility;
using VendingMachine.Core.Services;

namespace VendingMachine.ApplicationLogic.Commands
{
    public class TryBuyProductCommand : IChainCommand<MenuItemModel, bool>
    {
        private IMachineOperations MachineOperations { get; }
        private INavigator Navigator { get; }

        public TryBuyProductCommand(IMachineOperations machineOperations, INavigator navigator)
        {
            MachineOperations = machineOperations;
            Navigator = navigator;
        }

        public bool Execute(MenuItemModel parameter)
        {
            var canBuyProduct = MachineOperations.CanBuyProduct(parameter.ProductId);
            if (!canBuyProduct)
            {
                return false;
            }

            MachineOperations.SellProduct(parameter.ProductId);
            UpdateMenu(parameter);
            UpdateDepositAmount();
            return true;
        }

        private void UpdateMenu(MenuItemModel menuItemModel)
        {
            var productList = MachineOperations.GetProductList();
            var productInfo = productList.Single(p => p.Id == menuItemModel.ProductId);
            menuItemModel.Count = productInfo.Count;
            menuItemModel.IsAvailable = productInfo.IsAvailable;
        }

        private void UpdateDepositAmount()
        {
            var cashDepositModel = Navigator.GetNavigatedModel<CashDepositModel>();
            cashDepositModel.Amount = MachineOperations.GetDepositAmount();
        }
    }
}