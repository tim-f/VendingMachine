namespace VendingMachine.ApplicationLogic.Utility
{
    public interface IChainCommand
    {
        void Execute();
    }

    public interface IChainCommand<in TInput>
    {
        void Execute(TInput parameter);
    }

    public interface IChainCommand<in TInput, out TOutput>
    {
        TOutput Execute(TInput parameter);
    }
}