using System.Diagnostics;
using BookingPlatform.Application.Abstractions;
using Humanizer;
using Microsoft.Extensions.Logging;

namespace BookingPlatform.Infrastructure.DAL.Decorators;

internal sealed class LoggingCommandHandlerDecorator<TCommand> :
    ICommandHandler<TCommand> where TCommand : class, ICommand
{
    private readonly ICommandHandler<TCommand> _commandHandler;
    private readonly ILogger<TCommand> _logger;

    public LoggingCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler, ILogger<TCommand> logger)
    {
        _commandHandler = commandHandler;
        _logger = logger;
    }

    public async Task HandleAsync(TCommand command)
    {
        var commandName = typeof(TCommand).Name.Underscore();
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        _logger.LogInformation("Started handling a command: {CommandName}...", commandName);
        await _commandHandler.HandleAsync(command);
        _logger.LogInformation("Completed handling a command: {CommandName} in {Elapsed}",
            commandName, stopwatch.Elapsed);
    }
}