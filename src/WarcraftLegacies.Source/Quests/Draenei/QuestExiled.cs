using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.Legends;
using WarcraftLegacies.Source.Setup.QuestSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// After waiting a while or completing a specific research, the Draenei escape from Outland.
  /// </summary>
  public sealed class QuestExiled : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestExiled"/> class.
    /// </summary>
    public QuestExiled() : base("The Exile from Outland",
      "The Draenei need to escape Outland through the Exodar ship. We will need to power it up with a Divine Citadel first. The longer you hold out, the better the rewards will be",
      "ReplaceableTextures\\CommandButtons\\BTNUndeadAirBarge.blp")
    {
      AddObjective(new ObjectiveEitherOf(new ObjectiveResearch(FourCC("R080"), Constants.UNIT_H09W_THE_EXODAR),
        new ObjectiveTime(782)));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendDraenei.LegendExodarship));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R081_QUEST_COMPLETED_THE_EXILE_FROM_OUTLAND;
      Global = true;
    }

    /// <summary>
    /// Upon completion, the completing player instantly gains however much gold was still left in this gold mine.
    /// </summary>
    public unit? GoldMine { get; init; }

    /// <summary>
    /// These units are killed when the <see cref="QuestExiled"/> is failed.
    /// </summary>
    public IEnumerable<unit>? KilledOnFail { get; init; }

    /// <summary>
    ///   Removed from the game when the Draenei escape.
    /// </summary>
    public unit? TheExodar { get; init; }

    /// <inheritdoc />
    protected override string CompletionPopup => "The Draenei have landed on Azuremyst after escaping Outland";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in Azuremyst, gain 200 gold, 500 lumber and teleports all your units away from Outland";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      GrantExiled(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      if (KilledOnFail != null)
        foreach (var unit in KilledOnFail)
          KillUnit(unit);

      KillUnit(LegendDraenei.LegendVelen.Unit);

      using var group = new GroupWrapper().EnumUnitsInRect(Regions.InstanceOutland);
      foreach (var unit in group.EmptyToList())
      {
        if (GetOwningPlayer(unit) == completingFaction.Player)
          if (IsUnitType(unit, UNIT_TYPE_STRUCTURE) && !IsUnitType(unit, UNIT_TYPE_ANCIENT))
            KillUnit(unit);
      }
      
      ResetCamera(completingFaction);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      Player(13).AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 2000 - GetResourceAmount(GoldMine));
      completingFaction.AddQuest(DraeneiQuestSetup.SHIP_ARGUS);
      DraeneiQuestSetup.SHIP_ARGUS.Progress = QuestProgress.Incomplete;
      UnitRemoveAbility(LegendDraenei.LegendVelen.Unit, Constants.ABILITY_ACM2_SPELL_IMMUNITY_DIVINE_ARMOR);

      if (completingFaction.Player != null)
      {
        GrantExiled(completingFaction.Player);
        EscapeOutland(completingFaction.Player);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 200);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 500);
        RemoveUnit(TheExodar);
      }
      
      completingFaction.Player?.RunLocal(() => PlayThematicMusic("war3mapImported\\DraeneiTheme.mp3"));
      ResetCamera(completingFaction);

      if (KilledOnFail != null)
        foreach (var unit in KilledOnFail)
          KillUnit(unit);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(Regions.DraeneiEvacuation).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        if (!IsUnitType(unit, UNIT_TYPE_STRUCTURE)) 
          ShowUnit(unit, false);
      }
      
      whichFaction.Player?.SetCameraLimits(Regions.DraeneiCamLock.Rect);
      whichFaction.Player?.ChangeMinimapTerrainTexture("war3mapImported\\OutlandMinimap.blp");
    }

    private static void ResetCamera(Faction whichFaction)
    {
      whichFaction.Player?.SetCameraLimits(WCSharp.Shared.Data.Rectangle.WorldBounds.Rect);
      whichFaction.Player?.ChangeMinimapTerrainTexture("war3mapMap.blp");
    }
    
    private static void GrantExiled(player whichPlayer)
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(Regions.DraeneiEvacuation.Rect).EmptyToList())
        if (unit.OwningPlayer() == Player(PLAYER_NEUTRAL_PASSIVE))
          unit.Rescue(whichPlayer);
    }

    private static void EscapeOutland(player whichPlayer)
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(Regions.InstanceOutland.Rect).EmptyToList())
      {
        if (GetOwningPlayer(unit) != whichPlayer) continue;
        if (IsUnitType(unit, UNIT_TYPE_STRUCTURE) && !IsUnitType(unit, UNIT_TYPE_ANCIENT))
          KillUnit(unit);
        else if (!IsUnitType(unit, UNIT_TYPE_ANCIENT)) 
          SetUnitPosition(unit, -21185, 8000);
      }
    }
  }
}