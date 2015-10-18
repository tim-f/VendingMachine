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
    internal sealed class Visualizer : IVisualizer
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


        //public void ShowUserWallet(UserWallet userWallet)
        //{
        //    UserWalletFrame.Navigate(new UserWalletPage(userWallet), userWallet);
        //}

        //public void ShowMachineWallet(MachineWallet machineWallet)
        //{
        //    MachineWalletFrame.Navigate(new MachineWalletPage(machineWallet));
        //}

        //public void ShowCashDeposit(CashDeposit cashDeposit)
        //{
        //    CashDepositFrame.Navigate(new CashDepositPage(cashDeposit));
        //}

        //public void ShowGoodsMenu(GoodsMenu goodsMenu)
        //{
        //    GoodsMenuFrame.Navigate(new GoodsMenuPage(goodsMenu));
        //}

        public TAppModel Visualize<TAppModel>() where TAppModel : AppModel, new()
        {
            Frame hostFrame;
            Page hostView;

            if (typeof(TAppModel) == typeof(UserWallet))
            {
                hostFrame = UserWalletFrame;
                hostView = new UserWalletPage();
            }
            else if (typeof(TAppModel) == typeof(MachineWallet))
            {
                hostFrame = MachineWalletFrame;
                hostView = new MachineWalletPage();
            }
            else if (typeof(TAppModel) == typeof(GoodsMenu))
            {
                hostFrame = GoodsMenuFrame;
                hostView = new GoodsMenuPage();
            }
            else if (typeof(TAppModel) == typeof(CashDeposit))
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

        public TAppModel GetVisualizedModel<TAppModel>() where TAppModel : AppModel
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