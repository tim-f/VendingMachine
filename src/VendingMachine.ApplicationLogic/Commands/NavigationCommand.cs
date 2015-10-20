using System;
using System.Threading.Tasks;
using VendingMachine.ApplicationLogic.Navigation;

namespace VendingMachine.ApplicationLogic.Commands
{
    public abstract class NavigationCommand<TAppModel> where TAppModel : AppModel.AppModel, new()
    {
        private INavigator Navigator { get; }

        public NavigationCommand(INavigator navigator)
        {
            Navigator = navigator;
        }

        public async Task<NavigationResult> Execute(TAppModel parameter)
        {
            BeginNavigation(parameter);

            using (Disposable.Create(EndNavigation, parameter))
            {
                return await Navigator.NavigateAsync(parameter);
            }
        }

        protected abstract void BeginNavigation(TAppModel model);
        protected abstract void EndNavigation(TAppModel model);

        
        

        private class Disposable : IDisposable
        {
            private readonly Action<TAppModel> _dispose;
            private readonly TAppModel _parameter;

            public Disposable(Action<TAppModel> dispose, TAppModel parameter)
            {
                _dispose = dispose;
                _parameter = parameter;
            }

            public void Dispose()
            {
                _dispose(_parameter);
            }

            public static IDisposable Create(Action<TAppModel> dispose, TAppModel parameter)
            {
                return new Disposable(dispose, parameter);
            }
        }
    }
}