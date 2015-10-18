using System.Windows.Input;

namespace VendingMachine.Presentation.Wpf.Views
{
    /// <summary>
    /// Interaction logic for CashDepositPage.xaml
    /// </summary>
    public partial class CashDepositPage
    {
        public CashDepositPage()
        {
            InitializeComponent();
        }

        public ICommand TakeChangeCommand => App.CommandFactory.TakeChange;
    }
}
