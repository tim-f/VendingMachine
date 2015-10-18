using System.Windows.Input;

namespace VendingMachine.Presentation.Wpf.Views
{
    /// <summary>
    /// Interaction logic for UserWalletPage.xaml
    /// </summary>
    public sealed partial class UserWalletPage
    {
        public UserWalletPage()
        {
            InitializeComponent();

            //new TakeCoinFromUserWalletCommand(null, null).ContinueWith(new PutCoinIntoMachineCommand())
            //PutCoinIntoMachineCommand = 
            DepositCoinCommand = App.CommandFactory.DepositCoinCommand;
        }

        protected ICommand DepositCoinCommand;
    }
}
