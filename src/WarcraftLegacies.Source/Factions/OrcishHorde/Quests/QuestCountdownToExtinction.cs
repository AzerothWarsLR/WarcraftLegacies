using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Quests;

/// <summary>
/// The Orcish Horde's starting quest. Thrall's forces must hold the landing island against four waves of
/// murlocs, headed up by a Sea Witch, while the fleet is repaired.
/// </summary>
public sealed class QuestCountdownToExtinction : QuestData
{
  private const int GruntCount = 6;
  private const int ShamanCount = 2;
  private const int PeonCount = 5;
  private const float ReinforcementLifePercent = 50f;
  private const float DefeatSurvivorLifePercent = 50f;
  private const float ReinforcementSpacing = 90f;

  /// <summary>
  /// Key Orcish Horde buildings that Thrall gets a Tiny item version of when the fleet departs cleanly,
  /// so the buildings can be rebuilt at the new landing site.
  /// </summary>
  private static readonly Dictionary<int, int> _keyBuildingTinyItems = new()
  {
    { UNIT_O078_GREAT_HALL_ORCISH_HORDE_T1, ITEM_I01Z_TINY_GREAT_HALL_ORCISH_HORDE },
    { UNIT_O075_WAR_CAMP_ORCISH_HORDE, ITEM_I020_TINY_WAR_CAMP_ORCISH_HORDE },
    { UNIT_O076_ALTAR_OF_STORMS_ORCISH_HORDE, ITEM_I021_TINY_ALTAR_OF_STORMS_ORCISH_HORDE }
  };

  private readonly Rectangle _buildZone;
  private readonly Point _retreatDestination;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestCountdownToExtinction"/> class.
  /// </summary>
  /// <param name="greatHall">The starting Great Hall. Losing it fails the quest.</param>
  /// <param name="buildZone">The area that Red is allowed to build in on the landing island.</param>
  /// <param name="retreatRegion">Where survivors are sent, win or lose.</param>
  public QuestCountdownToExtinction(unit greatHall, Rectangle buildZone, Rectangle retreatRegion) : base(
    "Countdown to Extinction",
    "Thrall's fleet was battered by the crossing and needs time to be made seaworthy again. Until then, the Horde must hold this island against whatever the sea sends at them.",
    @"ReplaceableTextures\CommandButtons\BTNGhost.blp")
  {
    _buildZone = buildZone;
    _retreatDestination = retreatRegion.Center;

    AddObjective(new ObjectiveUnitAlive(greatHall));
    SurviveAssault = new ObjectiveSurviveAssault("Survive the murloc assault");
    AddObjective(SurviveAssault);
  }

  /// <summary>Marked complete externally once the murloc assault is over.</summary>
  public ObjectiveSurviveAssault SurviveAssault { get; }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The last of the murlocs sink beneath the waves. With the coast clear, the fleet sets sail for Kalimdor.";

  /// <inheritdoc />
  public override string PenaltyFlavour =>
    "The Great Hall falls, but the survivors scramble aboard what's left of the fleet and limp toward Kalimdor regardless.";

  /// <inheritdoc />
  protected override string RewardDescription => "The fleet departs for Durotar, taking all surviving forces with it";

  /// <inheritdoc />
  protected override string PenaltyDescription => "Surviving forces retreat to Durotar at reduced health";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var completingPlayer = completingFaction.Player;
    if (completingPlayer == null)
    {
      return;
    }

