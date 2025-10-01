using System.Text;
using Launcher.Extensions;
using Launcher.IntegrityChecker.TestSupport;
using War3Api.Object;
using War3Net.Common.Extensions;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker;

public sealed class ObjectDataAccessibilityTests(MapTestFixture mapTestFixture) : IClassFixture<MapTestFixture>
{
  [Fact]
  public void AllResearches_CanBeAccessed()
  {
    if (mapTestFixture.InaccessibleObjects.Upgrades.Count <= 0)
    {
      return;
    }

    var exceptions = new HashSet<string>
    {
      "Robk"
    };

    var upgradesToCheck = mapTestFixture.InaccessibleObjects.Upgrades
      .Where(upgrade => !exceptions.Contains(GetReadableId(upgrade)))
      .ToList();

    if (upgradesToCheck.Count <= 0)
    {
      return;
    }

    var exceptionMessageBuilder = new StringBuilder();
    exceptionMessageBuilder.AppendLine(
      $"There is no way to research the following {upgradesToCheck.Count} researches. Remove them from the map or add a way to research them.");

    foreach (var upgrade in upgradesToCheck)
    {
      exceptionMessageBuilder.AppendLine($"{GetReadableId(upgrade)} - {GetId(upgrade)}");
      File.Delete($"../../../../../mapdata/WarcraftLegacies/UpgradeData/Core/{upgrade.GetId()}.json");
      File.Delete($"../../../../../mapdata/WarcraftLegacies/UpgradeData/Skin/{upgrade.GetId()}.json");
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }

  [Fact]
  public void AllUnits_CanBeTrained()
  {
    if (mapTestFixture.InaccessibleObjects.Units.Count <= 0)
    {
      return;
    }

    var unitsToCheck = mapTestFixture.InaccessibleObjects.Units.ToList();

    if (unitsToCheck.Count <= 0)
    {
      return;
    }

    var exceptionMessageBuilder = new StringBuilder();
    exceptionMessageBuilder.AppendLine(
      $"There is no way to train the following {unitsToCheck.Count} units. Remove them from the map or add a way to get them.");

    foreach (var unit in unitsToCheck)
    {
      File.Delete($"../../../../../mapdata/WarcraftLegacies/UnitData/Core/{unit.GetReadableId()}.json");
      File.Delete($"../../../../../mapdata/WarcraftLegacies/UnitData/Skin/{unit.GetReadableId()}.json");
      exceptionMessageBuilder.AppendLine($"{GetReadableId(unit)} - {GetId(unit)}");
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }

  [Fact]
  public void AllAbilities_CanBeCast()
  {
    if (mapTestFixture.InaccessibleObjects.Units.Count <= 0)
    {
      return;
    }

    var abilitiesToCheck = mapTestFixture.InaccessibleObjects.Abilities.ToList();

    if (abilitiesToCheck.Count <= 0)
    {
      return;
    }

    var exceptionMessageBuilder = new StringBuilder();
    exceptionMessageBuilder.AppendLine(
      $"There is no way to cast the following {abilitiesToCheck.Count} abilities. Remove them from the map or add a way to get them.");

    foreach (var unit in abilitiesToCheck)
    {
      File.Delete($"../../../../../mapdata/WarcraftLegacies/AbilityData/Core/{unit.GetId()}.json");
      File.Delete($"../../../../../mapdata/WarcraftLegacies/AbilityData/Skin/{unit.GetId()}.json");
      exceptionMessageBuilder.AppendLine($"{GetReadableId(unit)} - {GetId(unit)}");
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }

  private static int GetId(BaseObject baseObject) => baseObject.NewId != 0 ? baseObject.NewId : baseObject.OldId;

  private static string GetReadableId(BaseObject baseObject) => GetId(baseObject).ToRawcode();
}
