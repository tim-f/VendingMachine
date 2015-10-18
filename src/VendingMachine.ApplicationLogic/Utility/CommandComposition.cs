using System;
using System.Collections.Generic;

namespace VendingMachine.ApplicationLogic.Utility
{
    public static class CommandComposition
    {
        public static IChainCommand<TInput> Fork<TInput>(this IChainCommand<TInput> firstCommand, IChainCommand<TInput> secondCommand)
        {
            ForkChainCommand<TInput> forkChainCommand = firstCommand as ForkChainCommand<TInput>;
            if (forkChainCommand == null)
            {
                forkChainCommand = new ForkChainCommand<TInput>();
                forkChainCommand.AddCommand(firstCommand);
            }
            forkChainCommand.AddCommand(secondCommand);
            return forkChainCommand;
        }

        public static IChainCommand<object> StartWith(IChainCommand command)
        {
            return new AnonymousChainedCommand<object>(o => command.Execute());
        }

        public static IChainCommand<object> StartWith<TInput>(Func<TInput> source, IChainCommand<TInput> command)
        {
            return new AnonymousChainedCommand<object>(o => command.Execute(source()));
        }

        public static IChainCommand<object, TOutput> StartWith<TInput, TOutput>(Func<TInput> source, IChainCommand<TInput, TOutput> command)
        {
            return new AnonymousChainedCommand<object, TOutput>(o => command.Execute(source()));
        }

        public static IChainCommand<TInput, TOutput> ContinueWith<TInput, TIntermediate, TOutput>(this IChainCommand<TInput, TIntermediate> firstCommand, Func<TIntermediate, TOutput> secondCommandExecute)
        {
            return new AnonymousChainedCommand<TInput, TOutput>(input => secondCommandExecute(firstCommand.Execute(input)));
        }

        public static IChainCommand<TInput> ContinueWith<TInput, TIntermediate>(this IChainCommand<TInput, TIntermediate> firstCommand, IChainCommand<TIntermediate> secondCommand)
        {
            return new AnonymousChainedCommand<TInput>(input => secondCommand.Execute(firstCommand.Execute(input)));
        }

        public static IChainCommand<TInput, TOutput> ContinueWith<TInput, TIntermediate, TOutput>(this IChainCommand<TInput, TIntermediate> firstCommand, IChainCommand<TIntermediate, TOutput> secondCommand)
        {
            return new AnonymousChainedCommand<TInput, TOutput>(input => secondCommand.Execute(firstCommand.Execute(input)));
        }


        private class ForkChainCommand<T> : IChainCommand<T>
        {
            private readonly List<IChainCommand<T>> _commands = new List<IChainCommand<T>>();

            public void AddCommand(IChainCommand<T> command)
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

        private class AnonymousChainedCommand<TInput> : IChainCommand<TInput>
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

        private class AnonymousChainedCommand<TInput, TOutput> : IChainCommand<TInput, TOutput>
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