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

            App.CommandFactory.StartAppCommand.Execute(null);
        }
    }
}
