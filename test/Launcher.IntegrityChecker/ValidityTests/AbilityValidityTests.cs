using System.Diagnostics.CodeAnalysis;
using System.Text;
using Launcher.Extensions;
using Launcher.IntegrityChecker.TestSupport;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Net.Common.Extensions;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker.ValidityTests;

public sealed class AbilityValidityTests(MapTestFixture mapTestFixture) : IClassFixture<MapTestFixture>
{
  [Fact]
  public void AllAbilities_HaveValidFields()
  {
    var objectDatabase = mapTestFixture.ObjectDatabase;

    var exceptionMessageBuilder = new StringBuilder();
    foreach (var ability in objectDatabase.GetAbilities())
    {
      if (VerifyUnitsSummoned(ability, out var unitsSummonedIssues))
      {
        exceptionMessageBuilder.AppendLine(unitsSummonedIssues);
      }
    }

    if (exceptionMessageBuilder.Length == 0)
    {
      return;
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }

  [Fact]
  public void AllAbilities_CanBeHandledByWar3Net()
  {
    var objectDatabase = mapTestFixture.ObjectDatabase;

    var exceptionMessageBuilder = new StringBuilder();
    foreach (var ability in objectDatabase.GetAbilities())
    {
      if (!CanAbilityBeHandledByWar3Net(ability) && ability.Modifications.Any())
      {
        exceptionMessageBuilder.AppendLine($"{ability.TextName} ({ability.GetReadableId()} - {ability.GetId()}) is of banned type {ability.OldId.ToRawcode()} - {ability.OldId}");
      }
    }

    if (exceptionMessageBuilder.Length == 0)
    {
      return;
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
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
