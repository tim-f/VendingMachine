using System.Windows.Input;

namespace VendingMachine.Presentation.Wpf.Views
{
    /// <summary>
    /// Interaction logic for GoodsMenuPage.xaml
    /// </summary>
    public partial class GoodsMenuPage
    {
        public GoodsMenuPage()
        {
            InitializeComponent();
        }

        public ICommand BuyProductCommand => App.CommandFactory.BuyProduct;
    }
}
