using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.Core;
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
            //OnNavigatedTo(parameter);

            //using (AnonymousDisposable.Create(OnNavigatedFrom, parameter))
            //{
            //    return await Navigator.NavigateAsync(parameter);
            //}

            using (SubscribeToModelUpdates(parameter))
            {
                return await Navigator.NavigateAsync(parameter);
            }
        }

        protected abstract IDisposable SubscribeToModelUpdates(TAppModel appModel);

        //protected abstract void OnNavigatedTo(TAppModel model);
        //protected abstract void OnNavigatedFrom(TAppModel model);

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
        private readonly IUserWalletDecoraptor _userWallet;

        public NavigateToUserWallet(INavigator navigator, IUserWalletDecoraptor userWallet) : base(navigator)
        {
            _userWallet = userWallet;
        }

        //protected override void OnNavigatedTo(UserWalletModel model)
        //{
        //    _userWallet.CoinTaken += (sender, args) =>
        //    {
        //        var availableCoins = _userWallet.GetAvailableCoins();
        //        model.Coins.Clear();
        //        foreach (var coinInfo in availableCoins.Coins)
        //        {
        //            model.Coins.Add(new CoinModel { Value = coinInfo.Key.Value, Count = coinInfo.Value, IsAvailable = coinInfo.Value > 0 });
        //        }

        //    };
        //    //_userWallet.CoinTaken += UpdateUserWallet;
        //    //_userWallet.ChangeReturned += UpdateUserWallet;

        //    IDisposable subscription = _userWallet.WalletObservable.Subscribe(_ =>
        //    {
        //        var availableCoins = _userWallet.GetAvailableCoins();
        //        model.Coins.Clear();
        //        foreach (var coinInfo in availableCoins.Coins)
        //        {
        //            model.Coins.Add(new CoinModel { Value = coinInfo.Key.Value, Count = coinInfo.Value, IsAvailable = coinInfo.Value > 0 });
        //        }
        //    });
        //}

        //protected override void OnNavigatedFrom(UserWalletModel model)
        //{
        //    //_userWallet.CoinTaken -= UpdateUserWallet;
        //    //_userWallet.ChangeReturned -= UpdateUserWallet;
        //}
        protected override IDisposable SubscribeToModelUpdates(UserWalletModel appModel)
        {
            IDisposable subscription = _userWallet.WalletObservable.Subscribe(_ =>
            {
                var availableCoins = _userWallet.GetAvailableCoins();
                appModel.Coins.Clear();
                foreach (var coinInfo in availableCoins.Coins)
                {
                    appModel.Coins.Add(new CoinModel { Value = coinInfo.Key.Value, Count = coinInfo.Value, IsAvailable = coinInfo.Value > 0 });
                }
            });
            return subscription;
        }
    }

    public interface IUserWalletDecoraptor : IUserWallet
    {
        IObservable<object> WalletObservable { get; }
        event EventHandler CoinTaken;
        event EventHandler ChangeReturned;
    }

    public class UserWalletDecoraptor : IUserWalletDecoraptor
    {
        private IUserWallet UserWallet { get; }
        private Subject<object> WalletSubject { get; } = new Subject<object>();

        public UserWalletDecoraptor(IUserWallet userWallet)
        {
            UserWallet = userWallet;
        }

        public void PutChangeBack(CoinSet coinSet)
        {
            UserWallet.PutChangeBack(coinSet);
            ChangeReturned?.Invoke(this, EventArgs.Empty);
            WalletSubject.OnNext(null);
        }

        public void TakeCoin(Coin coin)
        {
            UserWallet.TakeCoin(coin);
            CoinTaken?.Invoke(this, EventArgs.Empty);
            WalletSubject.OnNext(null);
        }

        public decimal CalculateTotalAmount()
        {
            return UserWallet.CalculateTotalAmount();
        }

        public CoinSet GetAvailableCoins()
        {
            return UserWallet.GetAvailableCoins();
        }

        public IObservable<object> WalletObservable => WalletSubject.AsObservable();
        public event EventHandler CoinTaken;
        public event EventHandler ChangeReturned;
    }


    //public interface IMachineOperationsObservableDecorator : IMachineOperations
    //{
    //    event EventArgs 
    //}

    //class MachineOperationsObservableDecorator : IMachineOperationsObservableDecorator
    //{
    //    private IMachineOperations MachineOperations { get; }

    //    public MachineOperationsObservableDecorator(IMachineOperations machineOperations)
    //    {
    //        MachineOperations = machineOperations;
    //    }

    //    public void DepositCoin(Coin coin)
    //    {
    //        MachineOperations.DepositCoin(coin);
    //    }

    //    public decimal GetDepositAmount()
    //    {
    //        return MachineOperations.GetDepositAmount();
    //    }

    //    public CoinSet RetrieveChange()
    //    {
    //        return MachineOperations.RetrieveChange();
    //    }

    //    public CoinSet GetAvailableCoins()
    //    {
    //        return MachineOperations.GetAvailableCoins();
    //    }

    //    public IReadOnlyCollection<ProductInfo> GetProductList()
    //    {
    //        return MachineOperations.GetProductList();
    //    }

    //    public bool HasProduct(Guid productId)
    //    {
    //        return MachineOperations.HasProduct(productId);
    //    }

    //    public bool CanBuyProduct(Guid productId)
    //    {
    //        return MachineOperations.CanBuyProduct(productId);
    //    }

    //    public void SellProduct(Guid productId)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}