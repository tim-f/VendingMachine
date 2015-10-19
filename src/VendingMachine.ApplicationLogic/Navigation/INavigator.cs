namespace VendingMachine.ApplicationLogic.Navigation
{
    public interface INavigator
    {
        TAppModel Navigate<TAppModel>() where TAppModel : AppModel.AppModel, new();
        TAppModel GetNavigatedModel<TAppModel>() where TAppModel : AppModel.AppModel;
    }
}