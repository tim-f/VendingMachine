using VendingMachine.ApplicationLogic.AppModel;

namespace VendingMachine.Presentation.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MachineWalletPage.xaml
    /// </summary>
    public partial class MachineWalletPage
    {
        public MachineWalletPage(MachineWallet machineWallet)
        {
            InitializeComponent();
            DataContext = machineWallet;
        }
    }
}
