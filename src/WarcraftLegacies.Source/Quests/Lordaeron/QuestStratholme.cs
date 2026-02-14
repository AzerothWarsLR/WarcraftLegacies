using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Lordaeron;

/// <summary>
/// Free Alterac Mountains of the Blackrock orcs and upgrgade the main building to a castle in order to gain control of Stratholme.
/// </summary>
public sealed class QuestStratholme : QuestData
{
  private readonly LegendaryHero _arthas;
  private readonly LegendaryHero _uther;
  private readonly Capital _stratholme;
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestStratholme"/> class.
  /// </summary>
  public QuestStratholme(Rectangle rescueRect, LegendaryHero arthas, LegendaryHero uther, Capital stratholme) : base(
    "Blackrock and Roll",
    "The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron",
    @"ReplaceableTextures\CommandButtons\BTNChaosBlademaster.blp")
  {
    _arthas = arthas;
    _uther = uther;
    _stratholme = stratholme;
    AddObjective(new ObjectiveControlPoint(UNIT_N019_ALTERAC_MOUNTAINS));
    AddObjective(new ObjectiveUpgrade(UNIT_HCAS_CASTLE_LORDAERON_T3, UNIT_HTOW_TOWN_HALL_LORDAERON_T1));
    AddObjective(new ObjectiveControlLegend(arthas, false));
    AddObjective(new ObjectiveExpire(11, Title));
    AddObjective(new ObjectiveSelfExists());

    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    ResearchId = UPGRADE_R09E_QUEST_COMPLETED_BLACKROCK_AND_ROLL;
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all units in Stratholme and you can now build Town Halls";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
    _arthas.AddUnitDependency(_stratholme.Unit);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
    _arthas.AddUnitDependency(_stratholme.Unit);
    _uther.AddUnitDependency(_stratholme.Unit);
  }
}
