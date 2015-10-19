using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using JetBrains.Annotations;
using VendingMachine.ApplicationLogic.AppModel;
using VendingMachine.ApplicationLogic.Navigation;
using VendingMachine.Presentation.Wpf.Views;

namespace VendingMachine.Presentation.Wpf.Navigation
{
    internal sealed class Navigator : INavigator
    {
        [NotNull]
        private MainWindow MainWindow => ((MainWindow)Application.Current.MainWindow);

        [NotNull]
        private Frame UserWalletFrame => MainWindow.UserWallet;

        [NotNull]
        private Frame MachineWalletFrame => MainWindow.MachineWallet;

        [NotNull]
        private Frame CashDepositFrame => MainWindow.CashDeposit;

        [NotNull]
        private Frame GoodsMenuFrame => MainWindow.GoodsMenu;

        private Dictionary<Type, AppModel> VisualizedAppModels { get; } = new Dictionary<Type, AppModel>();

        public TAppModel Navigate<TAppModel>() where TAppModel : AppModel, new()
        {
            Frame hostFrame;
            Page hostView;

            if (typeof(TAppModel) == typeof(UserWalletModel))
            {
                hostFrame = UserWalletFrame;
                hostView = new UserWalletPage();
            }
            else if (typeof(TAppModel) == typeof(MachineWalletModel))
            {
                hostFrame = MachineWalletFrame;
                hostView = new MachineWalletPage();
            }
            else if (typeof(TAppModel) == typeof(GoodsMenuModel))
            {
                hostFrame = GoodsMenuFrame;
                hostView = new GoodsMenuPage();
            }
            else if (typeof(TAppModel) == typeof(CashDepositModel))
            {
                hostFrame = CashDepositFrame;
                hostView = new CashDepositPage();
            }
            else
            {
                throw new InvalidOperationException("Unsupported AppModel type.");
            }

            var appModel = new TAppModel();
            hostView.DataContext = appModel;
            hostFrame.Navigate(hostView);
            VisualizedAppModels.Add(typeof(TAppModel), appModel);
            return appModel;
        }

        public TAppModel GetNavigatedModel<TAppModel>() where TAppModel : AppModel
        {
            AppModel appModel;
            if (!VisualizedAppModels.TryGetValue(typeof(TAppModel), out appModel))
            {
                throw new InvalidOperationException("Unsupported AppModel type.");
            }
            return (TAppModel)appModel;
        }

    }
}