using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestDarkshire : QuestData
  {
    public QuestDarkshire(unit gnollToKill) : base("Gnoll troubles",
      "The town of Darkshire is under attack by Gnoll's, clear them out!",
      "ReplaceableTextures\\CommandButtons\\BTNGnollArcher.blp")
    {
      AddObjective(new ObjectiveKillUnit(gnollToKill));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00V"))));
      AddObjective(new ObjectiveExpire(1425));
      AddObjective(new ObjectiveSelfExists());
    }

    protected override string CompletionPopup =>
      "Darkshire has been liberated, and its military is now free to assist Stormwind.";

    protected override string RewardDescription => "Control of all units in Darkshire";

    private static void GrantDarkshire(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Darkshire
      GroupEnumUnitsInRect(tempGroup, Regions.DarkshireUnlock.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) u.Rescue(whichPlayer);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnFail(Faction completingFaction)
    {
      GrantDarkshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      GrantDarkshire(completingFaction.Player);
    }
  }
}