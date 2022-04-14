using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Game_Logic;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Commands
{
  public static class BootCommand
  {
    private const string COMMAND = "-boot ";

    private static void Actions()
    {
      string enteredString = GetEventPlayerChatString();
      var triggerPlayer = GetTriggerPlayer();

      if (SubString(enteredString, 0, StringLength(COMMAND)) == COMMAND)
      {
        string content = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
        content = StringCase(content, false);
        Faction targetFaction = FactionManager.GetFromName(content);

        if (triggerPlayer.GetFaction() != NagaSetup.FactionNaga)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "This command can only be used by liege factions.");
          return;
        }

        if (OpenAllianceVote.AreAlliancesOpen)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "Alliances are open");
          return;
        }

        if (targetFaction == null)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "There is no Faction with the name " + content + ".");
          return;
        }

        if (triggerPlayer.GetFaction() == targetFaction)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, "You can'boot yourself from the game.");
          return;
        }

        if (targetFaction.Player == null)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0,
            "There is no player with the Faction " + targetFaction.ColoredName + ".");
          return;
        }

        if (FelHordeSetup.FactionFelHorde.Team != TeamSetup.Naga)
        {
          DisplayTextToPlayer(triggerPlayer, 0, 0, $"{targetFaction.ColoredName} isn't your vassal.");
          return;
        }

        if (targetFaction.Player != null)
        {
          targetFaction.Obliterate();
          targetFaction.Player.SetFaction(null);
        }
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      TriggerAddAction(trig, Actions);
    }
  }
}