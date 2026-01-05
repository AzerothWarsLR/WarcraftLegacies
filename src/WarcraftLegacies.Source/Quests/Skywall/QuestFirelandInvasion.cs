using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
//using MacroTools.UserInterface;
//using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Quests.Skywall;

/// <summary>
/// When completed, the fireland invasion begins, granting the elemental player a bunch of units around the world tree.
/// </summary>
public sealed class QuestFirelandInvasion : QuestData
{
  private readonly Faction _invasionVictim;

  private readonly Faction _secondaryInvasionFaction;
  private readonly InvasionParameters _invasionParameters;

  private readonly List<unit> _sulfuronUnits;

  /// <summary>
  /// When completed, the quest holder initiates the Invasion.
  /// </summary>
  /// <param name="invasionParameters">Provides information about how the invasion should work.</param>
  /// <param name="invasionVictim">The faction that the invasion will primarily affect.</param>
  /// <param name="secondaryInvasionFaction">The faction that will gain some of the fringe benefits of the plague.</param>
  /// /// <param name="sulfuron">The base near Capital Palace.</param>
  public QuestFirelandInvasion(InvasionParameters invasionParameters, Faction invasionVictim,
    Faction secondaryInvasionFaction, Rectangle sulfuron) : base(
    "Fireland Invasion",
    "The elemental plane has launched a massive invasion at the world tree.",
    @"ReplaceableTextures\CommandButtons\BTNFireLandStrike.blp")
  {
    _invasionVictim = invasionVictim;
    _invasionParameters = invasionParameters;
    _secondaryInvasionFaction = secondaryInvasionFaction;
    AddObjective(new ObjectiveEitherOf(
      new ObjectiveResearch(UPGRADE_RSW5_FIRELAND_INVASION_SKYWALL, UNIT_NELC_VORTEX_PINNACLE_SKYWALL_T3),
      new ObjectiveTime(600)));
    AddObjective(new ObjectiveTime(500));
    _sulfuronUnits = sulfuron.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    Global = true;
    //ResearchId = UPGRADE_R009_QUEST_COMPLETED_PLAGUE_OF_UNDEATH;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The invasion of the World Tree has been unleashed! The forces of Kalimdor have to protect it at all cost.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Several small armies under your control spawn throughout Hyjal, you gain control of the Sulfuron Spire, the World Tree's Control Points reset to level 0, and you will be given a choice to instantly move your military units to Sufuron Spire";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.ModObjectLimit(UPGRADE_RSW5_FIRELAND_INVASION_SKYWALL, -Faction.Unlimited);
    if (completingFaction.Player != null)
    {
      SpawnArmies(completingFaction);
    }

    ResetVictimControlPointLevel();
    //PresentInvasionDialogs();
    RescueBases(completingFaction);

  }

  private void RescueBases(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_sulfuronUnits);
  }

  //private static void PresentInvasionDialogs()
  //{
  //  new ScourgeInvasionDialogPresenter(
  //      new Choice<Rectangle?>(null, "No invasion"),
  //      new Choice<Rectangle?>(Regions.SulfuronSpire, "Sulfuron Spire"))
  //    .Run(player.Create(8));
  //}

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) =>
    whichFaction.ModObjectLimit(UPGRADE_RSW5_FIRELAND_INVASION_SKYWALL, Faction.Unlimited);


  private void SpawnArmies(Faction completingFaction)
  {
    var primaryInvasionPlayer = completingFaction.ScoreStatus != ScoreStatus.Defeated && completingFaction.Player != null
      ? completingFaction.Player
      : player.NeutralAggressive;

    var secondaryInvasionPlayer = _secondaryInvasionFaction.ScoreStatus != ScoreStatus.Defeated && _secondaryInvasionFaction.Player != null
      ? _secondaryInvasionFaction.Player
      : player.NeutralAggressive;

    foreach (var invasionRect in _invasionParameters.InvasionRects)
    {
      var position = invasionRect.GetRandomPoint();
      position.RemoveDestructablesInRadius(250f);

      unit.Create(secondaryInvasionPlayer, UNIT_U019_WORKER_CTHUN_WORKER, position.X, position.Y, 0);

      var attackTarget = _invasionParameters.AttackTargets
        .OrderBy(x => MathEx.GetDistanceBetweenPoints(position, x))
        .First();

      foreach (var parameter in _invasionParameters.InvasionArmySummonParameters)
      {
        foreach (var unit in CreateUnits(primaryInvasionPlayer, parameter.SummonUnitTypeId,
                   position.X, position.Y, 0, parameter.SummonCount))
        {
          if (!unit.IsUnitType(unittype.Peon))
          {
            unit.IssueOrder(ORDER_ATTACK, attackTarget.X, attackTarget.Y);
          }
        }
      }
    }
  }

  private void ResetVictimControlPointLevel()
  {
    if (_invasionVictim.Player == null)
    {
      return;
    }

    foreach (var controlPoint in _invasionVictim.Player.GetPlayerData().ControlPoints)
    {
      controlPoint.ControlLevel = 0;
    }
  }
}
