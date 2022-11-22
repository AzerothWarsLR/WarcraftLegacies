using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Wrappers;
using static War3Api.Common;

namespace MacroTools.CommandSystem
{
  /// <summary>
  /// Responsible for managing all <see cref="Command"/>s in the game.
  /// </summary>
  public static class CommandManager
  {
    private static readonly Dictionary<string, Command> CheatsByCommand = new();
    private static readonly TriggerWrapper CheatTrigger = new();
    
    /// <summary>
    /// A piece of text to be appended before any message relating to cheats.
    /// </summary>
    private const string CheatMessagePrefix = "|cffD27575CHEAT:|r";
    
    /// <summary>
    /// All <see cref="Command"/>s must be prefixed with this when entered into the chat.
    /// </summary>
    private const string Prefix = "-";
    
    /// <summary>
    /// Registers a <see cref="Command"/>, allowing it to be fired when a player executes its command in the chat.
    /// </summary>
    public static void Register(Command command)
    {
      CheatsByCommand.Add(Prefix + command.CommandText, command);
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) 
        CheatTrigger.RegisterPlayerChatEvent(player, Prefix + command.CommandText, false);
    }

    private static void ExecuteCheat()
    {
      try
      {
        var split = GetEventPlayerChatString().Split(" ");
        var command = split[0];
        if (!CheatsByCommand.TryGetValue(command, out var cheat)) 
          return;
        var triggerPlayer = GetTriggerPlayer();
        var parameters = split.Skip(1).ToArray();
        if (parameters.Length != cheat.ParameterCount)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, $"{CheatMessagePrefix} You must supply exactly {cheat.ParameterCount} parameters.");
          return;
        }
        var message = cheat.Execute(triggerPlayer, parameters);
        DisplayTextToPlayer(triggerPlayer, 0, 0, $"{CheatMessagePrefix} {message}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute command: {ex}");
      }
    }

    static CommandManager()
    {
      CheatTrigger.AddAction(ExecuteCheat);
    }
  }
}