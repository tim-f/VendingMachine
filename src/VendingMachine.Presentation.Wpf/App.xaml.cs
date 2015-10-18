using System;
using System.Windows.Input;
using VendingMachine.Presentation.Wpf.Utility;

namespace VendingMachine.Presentation.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public sealed partial class App
    {
        private static readonly Lazy<UiCommandFactory> Factory = new Lazy<UiCommandFactory>(() => new UiCommandFactory(new AppServices()));
        public static UiCommandFactory CommandFactory => Factory.Value;
    }
}
