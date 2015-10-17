using VendingMachine.ApplicationLogic.AppModel;

namespace VendingMachine.Presentation.Wpf.Views
{
    /// <summary>
    /// Interaction logic for GoodsMenuPage.xaml
    /// </summary>
    public partial class GoodsMenuPage
    {
        public GoodsMenuPage(GoodsMenu goodsMenu)
        {
            InitializeComponent();
            DataContext = goodsMenu;
        }
    }
}
