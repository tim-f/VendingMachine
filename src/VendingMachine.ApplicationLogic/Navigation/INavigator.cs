using System.Threading.Tasks;
using VendingMachine.ApplicationLogic.Commands;

namespace VendingMachine.ApplicationLogic.Navigation
{
    public interface INavigator
    {
        TAppModel Navigate<TAppModel>() where TAppModel : AppModel.AppModel, new();
        TAppModel GetNavigatedModel<TAppModel>() where TAppModel : AppModel.AppModel;
        void ShowMessage(string message);

        Task<NavigationResult> NavigateAsync<TAppModel>(TAppModel model) where TAppModel : AppModel.AppModel;
    }

    public class NavigationResult
    {
    }

}