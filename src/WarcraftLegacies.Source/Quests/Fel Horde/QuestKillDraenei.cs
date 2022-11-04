using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  public sealed class QuestKillDraenei : QuestData
  {
    public QuestKillDraenei() : base("The Shattrah Massacre",
      "The Draenei race existence insults the Fel Horde demon masters, slaughter them all ",
      "ReplaceableTextures\\CommandButtons\\BTNChaosWolfRider.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n09X"))));
      AddObjective(new ObjectiveLegendDead(LegendDraenei.LegendExodarship));
      AddObjective(new ObjectiveSelfExists());
      Required = true;
    }

    protected override string CompletionPopup =>
      "The Draenei have been eliminated from Outland and their gold mine is ours.";

    protected override string RewardDescription =>
      "The Draenei rich gold mine in Tempest Keep, the faster we destroy them, the more gold will be left";

    protected override void OnComplete(Faction completingFaction)
    {
      group tempGroup = CreateGroup();

      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 500);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 500);

      GroupEnumUnitsInRect(tempGroup, Regions.InstanceOutland.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == DraeneiSetup.Draenei.Player)
          if (IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT))
            KillUnit(u);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }
  }
}