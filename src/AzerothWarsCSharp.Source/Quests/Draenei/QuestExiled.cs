using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using AzerothWarsCSharp.Source.Setup.QuestSetup;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestExiled : QuestData
  {
    public QuestExiled() : base("The Exile from Outland",
      "The Draenei need to escape Outland through the Exodar ship. We will need to power it up with a Divine Citadel first. The longer you hold out, the better the rewards will be",
      "ReplaceableTextures\\CommandButtons\\BTNUndeadAirBarge.blp")
    {
      AddObjective(new ObjectiveEitherOf(new ObjectiveResearch(FourCC("R080"), FourCC("h09W")),
        new ObjectiveTime(782)));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendDraenei.LegendExodarship));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R081");
      Global = true;
    }

    public unit GoldMine { get; init; }

    public IEnumerable<unit> KilledOnFail { get; init; }

    /// <summary>
    ///   Removed from the game when the Draenei escape.
    /// </summary>
    public unit TheExodar { get; init; }

    protected override string CompletionPopup => "The Draenei have landed on Azuremyst after escaping Outland";

    protected override string RewardDescription =>
      "Control of all units in Azuremyst, gain 200 gold, 500 lumber and teleports all your units away from Outland";

    private static void GrantExiled(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Exiled
      GroupEnumUnitsInRect(tempGroup, Regions.DraeneiEvacuation.Rect, null);
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

    private void EscapeOutland(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Exiled
      GroupEnumUnitsInRect(tempGroup, Regions.InstanceOutland.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == whichPlayer)
        {
          if (IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT))
            KillUnit(u);
          else if (!IsUnitType(u, UNIT_TYPE_ANCIENT)) SetUnitPosition(u, -21185, 8000);
        }

        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnFail(Faction completingFaction)
    {
      group tempGroup = CreateGroup();

      GrantExiled(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      foreach (var unit in KilledOnFail) KillUnit(unit);

      KillUnit(LegendDraenei.LegendVelen.Unit);

      GroupEnumUnitsInRect(tempGroup, Regions.InstanceOutland.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == completingFaction.Player)
          if (IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT))
            KillUnit(u);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 200);
      Player(13).AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000 - GetResourceAmount(GoldMine));
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 500);
      completingFaction.AddQuest(DraeneiQuestSetup.SHIP_ARGUS);
      DraeneiQuestSetup.SHIP_ARGUS.Progress = QuestProgress.Incomplete;
      UnitRemoveAbility(LegendDraenei.LegendVelen.Unit, FourCC("ACm2"));
      GrantExiled(completingFaction.Player);
      EscapeOutland(completingFaction.Player);
      RemoveUnit(TheExodar);
      foreach (var unit in KilledOnFail) KillUnit(unit);

      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\DraeneiTheme.mp3");
    }
  }
}