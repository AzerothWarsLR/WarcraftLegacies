using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;

namespace WarcraftLegacies.Source.Commands
{
  /// <summary>
  /// When a player types the command, they get removed from the game and made into an observer.
  /// </summary>
  public static class ObserverCommand
  {
    private const string Command = "-obs";
    private static Team? _observers;

    /// <summary>
    /// Sets up the observer command.
    /// </summary>
    public static void Setup()
    {
      var trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) 
        TriggerRegisterPlayerChatEvent(trig, player, Command, true);
      TriggerAddAction(trig, Actions);
      _observers = new Team("Observers");
      FactionManager.Register(_observers);
    }
    
    private static void Actions()
    {
      var triggerFaction = GetTriggerPlayer().GetFaction();
      if (triggerFaction == null)
      {
        throw new InvalidOperationException(
          $"{GetPlayerName(GetTriggerPlayer())} tried to execute {nameof(ObserverCommand)}, but they don't have a {nameof(Faction)}.");
      }
      
      triggerFaction.Defeat();
      triggerFaction.Player?.SetTeam(_observers!);
    }
  }
}