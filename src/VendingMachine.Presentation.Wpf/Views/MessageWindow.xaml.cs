namespace VendingMachine.Presentation.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow
    {
        public MessageWindow()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return MessageText.Text; }
            set { MessageText.Text = value; }
        }
    }
}
