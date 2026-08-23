using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Researches;
using WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics;
using WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Researches;

/// <summary>
/// When researched, packs the starting camp's buildings into pack kodos and starts <see cref="LongMarchCaravan"/>
/// marching them toward Stonemaul Keep and then Thunder Bluff.
/// </summary>
public sealed class StartTheLongMarch : Research
{
  /// <summary>
  /// Player slot that owns the pack kodos while they march. Not the native Neutral Passive slot, because
  /// Neutral Passive units are immune to attacks even from an explicitly targeted order - this slot is just an
  /// otherwise-unused player, allied with Tauren Tribes so it isn't hostile to the player, but still a normal
  /// enemy to Neutral Aggressive so ambushes can actually land hits.
  /// </summary>
  private const int KodoControllerSlot = 8;

  /// <summary>How long the "birth" (construction) animation is given to play before the building is removed.</summary>
  private const float PackUpAnimationSeconds = 1.50f;

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

    var kodos = new List<unit>();
    kodos.Add(SpawnKodo(kodoController, _tent));
    _tent.Dispose();

    foreach (var building in _productionBuildings)
    {
      kodos.Add(SpawnKodo(kodoController, building));
      PlayPackUpAnimationThenRemove(building);
    }

    _quest.BeginMarch(kodos, Regions.StonemaulKeep, Regions.ThunderBluff);
    new LongMarchCaravan(_taurenTribes, _quest, kodos, Regions.StonemaulKeep, Regions.ThunderBluff);
  }

  private static unit SpawnKodo(player owner, unit atBuilding) =>
    unit.Create(owner, UNIT_OTKO_PACK_KODO_TAUREN_TRIBES, atBuilding.X, atBuilding.Y, atBuilding.Facing);

  private static void PlayPackUpAnimationThenRemove(unit building)
  {
    building.SetAnimation("birth");
    var removalTimer = timer.Create();
    removalTimer.Start(PackUpAnimationSeconds, false, () =>
    {
      building.Dispose();
      removalTimer.Dispose();
    });
  }
}
