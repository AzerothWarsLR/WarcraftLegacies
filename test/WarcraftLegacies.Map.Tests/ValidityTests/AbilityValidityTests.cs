using System.Diagnostics.CodeAnalysis;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Net.Common.Extensions;
using Warcraft.Cartographer.Extensions;
using WarcraftLegacies.Map.Tests.TestSupport;

namespace WarcraftLegacies.Map.Tests.ValidityTests;

[Collection(nameof(MapTestCollection))]
public sealed class AbilityValidityTests(MapTestFixture fixture)
{
  [Fact]
  public void AllAbilities_HaveValidFields()
  {
    var objectDatabase = fixture.ObjectDatabase;

    var issues = new List<string>();
    foreach (var ability in objectDatabase.GetAbilities())
    {
      if (VerifyUnitsSummoned(ability, out var unitsSummonedIssue))
      {
        issues.Add(unitsSummonedIssue);
      }
    }

    ValidityTestHelpers.ThrowIfAny(issues);
  }

  [Fact]
  public void AllAbilities_HaveValidBuffReferences()
  {
    var issues = fixture.ObjectDatabase.GetAbilities()
      .SelectMany(ability => Enumerable.Range(1, ability.StatsLevels).SelectMany(i => GetInvalidBuffIds(ability, i)))
      .ToList();

    ValidityTestHelpers.ThrowIfAny(issues);
  }

  private IEnumerable<string> GetInvalidBuffIds(Ability ability, int level)
  {
    return new (bool IsModified, ObjectProperty<string> Property)[]
      {
        (ability.IsStatsBuffsModified[level], ability.StatsBuffsRaw),
        (ability.IsStatsEffectsModified[level], ability.StatsEffectsRaw),
      }
      .Where(x => x.IsModified)
      .SelectMany(x => GetInvalidBuffIds(ability, level, x.Property));
  }

  private IEnumerable<string> GetInvalidBuffIds(Ability ability, int level, ObjectProperty<string> property)
  {
    return property[level].Split(',', StringSplitOptions.RemoveEmptyEntries)
      .Where(id => !fixture.ObjectDatabase.TryGetBuff(id.FromRawcode(), out _))
      .Select(id=> $"{ability.TextName} ({ability.GetReadableId()}) references invalid buff '{id}' at level {level}.");
  }

  [Fact]
  public void AllAbilities_CanBeHandledByWar3Net()
  {
    var objectDatabase = fixture.ObjectDatabase;

    var issues = new List<string>();
    foreach (var ability in objectDatabase.GetAbilities())
    {
      if (!CanAbilityBeHandledByWar3Net(ability) && ability.Modifications.Any())
      {
        issues.Add($"{ability.TextName} ({ability.GetReadableId()} - {ability.GetId()}) is of banned type {ability.OldId.ToRawcode()} - {ability.OldId}");
      }
    }

    ValidityTestHelpers.ThrowIfAny(issues);
  }

  /// <summary>
  /// Returns true if the ability base type can reasonably be handled by War3Net.
  /// </summary>
  private static bool CanAbilityBeHandledByWar3Net(Ability ability)
  {
    return ability switch
    {
      ChenStormEarthAndFire => false,
      RokhanHex => false,
      RokhanSerpentWard => false,
      RokhanVoodooSpirits => false,
      SummonLobstrokPrawns => false,
      WateryMinionItem => false,
      RexxarSummonBear => false,
      RexxarSummonQuilbeast => false,
      FeralSpiritSpiritBeast => false,
      FeralSpiritAkama => false,
      _ => true
    };
  }

  private static bool VerifyUnitsSummoned(Ability ability, [NotNullWhen(true)] out string? issue)
  {
    issue = null;

    try
    {
      switch (ability)
      {
        case ArchMageWaterElemental archmageWaterElemental:
          _ = archmageWaterElemental.DataSummonedUnitType;
          break;
        case AuraPlagueAbomination auraPlagueAbomination:
          _ = auraPlagueAbomination.DataPlagueWardUnitType;
          break;
        case AuraPlagueAnimatedDead auraPlagueAnimatedDead:
          _ = auraPlagueAnimatedDead.DataPlagueWardUnitType;
          break;
        case AuraPlagueCreep auraPlagueCreep:
          _ = auraPlagueCreep.DataPlagueWardUnitType;
          break;
        case AuraPlagueCreepGfx auraPlagueCreepGfx:
          _ = auraPlagueCreepGfx.DataPlagueWardUnitType;
          break;
        case FigurineBlueDrake figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineDoomGuard figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineDragonspawnOverseer figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineFelHound figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineFurbolg figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineFurbolgTracker figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineIceRevenant figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineRedDrake figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineRockGolem figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineSkeleton figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        case FigurineUrsaWarrior figurine:
          _ = figurine.DataSummon1UnitType;
          _ = figurine.DataSummon2UnitType;
          break;
        default:
          _ = (ObjectProperty<Unit>?)null;
          break;
      }
    }
    catch (KeyNotFoundException)
    {
      issue = $"{ability.GetReadableId()} summons an invalid unit.";
      return true;
    }

    return false;
  }
}
