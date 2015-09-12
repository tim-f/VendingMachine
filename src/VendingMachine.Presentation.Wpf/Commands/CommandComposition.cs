using System;
using System.Collections.Generic;

namespace VendingMachine.Presentation.Wpf.Commands
{
    public static class CommandComposition
    {
        public static IActionCommand<TInput> Fork<TInput>(this IActionCommand<TInput> firstCommand, IActionCommand<TInput> secondCommand)
        {
            ForkActionCommand<TInput> forkActionCommand = firstCommand as ForkActionCommand<TInput>;
            if (forkActionCommand == null)
            {
                forkActionCommand = new ForkActionCommand<TInput>();
                forkActionCommand.AddCommand(firstCommand);
            }
            forkActionCommand.AddCommand(secondCommand);
            return forkActionCommand;
        }

        public static IActionCommand<object> StartWith<TInput>(Func<TInput> source, IActionCommand<TInput> command)
        {
            return new AnonymousChainedCommand<object>(o => command.Execute(source()));
        }

        public static IActionCommand<object, TOutput> StartWith<TInput, TOutput>(Func<TInput> source, IActionCommand<TInput, TOutput> command)
        {
            return new AnonymousChainedCommand<object, TOutput>(o => command.Execute(source()));
        }

        public static IActionCommand<TInput, TOutput> ContinueWith<TInput, TIntermediate, TOutput>(this IActionCommand<TInput, TIntermediate> firstCommand, Func<TIntermediate, TOutput> secondCommandExecute)
        {
            return new AnonymousChainedCommand<TInput, TOutput>(input => secondCommandExecute(firstCommand.Execute(input)));
        }

        public static IActionCommand<TInput> ContinueWith<TInput, TIntermediate>(this IActionCommand<TInput, TIntermediate> firstCommand, IActionCommand<TIntermediate> secondCommand)
        {
            return new AnonymousChainedCommand<TInput>(input => secondCommand.Execute(firstCommand.Execute(input)));
        }

        public static IActionCommand<TInput, TOutput> ContinueWith<TInput, TIntermediate, TOutput>(this IActionCommand<TInput, TIntermediate> firstCommand, IActionCommand<TIntermediate, TOutput> secondCommand)
        {
            return new AnonymousChainedCommand<TInput, TOutput>(input => secondCommand.Execute(firstCommand.Execute(input)));
        }


        private class ForkActionCommand<T> : IActionCommand<T>
        {
            private readonly List<IActionCommand<T>> _commands = new List<IActionCommand<T>>();

            public void AddCommand(IActionCommand<T> command)
            {
                _commands.Add(command);
            }

            public void Execute(T parameter)
            {
                foreach (var command in _commands)
                {
                    command.Execute(parameter);
                }
            }
        }

        private class AnonymousChainedCommand<TInput> : IActionCommand<TInput>
        {
            private readonly Action<TInput> _executeDelegate;

            public AnonymousChainedCommand(Action<TInput> executeDelegate)
            {
                _executeDelegate = executeDelegate;
            }

            public void Execute(TInput parameter)
            {
                _executeDelegate(parameter);
            }
        }

        private class AnonymousChainedCommand<TInput, TOutput> : IActionCommand<TInput, TOutput>
        {
            private readonly Func<TInput, TOutput> _executeDelegate;

            public AnonymousChainedCommand(Func<TInput, TOutput> executeDelegate)
            {
                _executeDelegate = executeDelegate;
            }

            public TOutput Execute(TInput parameter)
            {
                return _executeDelegate(parameter);
            }
        }

    }
}