using System.Windows.Input;
using VendingMachine.ApplicationLogic.Utility;

namespace VendingMachine.Presentation.Wpf.Utility
{
    public static class CommandWrapper
    {
        public static ICommand Wrap(this IChainCommand command)
        {
            return new CommandAdapter(command);
        }

        public static ICommand Wrap<TInput>(this IChainCommand<TInput> command)
        {
            return new CommandAdapter<TInput>(command);
        }

        public static ICommand Wrap<TInput, TOutput>(this IChainCommand<TInput, TOutput> command)
        {
            return new CommandAdapter<TInput, TOutput>(command);
        }

        private class CommandAdapter : AlwaysEnabledCommand
        {
            private readonly IChainCommand _command;

            public CommandAdapter(IChainCommand command)
            {
                _command = command;
            }

            protected override void Execute()
            {
                _command.Execute();
            }
        }

        private class CommandAdapter<TInput> : AlwaysEnabledCommand<TInput>
        {
            private readonly IChainCommand<TInput> _command;

            public CommandAdapter(IChainCommand<TInput> command)
            {
                _command = command;
            }

            protected override void Execute(TInput parameter)
            {
                _command.Execute(parameter);
            }
        }

        private class CommandAdapter<TInput, TOutput> : AlwaysEnabledCommand<TInput>
        {
            private readonly IChainCommand<TInput, TOutput> _command;

            public CommandAdapter(IChainCommand<TInput, TOutput> command)
            {
                _command = command;
            }

            protected override void Execute(TInput parameter)
            {
                _command.Execute(parameter);
            }
        }
    }
}