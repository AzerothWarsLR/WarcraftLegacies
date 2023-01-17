using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
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
    private readonly List<unit> _rescueUnits = new();
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestEliminatePiracy"/> class.
    /// </summary>
    public QuestEliminatePiracy(Rectangle rescueRect) : base("Eliminate Piracy",
      "The seas must be secured and the Kul'tiras navy must be returned to its former glory!", "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
    {
      AddObjective(new ObjectiveKillAllInArea(new List<Rectangle> { Regions.StranglethornAmbient3 }, "In Booty Bay"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01E_FUSELIGHT_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00L_BOOTY_BAY_10GOLD_MIN)));
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The South Coast has been secured, High Bank can now be established as an Outpost for the Alliance";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain control of High Bank and 400 gold";
/// <inheritdoc/>

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 400);
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
  }
}