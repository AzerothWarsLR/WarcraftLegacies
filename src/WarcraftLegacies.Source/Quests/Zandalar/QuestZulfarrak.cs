using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Zandalar
{
  /// <summary>
  /// Capture Zul'Farrak to unlock Gahz'rilla as a hero/>
  /// </summary>
  public sealed class QuestZulfarrak : QuestData
  {
    private const int GAHZRILLA_ID = Constants.UNIT_H06Q_DEMIGOD_WARSONG;
    private readonly List<unit> _rescueUnits;
    private readonly List<unit> _killUnits;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestZulfarrak"/> class
    /// </summary>
    /// <param name="rescueRect"></param>
    public QuestZulfarrak(Rectangle rescueRect) : base("Fury of the Sands",
      "The Sandfury Trolls of Zul'farrak are openly hostile to visitors, but they share a common heritage with the Zandalari Trolls. An adequate display of force could bring them around.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkTroll.blp")
    {
      ResearchId = Constants.UPGRADE_R02F_QUEST_COMPLETED_FURY_OF_THE_SANDS_WARSONG;
      AddObjective(new ObjectiveControlLegend(LegendNeutral.Zulfarrak, false));
      AddObjective(new ObjectiveLegendReachRect(LegendTroll.LEGEND_PRIEST, rescueRect, "Zul'Farrak"));
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      _killUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures, (unit => GetUnitTypeId(unit) != GetUnitTypeId(LegendNeutral.Zulfarrak.Unit)), Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <summary>
    ///<inheritdoc/>
    /// </summary>
    protected override string CompletionPopup =>
      $"Zul'farrak has fallen. The Sandfury trolls lend their might to the Zandalari.";

    /// <summary>
    ///<inheritdoc/>
    /// </summary>
    protected override string RewardDescription =>
      "Control of Zul'farrak, 300 gold tribute, enable to train Storm Wyrm and you can summon the hero Gahz'rilla from the Altar of Conquerors";

    /// <summary>
    ///<inheritdoc/>
    /// </summary>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        SetUnitOwner(LegendNeutral.Zulfarrak.Unit, completingFaction.Player, true);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 300);
        completingFaction.Player.RescueGroup(_rescueUnits);
        foreach (var unit in _killUnits)
          unit.Kill();    
      }
    }

    /// <summary>
    ///<inheritdoc/>
    /// </summary>
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(GAHZRILLA_ID, 1);
    }
  }
}