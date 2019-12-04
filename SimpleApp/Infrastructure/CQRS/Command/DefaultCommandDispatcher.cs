using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Infrastructure.CQRS.Command
{
    public interface ICommand
    {
    }

    public interface ICommandResult
    {
    }

    public interface ICommandDispatcher
    {
        Task<TCommandResult> ExecuteAsync<TCommand, TCommandResult>(TCommand command)
            where TCommand : class, ICommand
            where TCommandResult : class, ICommandResult, new();
    }

    public interface ICommandHandler<in TCommand, TCommandResult>
        where TCommand : class, ICommand
    {
        Task<TCommandResult> ExecuteAsync(TCommand command);
    }

    public class DefaultCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _service;

        public DefaultCommandDispatcher(IServiceProvider service)
        {
            _service = service;
        }

        public virtual async Task<TCommandResult> ExecuteAsync<TCommand, TCommandResult>(TCommand command)
            where TCommand : class, ICommand
            where TCommandResult : class, ICommandResult, new()
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var handler = (ICommandHandler<TCommand, TCommandResult>)_service.GetService(typeof(ICommandHandler<TCommand, TCommandResult>));
            var result = await handler.ExecuteAsync(command);
            return result;
        }
    }
}