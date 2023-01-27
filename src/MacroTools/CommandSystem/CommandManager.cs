using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Cheats;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.CommandSystem
{
  /// <summary>
  /// Responsible for managing all <see cref="Command"/>s in the game.
  /// </summary>
  public sealed class CommandManager
  {
    private readonly List<Command> _registeredCommands = new();

    /// <summary>
    /// All <see cref="Command"/>s must be prefixed with this when entered into the chat.
    /// </summary>
    private const string Prefix = "-";

    /// <summary>
    /// Returns all registered <see cref="Command"/>s.
    /// </summary>
    public IEnumerable<Command> GetAllCommands() => _registeredCommands.AsReadOnly();

    /// <summary>
    /// Registers a <see cref="Command"/>, allowing it to be fired when a player executes its command in the chat.
    /// </summary>
    public void Register(Command command)
    {
      _registeredCommands.Add(command);
      command.OnRegister();
      CreateTrigger()
        .RegisterSharedChatEvent(Prefix + command.CommandText, false)
        .AddAction(() =>
        {
          try
          {
            if (command.Type == CommandType.Cheat && !TestMode.CheatCondition())
              return;

            var parameters = SplitParameters(GetEventPlayerChatString());

            if (parameters.Length < command.MinimumParameterCount)
            {
              DisplayTextToPlayer(GetTriggerPlayer(), 0, 0,
                $"You must supply at least {command.MinimumParameterCount} parameters. If you're trying to use a parameter with multiple words, try enclosing it in quotes.");
              return;
            }

            var message = command.Execute(GetTriggerPlayer(), parameters);
            DisplayTextToPlayer(GetTriggerPlayer(), 0, 0,
              command.Type == CommandType.Cheat ? $"|cffD27575CHEAT:|r {message}" : $"{message}");
          }
          catch (Exception ex)
          {
            Console.WriteLine($"Failed to execute command: {ex}");
          }
        });
    }

    private static string[] SplitParameters(string inputString)
    {
      return inputString.Split('"')
        .Select((element, index) => index % 2 == 0
          ? element.Split(' ', StringSplitOptions.RemoveEmptyEntries)
          : new string[] { element })
        .SelectMany(element => element)
        .Skip(1)
        .ToArray();
    }
  }
}