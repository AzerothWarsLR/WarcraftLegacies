using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using MacroTools.Researches;
using WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics;
using WarcraftLegacies.Source.Factions.TaurenTribes.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Researches;

/// <summary>
/// When researched, packs the starting camp's buildings into pack kodos and starts <see cref="LongMarchCaravan"/>
/// marching them toward Stonemaul Keep and then Thunder Bluff.
/// </summary>
public sealed class StartTheLongMarch : Research
{
  private const int KodoControllerSlot = 8;
  private const float PackUpAnimationSeconds = 1.50f;
  private const int GuardCount = 4;
  private const float GuardSpawnSpacing = 60f;

  private readonly Faction _taurenTribes;
  private readonly QuestTheLongMarch _quest;
  private readonly unit _tent;
  private readonly List<unit> _productionBuildings;

  /// <inheritdoc />
  public StartTheLongMarch(Faction taurenTribes, QuestTheLongMarch quest, unit tent, List<unit> productionBuildings)
    : base(UPGRADE_RTLM_START_THE_LONG_MARCH_TAUREN_TRIBES, 0, 0)
  {
    _taurenTribes = taurenTribes;
    _quest = quest;
    _tent = tent;
    _productionBuildings = productionBuildings;
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var kodoController = player.Create(KodoControllerSlot);
    kodoController.Name = "Kodo Caravan";
    if (_taurenTribes.Player != null)
    {
      kodoController.SetAlliance(_taurenTribes.Player, alliancetype.Passive, true);
      kodoController.SetAlliance(_taurenTribes.Player, alliancetype.SharedVision, true);
      _taurenTribes.Player.SetAlliance(kodoController, alliancetype.Passive, true);
      _taurenTribes.Player.SetAlliance(kodoController, alliancetype.SharedVision, true);
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
    var thousandNeedlesTarget = new Point(thousandNeedlesControlPoint.X, thousandNeedlesControlPoint.Y);
    var stonemaulControlPoint = AllPreplacedWidgets.Units.Get(UNIT_N022_STONEMAUL);
    var stonemaulTarget = new Point(stonemaulControlPoint.X, stonemaulControlPoint.Y);
    var mulgoreControlPoint = AllPreplacedWidgets.Units.Get(UNIT_N09G_MULGORE);
    var mulgoreTarget = new Point(mulgoreControlPoint.X, mulgoreControlPoint.Y);

    thousandNeedlesControlPoint.SetOwner(player.NeutralPassive);
    mulgoreControlPoint.SetOwner(player.NeutralPassive);

    _quest.BeginMarch(kodos, thousandNeedlesTarget, Regions.StonemaulKeep, mulgoreTarget, Regions.ThunderBluff);
    new LongMarchCaravan(_taurenTribes, _quest, kodos, guards, thousandNeedlesControlPoint, stonemaulTarget,
      mulgoreControlPoint, Regions.StonemaulKeep, Regions.ThunderBluff);
  }
}
