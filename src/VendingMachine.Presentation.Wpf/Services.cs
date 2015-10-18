using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.Core.Services;
using VendingMachine.Presentation.Wpf.Navigation;

namespace VendingMachine.Presentation.Wpf
{
    public class AppServices
    {
        public IUserWallet UserWallet { get; } = new UserWallet();
        public IMachineOperations MachineOperations { get; } = new MachineOperations();
        public IVisualizer Visualizer { get; } = new Visualizer();

        public AppServices()
        {
            //IUserWallet userWallet = new UserWallet();
            //IMachineOperations machineOperations = new MachineOperations();
            //IVisualizer visualizer = new Visualizer();
        }
    }
}