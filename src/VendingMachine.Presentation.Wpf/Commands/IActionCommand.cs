namespace VendingMachine.Presentation.Wpf.Commands
{
    public interface IActionCommand
    {
        void Execute();
    }

    public interface IActionCommand<in TInput>
    {
        void Execute(TInput parameter);
    }

    public interface IActionCommand<in TInput, out TOutput>
    {
        TOutput Execute(TInput parameter);
    }
}