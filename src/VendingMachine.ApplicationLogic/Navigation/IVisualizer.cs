namespace VendingMachine.ApplicationLogic.Navigation
{
    public interface IVisualizer
    {
        TAppModel Visualize<TAppModel>() where TAppModel : AppModel.AppModel, new();
        TAppModel GetVisualizedModel<TAppModel>() where TAppModel : AppModel.AppModel;
    }
}