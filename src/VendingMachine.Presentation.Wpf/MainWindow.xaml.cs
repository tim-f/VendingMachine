using VendingMachine.ApplicationLogic.Commands;
using VendingMachine.Presentation.Wpf.Navigation;

namespace VendingMachine.Presentation.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var startAppCommand = new StartAppCommand(new Visualizer());
            startAppCommand.Execute();
        }
    }
}
