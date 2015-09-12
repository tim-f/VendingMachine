using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace VendingMachine.Presentation.Wpf.AppModel
{
    public abstract class AppModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}