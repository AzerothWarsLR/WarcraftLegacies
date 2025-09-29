using System.Diagnostics.CodeAnalysis;
using System.Text;
using Launcher.Extensions;
using Launcher.IntegrityChecker.TestSupport;
using War3Api.Object;
using War3Api.Object.Abilities;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker.ValidityTests;

public sealed class AbilityValidityTests(MapTestFixture mapTestFixture) : IClassFixture<MapTestFixture>
{
  [Fact]
  public void AllAbilities_HaveValidFields()
  {
    var issues = new List<string>();
    var objectDatabase = mapTestFixture.ObjectDatabase;

    foreach (var ability in objectDatabase.GetAbilities().ToArray())
    {
      if (VerifyUnitsSummoned(ability, out var unitsSummonedIssues))
      {
        issues.Add(unitsSummonedIssues);
      }
    }

    if (issues.Count == 0)
    {
      return;
    }

    var exceptionMessageBuilder = new StringBuilder();
    foreach (var issue in issues)
    {
      exceptionMessageBuilder.AppendLine(issue);
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
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
