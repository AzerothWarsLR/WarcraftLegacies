﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    private const string CommandColor = "cffD27575";
    private readonly List<Command> _registeredCommands = new();

    /// <summary>
    /// All <see cref="Command"/>s must be prefixed with this when entered into the chat.
    /// </summary>
    private const string Prefix = "-";

    /// <summary>
    /// Returns all registered <see cref="Command"/>s.
    /// </summary>
    public ReadOnlyCollection<Command> GetAllCommands() => _registeredCommands.AsReadOnly();

    /// <summary>
    /// Registers a <see cref="Command"/>, allowing it to be fired when a player executes its command in the chat.
    /// </summary>
    public void Register(Command command)
    {
      _registeredCommands.Add(command);
      command.OnRegister();
      CreateTrigger()
        .RegisterSharedChatEvent($"{Prefix}{command.CommandText}", command.ExpectedParameterCount.Maximum == 0)
        .AddAction(() =>
        {
          try
          {
            if (command.Type == CommandType.Cheat && !TestMode.CheatCondition(GetTriggerPlayer()))
              return;

            var enteredChatString = GetEventPlayerChatString();
            if (!EnteredCommandEndsWithSpaceOrNothing(command, enteredChatString)) 
              return;

            var parameters = SplitParameters(command, enteredChatString);

            if (parameters.Length < command.ExpectedParameterCount.Minimum)
            {
              DisplayTextToPlayer(GetTriggerPlayer(), 0, 0,
                $"|{CommandColor}{command.CommandText}:|r You must supply at least {command.ExpectedParameterCount.Minimum} parameters. If you're trying to use a parameter with multiple words, try enclosing it in quotes.");
              return;
            }

            var message = command.Execute(GetTriggerPlayer(), parameters);
            DisplayTextToPlayer(GetTriggerPlayer(), 0, 0,
              command.Type == CommandType.Cheat ? $"|{CommandColor}CHEAT:|r {message}" : $"|{CommandColor}{command.CommandText}:|r {message}");
          }
          catch (Exception ex)
          {
            Console.WriteLine($"Failed to execute command: {ex}");
          }
        });
    }

    /// <summary>Creates a dummy quest that players can read to see the available commands.</summary>
    public void CreateInfoQuest()
    {
      var commandQuest = CreateQuest();
      QuestSetTitle(commandQuest, "Commands");
      QuestSetIconPath(commandQuest, @"ReplaceableTextures\CommandButtons\BTNDizzy.blp");
      QuestSetEnabled(commandQuest, true);
      QuestSetRequired(commandQuest, false);
      var description = _registeredCommands.Where(x => x.Type == CommandType.Normal).Aggregate("",
        (current, command) => $"{current} -{command.CommandText}: {command.Description}\n");
      
      QuestSetDescription(commandQuest, description);
    }

    private static bool EnteredCommandEndsWithSpaceOrNothing(Command command, string enteredChatString)
    {
      var commandLength = command.CommandText.Length + Prefix.Length;
      return enteredChatString.Length == commandLength ||
             enteredChatString[commandLength] == ' ';
    }

    private static string[] SplitParameters(Command command, string inputString)
    {
      //If there is only one parameter allowed, just ignore quotation marks and assume everything after the command
      //is a single parameter.
      if (command.ExpectedParameterCount.Maximum == 1)
      {
        var commandLength = command.CommandText.Length + Prefix.Length + 1;
        return new string[]
        {
          inputString.Substring(commandLength).Replace("\"", string.Empty)
        };
      }

      //First split by quotation marks, then by spaces, then remove the first word.
      //E.g. -team "Fel Horde" Alliance should return the parameters Fel Horde and Alliance.
      return inputString
        .Split('"')
        .Select((element, index) => index % 2 == 0
          ? element.Split(' ', StringSplitOptions.RemoveEmptyEntries)
          : new string[] { element })
        .SelectMany(element => element)
        .Skip(1)
        .ToArray();
    }
  }
}