using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.Utils;
using WarcraftLegacies.Source.FactionMechanics.Scourge;
using WarcraftLegacies.Source.Rocks;
using WCSharp.Shared.Data;
using timer = War3Api.Common.timer;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestPlague : QuestData
  {
    private readonly Faction _plagueVictim;
    private readonly Faction _secondaryPlagueFaction;
    private readonly PlagueParameters _plagueParameters;

    private readonly List<unit> _deathknellUnits;
    private readonly List<unit> _coastUnits;
    private readonly List<unit> _scholomanceUnits;

    private timer? _sequenceTimer;
    private double _sequenceElapsed;
    private bool _didVillagers;
    private bool _didRescueAndRocks;
    private bool _didDialog;
    private bool _didInitialWave;
    private bool _didBonusWave;

    public QuestPlague(
      PlagueParameters plagueParameters,
      Faction plagueVictim,
      Faction secondaryPlagueFaction,
      Rectangle deathknell,
      Rectangle coast,
      Rectangle scholomance
    ) : base(
      "Plague of Undeath",
      "The Cult of the Damned is prepared to unleash a devastating zombifying plague across the lands of Lordaeron.",
      @"ReplaceableTextures\CommandButtons\BTNPlagueBarrel.blp"
    )
    {
      _plagueVictim           = plagueVictim;
      _plagueParameters       = plagueParameters;
      _secondaryPlagueFaction = secondaryPlagueFaction;

      AddObjective(new ObjectiveEitherOf(
        new ObjectiveResearch(UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, FourCC("u000")),
        new ObjectiveTime(660)));
      AddObjective(new ObjectiveTime(60));

      _deathknellUnits  = deathknell.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      _coastUnits       = coast.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      _scholomanceUnits = scholomance.PrepareUnitsForRescue(RescuePreparationMode.HideAll);

      Global    = true;
      ResearchId = UPGRADE_R009_QUEST_COMPLETED_PLAGUE_OF_UNDEATH;
    }

    public override string RewardFlavour =>
      "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies";

    protected override string RewardDescription =>
      "Several small armies under your control spawn throughout Lordaeron, you gain control of three bases around Lordaeron, Lordaeron's Control Points reset to level 0, and you will be given a choice to instantly move your military units from Northrend to one of three locations in Lordaeron";

    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(
        UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE,
        -Faction.UNLIMITED
      );

      StartCinematicSequence(completingFaction);

      if (completingFaction.TryGetPowerByName("Cult Spies", out var spiesPower))
        completingFaction.RemovePower(spiesPower);
      else
        Logger.LogWarning($"Expected {completingFaction.Name} to have the Cult Spies Power.");

      ResetVictimControlPointLevel();
    }

    private void StartCinematicSequence(Faction completingFaction)
    {
      _sequenceElapsed      = 0;
      _didVillagers         = false;
      _didRescueAndRocks    = false;
      _didDialog            = false;
      _didInitialWave       = false;
      _didBonusWave         = false;

      _sequenceTimer = CreateTimer();
      TimerStart(_sequenceTimer, 0.1f, true, () =>
      {
        _sequenceElapsed += 0.1;

        if (!_didVillagers)
        {
          KillVillagers();
          _didVillagers = true;
        }

        if (!_didRescueAndRocks && _sequenceElapsed >= 0.3)
        {
          RescueBases(completingFaction);
          RegisterRocks();
          _didRescueAndRocks = true;
        }

        if (!_didDialog && _sequenceElapsed >= 0.6)
        {
          PresentInvasionDialogs();
          _didDialog = true;
        }

        if (!_didInitialWave && _sequenceElapsed >= 1.0)
        {
          SpawnArmies(completingFaction);
          _didInitialWave = true;
        }

        if (!_didBonusWave && _sequenceElapsed >= 1.3)
        {
          SpawnUndeadWave(completingFaction);
          _didBonusWave = true;
        }

        if (_sequenceElapsed >= 2.0 && _sequenceTimer != null)
        {
          DestroyTimer(_sequenceTimer);
          _sequenceTimer = null;
        }
      });
    }

    private void SpawnUndeadWave(Faction plagueSourceFaction)
    {
      var plaguePlayer = plagueSourceFaction.Player != null && plagueSourceFaction.ScoreStatus != ScoreStatus.Defeated
        ? plagueSourceFaction.Player
        : Player(PLAYER_NEUTRAL_AGGRESSIVE);

      foreach (var rect in _plagueParameters.PlagueRects)
      {
        var pos = rect.GetRandomPoint();
        pos.RemoveDestructablesInRadius(250f);

        var target = _plagueParameters.AttackTargets
          .OrderBy(x => MathEx.GetDistanceBetweenPoints(pos, x))
          .First();

        foreach (var param in _plagueParameters.PlagueArmySummonParameters)
        foreach (var u in CreateUnits(
                   plaguePlayer,
                   param.SummonUnitTypeId,
                   pos.X, pos.Y,
                   0,
                   param.SummonCount
                 ))
          if (!u.IsType(UNIT_TYPE_PEON))
            u.IssueOrder(OrderId("attack"), target);
      }
    }

    private static void RegisterRocks()
    {
      RockSystem.Register(new RockGroup(Regions.Northrend_Blocker_1, FourCC("B013"), 120));
      RockSystem.Register(new RockGroup(Regions.Northrend_Blocker_2, FourCC("B013"), 120));
    }

    private void RescueBases(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_deathknellUnits);
      completingFaction.Player.RescueGroup(_coastUnits);
      completingFaction.Player.RescueGroup(_scholomanceUnits);
    }

    private static void PresentInvasionDialogs()
    {
      new ScourgeInvasionDialogPresenter(
        new ScourgeInvasionChoice(null, "No invasion") { AttackTarget = null },
        new ScourgeInvasionChoice(Regions.ScholoInvasion, "Scholomance")
        {
          AttackTarget = new Point(Regions.SkullRetrieval.Center.X, Regions.SkullRetrieval.Center.Y)
        },
        new ScourgeInvasionChoice(Regions.StrathInvasion, "Stratholme")
        {
          AttackTarget = new Point(Regions.StrathAttackTarget.Center.X, Regions.StrathAttackTarget.Center.Y)
        },
        new ScourgeInvasionChoice(Regions.DeathknellUnlock, "Deathknell")
        {
          AttackTarget = new Point(Regions.King_Arthas_crown.Center.X, Regions.King_Arthas_crown.Center.Y)
        }
      ).Run(Player(3));
    }

    protected override void OnAdd(Faction whichFaction) =>
      whichFaction.ModObjectLimit(UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, Faction.UNLIMITED);

    private static void KillVillagers()
    {
      var villagerIds = new List<int>
      {
        FourCC("nvlw"),
        FourCC("nvl2"),
        FourCC("nvil"),
        FourCC("nvlk"),
        FourCC("nvk2")
      };

      var group = GlobalGroup.EnumUnitsOfPlayer(Player(PLAYER_NEUTRAL_PASSIVE))
        .Where(u => villagerIds.Contains(u.GetTypeId()));

      foreach (var villager in group)
        villager.Kill();
    }

    private void SpawnArmies(Faction completingFaction)
    {
      var primary = completingFaction.Player != null && completingFaction.ScoreStatus != ScoreStatus.Defeated
        ? completingFaction.Player
        : Player(PLAYER_NEUTRAL_AGGRESSIVE);

      var secondary = _secondaryPlagueFaction.Player != null && _secondaryPlagueFaction.ScoreStatus != ScoreStatus.Defeated
        ? _secondaryPlagueFaction.Player
        : Player(PLAYER_NEUTRAL_AGGRESSIVE);

      foreach (var rect in _plagueParameters.PlagueRects)
      {
        var pos = rect.GetRandomPoint();
        pos.RemoveDestructablesInRadius(250f);

        CreateUnit(secondary, UNIT_U00D_LEGION_HERALD_LEGION_WORKER, pos.X, pos.Y, 0);

        var target = _plagueParameters.AttackTargets
          .OrderBy(x => MathEx.GetDistanceBetweenPoints(pos, x))
          .First();

        foreach (var param in _plagueParameters.PlagueArmySummonParameters)
        foreach (var u in CreateUnits(
                   primary,
                   param.SummonUnitTypeId,
                   pos.X, pos.Y,
                   0,
                   param.SummonCount
                 ))
          if (!u.IsType(UNIT_TYPE_PEON))
            u.IssueOrder(OrderId("attack"), target);
      }
    }

    private void ResetVictimControlPointLevel()
    {
      if (_plagueVictim.Player == null) return;
      foreach (var cp in _plagueVictim.Player.GetControlPoints())
        cp.ControlLevel = 0;
    }
  }
}