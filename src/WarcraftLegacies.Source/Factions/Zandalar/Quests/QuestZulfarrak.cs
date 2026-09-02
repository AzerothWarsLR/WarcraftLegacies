using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic.Rocks;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;


namespace WarcraftLegacies.Source.Factions.Zandalar.Quests;
  /// <summary>
  /// Capture Zul'Farrak to unlock Gahz'rilla as a hero/>
  /// </summary>
  public sealed class QuestZulfarrak : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private int goldReward { get; set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestZulfarrak"/> class.
    /// </summary>
    /// <param name="rescueRect"></param>
    /// <param name="Zul"></param>
   public QuestZulfarrak(Rectangle rescueRect, LegendaryHero Zul) : base("Fury of the Sands",
      "The Sandfury Trolls of Zul'farrak are openly hostile to visitors, but they share a common heritage with the Zandalari Trolls. An adequate display of force could bring them around.",
      @"ReplaceableTextures\CommandButtons\BTNDarkTroll.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N092_ZUL_FARRAK));
      ResearchId = UPGRADE_MD33_QUEST_COMPLETED_ZULFARRAK;
      AddObjective(new ObjectiveLegendReachRect(Zul, rescueRect, "Zul'Farrak"));
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      goldReward = 150;
      }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      $"Zul'farrak has fallen. The Sandfury trolls lend their might to the Zandalari.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Control of Zul'farrak, 150 gold tribute, enable to train Storm Wyrm and you can summon the hero Gahz'rilla from the Altar of Conquerors";

    /// <inheritdoc/>>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        completingFaction.Player.RescueGroup(_rescueUnits);
      }
    }
  }
