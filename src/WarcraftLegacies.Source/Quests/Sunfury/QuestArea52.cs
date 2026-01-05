using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Sunfury;

/// <summary>
/// Build various structures inside <see cref="Regions.Area52Unlock"/>
/// </summary>
public sealed class QuestArea52 : QuestData
{
  private readonly List<unit> _rescueUnits;
  private const int GoldReward = 250;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestArea52"/> class.
  /// </summary>
  public QuestArea52(Rectangle rescueRect) : base("Area 52",
    "The goblins of Area 52 have lived in Netherstorm long before our arrival. In other circumstances, they may have been potential allies - but desperate times call for desperate conquests.",
    @"ReplaceableTextures\CommandButtons\BTNLordaeronPalace.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N07Q_AREA_52));
    AddObjective(new ObjectiveExpire(600, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll,
      filterUnit => filterUnit.UnitType != UNIT_NGME_GOBLIN_MERCHANT);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction whichFaction)
  {
    var player = whichFaction.Player;
    if (player != null)
    {
      player.Gold += GoldReward;
      player.RescueGroup(_rescueUnits);
    }
    else
    {
      player.NeutralAggressive.RescueGroup(_rescueUnits);
    }
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The goblins of Area 52 once aspired to travel amongst the stars. Now they aspire to nothing, buried one layer of dirt beneath our new settlement.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"Gain {GoldReward} gold and a base in Area 52";
}
