using System.Collections.Generic;
using System.Linq;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Mechanics.Scourge.Plague;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// When completed, the plague begins, granting either the Forsaken or the quest holder several Plague Cauldrons that periodically spawn undead units.
  /// </summary>
  public sealed class QuestPlague : QuestData
  {
    private readonly float _duration;

    private readonly unit _portalController1;
    private readonly unit _portalController2;
    private readonly unit _innerWaygate1;
    private readonly unit _innerWaygate2;
    private readonly unit _outerWaygate1;
    private readonly unit _outerWaygate2;

    private readonly List<PlagueCauldronSummonParameter> _plagueCauldronSummonParameters;
    private readonly int _plagueCauldronUnitTypeId;
    private readonly List<Rectangle> _plagueRects;
    private readonly List<Point> _attackTargets;

    /// <summary>
    /// When completed, the quest holder initiates the Plague, creating Plague Cauldrons around Lordaeron
    /// and converting villagers into Zombies.
    /// </summary>
    /// <param name="plagueParameters">Provides information about how the Plague should work.</param>
    /// <param name="preplacedUnitSystem">A system for finding preplaced units.</param>
    public QuestPlague(PlagueParameters plagueParameters, PreplacedUnitSystem preplacedUnitSystem) : base(
      "Plague of Undeath",
      "The Cult of the Damned is prepared to unleash a devastating zombifying plague across the lands of Lordaeron.",
      "ReplaceableTextures\\CommandButtons\\BTNPlagueBarrel.blp")
    {
      _plagueRects = plagueParameters.PlagueRects;
      _plagueCauldronUnitTypeId = plagueParameters.PlagueCauldronUnitTypeId;
      _plagueCauldronSummonParameters = plagueParameters.PlagueCauldronSummonParameters;
      _duration = plagueParameters.Duration;
      _attackTargets = plagueParameters.AttackTargets;
      AddObjective(new ObjectiveEitherOf(
        new ObjectiveResearch(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, FourCC("u000")),
        new ObjectiveTime(960)));
      AddObjective(new ObjectiveTime(660));
      Global = true;
      Required = true;

      _portalController1 = preplacedUnitSystem.GetUnit(Constants.UNIT_N03J_BLACK_PORTAL_AURA_CONTROL_NEXUS, new Point(-1546, 18236)).SetInvulnerable(true);
      _portalController2 = preplacedUnitSystem.GetUnit(Constants.UNIT_N03J_BLACK_PORTAL_AURA_CONTROL_NEXUS, new Point(14198, 6530)).SetInvulnerable(true);
      _innerWaygate1 = preplacedUnitSystem.GetUnit(Constants.UNIT_N03H_DEATH_GATE_WAYGATE, Regions.Scholomance_Exterior_1.Center).Show(false);
      _innerWaygate2 = preplacedUnitSystem.GetUnit(Constants.UNIT_N03H_DEATH_GATE_WAYGATE, Regions.Scholomance_Exterior_2.Center).Show(false);
      _outerWaygate1 = preplacedUnitSystem.GetUnit(Constants.UNIT_N03H_DEATH_GATE_WAYGATE, Regions.Wrathgate_Portal_1.Center).Show(false);
      _outerWaygate2 = preplacedUnitSystem.GetUnit(Constants.UNIT_N03H_DEATH_GATE_WAYGATE, Regions.Wrathgate_Portal_2.Center).Show(false);
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies. The Black Gatehas been opened in Dragonblight!";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "All villagers in Lordaeron are transformed into Zombies, and several Plague Cauldrons spawn throughout Lordaeron, which periodically spawn Zombies. Open a portal between Dragonblight and Scholomance";

    private void CreatePlagueCauldrons(Faction completingFaction)
    {
      var plaguePlayer = (completingFaction.ScoreStatus != ScoreStatus.Defeated
        ? completingFaction.Player
        : Player(PLAYER_NEUTRAL_AGGRESSIVE)) 
                         ?? Player(PLAYER_NEUTRAL_AGGRESSIVE);

      foreach (var plagueRect in _plagueRects)
      {
        var position = plagueRect.GetRandomPoint();
        var plagueCauldron = CreateUnit(plaguePlayer, _plagueCauldronUnitTypeId, position.X, position.Y, 0)
          .SetTimedLife(_duration);

        var attackTarget = _attackTargets.OrderBy(x => MathEx.GetDistanceBetweenPoints(position, x)).First();
        
        var plagueCauldronBuff = new PlagueCauldronBuff(plagueCauldron, plagueCauldron, attackTarget)
        {
          ZombieUnitTypeId = Constants.UNIT_NZOM_ZOMBIE_SCOURGE
        };
        BuffSystem.Add(plagueCauldronBuff);

        foreach (var parameter in _plagueCauldronSummonParameters)
          foreach (var unit in GeneralHelpers.CreateUnits(plaguePlayer, parameter.SummonUnitTypeId,
                   position.X, position.Y, 0, parameter.SummonCount))
          {
            if (!unit.IsType(UNIT_TYPE_PEON))
              unit.IssueOrder("attack", attackTarget);
          }
      }
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, -Faction.UNLIMITED);
      var plaguePower = new PlaguePower();
      if (completingFaction.Player != null) 
        CreatePlagueCauldrons(completingFaction);
      completingFaction.AddPower(plaguePower);

      _portalController1.SetInvulnerable(false);
      _portalController2.SetInvulnerable(false);
      _innerWaygate1
        .Show(true)
        .SetWaygateDestination(Regions.Wrathgate_Portal_1.Center);
      _innerWaygate2
        .Show(true)
        .SetWaygateDestination(Regions.Wrathgate_Portal_2.Center);
      _outerWaygate1
        .Show(true)
        .SetWaygateDestination(Regions.Scholomance_Exterior_1.Center);
      _outerWaygate2
        .Show(true)
        .SetWaygateDestination(Regions.Scholomance_Exterior_2.Center);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction) => 
      whichFaction.ModObjectLimit(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, Faction.UNLIMITED);
  }
}