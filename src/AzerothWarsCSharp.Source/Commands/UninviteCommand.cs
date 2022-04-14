using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  ///   Revokes an invitation sent to a player from the sending player's <see cref="Team" />.
  /// </summary>
  public static class UninviteCommand
  {
    private const string COMMAND = "-uninvite ";


    private static void Actions()
    {
      string enteredString = GetEventPlayerChatString();
      PlayerData senderPlayerData = PlayerData.ByHandle(GetTriggerPlayer());

      if (SubString(enteredString, 0, StringLength(COMMAND)) == COMMAND)
      {
        string content = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
        content = StringCase(content, false);

        if (FactionManager.FactionWithNameExists(content))
        {
          Faction targetFaction = FactionManager.GetFromName(content);
          if (targetFaction.Person != null)
            senderPlayerData.Faction.Team?.Uninvite(targetFaction);
          else
            DisplayTextToPlayer(senderPlayerData.Player, 0, 0,
              $"There is no player with the Faction {targetFaction.ColoredName}.");
        }
        else
        {
          DisplayTextToPlayer(senderPlayerData.Player, 0, 0, $"There is no Faction with the name {content}.");
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