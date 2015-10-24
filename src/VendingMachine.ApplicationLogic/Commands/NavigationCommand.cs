using System;
using System.Threading.Tasks;
using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.Core.Services;

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
            OnNavigatedTo(parameter);

            using (AnonymousDisposable.Create(OnNavigatedFrom, parameter))
            {
                return await Navigator.NavigateAsync(parameter);
            }
        }

        protected abstract void OnNavigatedTo(TAppModel model);
        protected abstract void OnNavigatedFrom(TAppModel model);

        private class AnonymousDisposable : IDisposable
        {
            private readonly Action<TAppModel> _dispose;
            private readonly TAppModel _parameter;

            private AnonymousDisposable(Action<TAppModel> dispose, TAppModel parameter)
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
                return new AnonymousDisposable(dispose, parameter);
            }
        }
    }

    class NavigateToUserWallet : NavigationCommand<UserWalletModel>
    {
        private readonly IUserWallet _userWallet;

        public NavigateToUserWallet(INavigator navigator, IUserWallet userWallet) : base(navigator)
        {
            _userWallet = userWallet;
        }

        protected override void OnNavigatedTo(UserWalletModel model)
        {
            throw new NotImplementedException();
        }

        protected override void OnNavigatedFrom(UserWalletModel model)
        {
            throw new NotImplementedException();
        }
    }
}