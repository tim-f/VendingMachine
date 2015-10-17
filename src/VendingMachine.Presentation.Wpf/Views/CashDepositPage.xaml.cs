using VendingMachine.ApplicationLogic.AppModel;

namespace VendingMachine.Presentation.Wpf.Views
{
    /// <summary>
    /// Interaction logic for CashDepositPage.xaml
    /// </summary>
    public partial class CashDepositPage
    {
        public CashDepositPage(CashDeposit cashDeposit)
        {
            InitializeComponent();
            DataContext = cashDeposit;
        }
    }
}
