using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using WarcraftLegacies.Source.Factions.TaurenTribes.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics;

/// <summary>
/// When Cairne Bloodhoof is first trained, grants the Tauren Tribes an escort of Tauren and Spirit Walkers, packs the
/// starting camp's buildings into pack kodos and starts <see cref="LongMarchCaravan"/> marching them toward Thunder Bluff.
/// </summary>
public sealed class LongMarchDeparture
{
  private const int KodoControllerSlot = 8;
  private const float PackUpAnimationSeconds = 1.50f;
  private const int GuardCount = 4;
  private const float GuardSpawnSpacing = 60f;
  private const int EscortTaurenCount = 8;
  private const int EscortSpiritWalkerCount = 4;
  private const float EscortSpawnSpacing = 90f;
  private const float EscortSpawnOffsetY = -250f;

  private readonly Faction _taurenTribes;
  private readonly QuestTheLongMarch _quest;
  private readonly unit _tent;
  private readonly List<unit> _productionBuildings;
  private bool _departed;

  /// <summary>
  /// Initializes a new instance of the <see cref="LongMarchDeparture"/> class.
  /// </summary>
  public LongMarchDeparture(Faction taurenTribes, QuestTheLongMarch quest, unit tent, List<unit> productionBuildings)
  {
    _taurenTribes = taurenTribes;
    _quest = quest;
    _tent = tent;
    _productionBuildings = productionBuildings;
    PlayerUnitEvents.Register(UnitTypeEvent.FinishesBeingTrained, OnCairneTrained,
      UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_TAUREN_TRIBES);
  }

  private void OnCairneTrained()
  {
    var taurenPlayer = _taurenTribes.Player;
    if (_departed || taurenPlayer == null || @event.TrainedUnit.Owner != taurenPlayer)
    {
      return;
    }

    _departed = true;
    SpawnEscort(taurenPlayer);
    Depart();
  }

  private void SpawnEscort(player taurenPlayer)
  {
    var spawnIndex = 0;
    for (var i = 0; i < EscortTaurenCount; i++)
    {
      SpawnEscortUnit(taurenPlayer, UNIT_OTAU_TAUREN_TAUREN_TRIBES, spawnIndex++);
    }

    for (var i = 0; i < EscortSpiritWalkerCount; i++)
    {
      SpawnEscortUnit(taurenPlayer, UNIT_OSPW_SPIRIT_WALKER_TAUREN_TRIBES, spawnIndex++);
    }
  }

  private void SpawnEscortUnit(player taurenPlayer, int unitTypeId, int spawnIndex)
  {
    var offsetX = (spawnIndex % 6 - 2.5f) * EscortSpawnSpacing;
    var offsetY = EscortSpawnOffsetY - spawnIndex / 6 * EscortSpawnSpacing;
    unit.Create(taurenPlayer, unitTypeId, _tent.X + offsetX, _tent.Y + offsetY, _tent.Facing);
  }

  private void Depart()
  {
    var kodoController = player.Create(KodoControllerSlot);
    kodoController.Name = "Kodo Caravan";
    ControlPointManager.Instance.NonCapturingPlayers.Add(kodoController);
    foreach (var ally in GetCaravanAllies())
    {
      kodoController.SetAlliance(ally, alliancetype.Passive, true);
      kodoController.SetAlliance(ally, alliancetype.SharedVision, true);
      ally.SetAlliance(kodoController, alliancetype.Passive, true);
      ally.SetAlliance(kodoController, alliancetype.SharedVision, true);
    }

    var allBuildings = new List<unit> { _tent };
    allBuildings.AddRange(_productionBuildings);

    foreach (var building in allBuildings)
    {
      building.SetAnimation("birth");
    }

    var packUpTimer = timer.Create();
    packUpTimer.Start(PackUpAnimationSeconds, false, () =>
    {
      packUpTimer.Dispose();
      SpawnKodosAndBeginMarch(kodoController, allBuildings);
    });
  }

  private void SpawnKodosAndBeginMarch(player kodoController, List<unit> allBuildings)
  {
    var campX = _tent.X;
    var campY = _tent.Y;
    var campFacing = _tent.Facing;

    var kodos = new List<unit>();
    foreach (var building in allBuildings)
    {
      kodos.Add(unit.Create(kodoController, UNIT_OTKO_PACK_KODO_TAUREN_TRIBES, building.X, building.Y, building.Facing));
      building.Dispose();
    }

    var guards = new List<unit>();
    for (var i = 0; i < GuardCount; i++)
    {
      var spawnOffset = (i - (GuardCount - 1) / 2f) * GuardSpawnSpacing;
      guards.Add(unit.Create(kodoController, UNIT_OTGD_TAUREN_GUARD_TAUREN_TRIBES, campX + spawnOffset, campY, campFacing));
    }

    var thousandNeedlesControlPoint = AllPreplacedWidgets.Units.Get(UNIT_N026_THOUSAND_NEEDLES);
    var mulgoreControlPoint = AllPreplacedWidgets.Units.Get(UNIT_N09G_MULGORE);

    thousandNeedlesControlPoint.SetOwner(player.NeutralPassive);
    mulgoreControlPoint.SetOwner(player.NeutralPassive);

    _quest.BeginMarch(kodos);
    new LongMarchCaravan(_taurenTribes, _quest, kodos, guards, thousandNeedlesControlPoint,
      mulgoreControlPoint, Regions.ThunderBluff);
  }

  private IEnumerable<player> GetCaravanAllies()
  {
    var taurenPlayer = _taurenTribes.Player;
    if (taurenPlayer == null)
    {
      yield break;
    }

    yield return taurenPlayer;
    var team = taurenPlayer.GetPlayerData().Team;
    if (team == null)
    {
      yield break;
    }

    foreach (var faction in team.GetAllFactions())
    {
      if (faction.Player != null && faction.Player != taurenPlayer)
      {
        yield return faction.Player;
      }
    }
  }
}