    GrantTinyBuildingItems(completingPlayer);
    DestroyBuildingsInZone(completingPlayer, showDeathEffects: false, refundCost: true);
    RelocateSurvivors(completingPlayer, 100f);
  }

  private void GrantTinyBuildingItems(player owningPlayer)
  {
    var thrall = GlobalGroup.EnumUnitsOfPlayer(owningPlayer)
      .FirstOrDefault(u => u.UnitType == UNIT_TP52_WARCHIEF_OF_THE_HORDE_ORCISH_HORDE);
    if (thrall == null)
    {
      return;
    }

    var keyBuildingTypes = GlobalGroup.EnumUnitsOfPlayer(owningPlayer)
      .Where(u => u.Alive && u.IsUnitType(unittype.Structure) && _buildZone.Contains(u.X, u.Y)
        && _keyBuildingTinyItems.ContainsKey(u.UnitType))
      .Select(u => u.UnitType)
      .Distinct();

    foreach (var unitType in keyBuildingTypes)
    {
      thrall.AddItem(item.Create(_keyBuildingTinyItems[unitType], thrall.X, thrall.Y));
    }
  }

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var completingPlayer = completingFaction.Player;
    if (completingPlayer == null)
    {
      return;
    }

    DestroyBuildingsInZone(completingPlayer, showDeathEffects: true, refundCost: false);
    var survivorCount = RelocateSurvivors(completingPlayer, DefeatSurvivorLifePercent);

    if (survivorCount == 0)
    {
      SpawnReinforcements(completingPlayer);
    }
  }

  private void DestroyBuildingsInZone(player owningPlayer, bool showDeathEffects, bool refundCost)
  {
    var buildings = GlobalGroup.EnumUnitsOfPlayer(owningPlayer)
      .Where(u => u.Alive && u.IsUnitType(unittype.Structure) && _buildZone.Contains(u.X, u.Y))
      .ToList();

    foreach (var building in buildings)
    {
      if (refundCost && !_keyBuildingTinyItems.ContainsKey(building.UnitType))
      {
        owningPlayer.Gold += unit.GoldCostOf(building.UnitType);
        owningPlayer.Lumber += unit.WoodCostOf(building.UnitType);
      }

      if (showDeathEffects)
      {
        building.Kill();
      }
      else
      {
        building.Dispose();
      }
    }
  }

  private int RelocateSurvivors(player owningPlayer, float lifePercent)
  {
    var survivors = GlobalGroup.EnumUnitsOfPlayer(owningPlayer)
      .Where(u => u.Alive && !u.IsUnitType(unittype.Structure))
      .ToList();

    foreach (var survivor in survivors)
    {
      survivor.SetPosition(_retreatDestination.X, _retreatDestination.Y);
      if (lifePercent < 100f)
      {
        survivor.SetLifePercent(lifePercent);
      }
    }

    return survivors.Count;
  }

  private void SpawnReinforcements(player owningPlayer)
  {
    var spawnIndex = 0;
    for (var i = 0; i < GruntCount; i++)
    {
      CreateReinforcement(owningPlayer, UNIT_O074_GRUNT_ORCISH_HORDE, spawnIndex++);
    }

    CreateReinforcement(owningPlayer, UNIT_OKOD_KODO_BEAST_WARSONG, spawnIndex++);

    for (var i = 0; i < ShamanCount; i++)
    {
      CreateReinforcement(owningPlayer, UNIT_OSHM_SHAMAN_FROSTWOLF, spawnIndex++);
    }

    for (var i = 0; i < PeonCount; i++)
    {
      CreateReinforcement(owningPlayer, UNIT_O07A_PEON_ORCISH_HORDE, spawnIndex++);
    }

    CreateReinforcement(owningPlayer, UNIT_TP52_WARCHIEF_OF_THE_HORDE_ORCISH_HORDE, spawnIndex);
  }

  private void CreateReinforcement(player owningPlayer, int unitTypeId, int spawnIndex)
  {
    var offsetX = (spawnIndex % 5) * ReinforcementSpacing;
    var offsetY = (spawnIndex / 5) * ReinforcementSpacing;
    var spawned = unit.Create(owningPlayer, unitTypeId, _retreatDestination.X + offsetX,
      _retreatDestination.Y + offsetY, 0);
    spawned.SetLifePercent(ReinforcementLifePercent);
  }
}
