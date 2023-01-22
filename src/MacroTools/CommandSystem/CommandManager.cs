using System;
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
    /// <summary>
    /// All <see cref="Command"/>s must be prefixed with this when entered into the chat.
    /// </summary>
    private const string Prefix = "-";
    
    /// <summary>
    /// Registers a <see cref="Command"/>, allowing it to be fired when a player executes its command in the chat.
    /// </summary>
    public void Register(Command command)
    {
      command.OnRegister();
      CreateTrigger()
        .RegisterSharedChatEvent(Prefix + command.CommandText, false)
        .AddAction(() =>
        {
          try
          {
            if (command.Type == CommandType.Cheat && !TestMode.CheatCondition())
              return;
            
            var parameters = GetEventPlayerChatString().Split(" ").Skip(1).ToArray();
            if (parameters.Length != command.ParameterCount)
            {
              DisplayTextToPlayer(GetTriggerPlayer(), 0, 0, $"You must supply exactly {command.ParameterCount} parameters.");
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
  }
}