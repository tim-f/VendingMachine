using System.Windows.Input;

namespace VendingMachine.Presentation.Wpf.Commands
{
    public static class CommandWrapper
    {
        public static ICommand Wrap(this IActionCommand command)
        {
            return new CommandAdapter(command);
        }

        public static ICommand Wrap<TInput>(this IActionCommand<TInput> command)
        {
            return new CommandAdapter<TInput>(command);
        }

        public static ICommand Wrap<TInput, TOutput>(this IActionCommand<TInput, TOutput> command)
        {
            return new CommandAdapter<TInput, TOutput>(command);
        }

        private class CommandAdapter : AlwaysEnabledCommand
        {
            private readonly IActionCommand _command;

            public CommandAdapter(IActionCommand command)
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
            private readonly IActionCommand<TInput> _command;

            public CommandAdapter(IActionCommand<TInput> command)
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
            private readonly IActionCommand<TInput, TOutput> _command;

            public CommandAdapter(IActionCommand<TInput, TOutput> command)
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