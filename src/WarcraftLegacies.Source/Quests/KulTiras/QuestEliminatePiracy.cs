using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Various control points must be captured.
  /// </summary>
  public sealed class QuestEliminatePiracy : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private readonly LegendaryHero _katherine;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestEliminatePiracy"/> class.
    /// </summary>
    public QuestEliminatePiracy(Rectangle rescueRect, LegendaryHero katherine) : base("Eliminate Piracy",
      "The seas must be secured and the Kul'tiras navy must be returned to its former glory!",
      "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
    {
      _katherine = katherine;
      AddObjective(new ObjectiveKillAllInArea(new List<Rectangle> { Regions.BootyBayQuest }, "In Booty Bay"));
      AddObjective(new ObjectiveControlLegend(katherine, false));
      AddObjective(
        new ObjectiveControlPoint(
          ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00L_BOOTY_BAY_10GOLD_MIN)));
      AddObjective(new ObjectiveExpire(840));
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The South Coast has been secured, High Bank can now be established as an Outpost for the Alliance";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain control of High Bank, 700 gold and 3000 experience to Katherine";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 700);
      completingFaction.Player.RescueGroup(_rescueUnits);
      _katherine.Unit?.AddExperience(3000);
    }
  }
}