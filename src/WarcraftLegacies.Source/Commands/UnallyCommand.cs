using MacroTools.Extensions;
using MacroTools.FactionSystem;


namespace WarcraftLegacies.Source.Commands
{
  /// <summary>
  ///   A command that causes a player to leave their <see cref="Team" /> and be given a solo Team with their
  ///   <see cref="Faction" /> as the name.
  /// </summary>
  public static class UnallyCommand
  {
    private const string Command = "-unally";

    private static void Actions()
    {
      var triggerPlayer = GetTriggerPlayer();
      triggerPlayer.GetFaction()?.Unally();
    }

    public static void Setup()
    {
      var trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) 
        TriggerRegisterPlayerChatEvent(trig, player, Command, true);

      TriggerAddAction(trig, Actions);
    }
  }
}