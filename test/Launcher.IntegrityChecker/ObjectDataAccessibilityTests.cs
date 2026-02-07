using System.Text;
using FluentAssertions;
using Launcher.IntegrityChecker.TestSupport;
using War3Api.Object;
using War3Net.Common.Extensions;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker;

public sealed class ObjectDataAccessibilityTests(MapTestFixture mapTestFixture) : IClassFixture<MapTestFixture>
{
  [Fact]
  public void InaccessibleObjectCollection_HasNoExceptions()
  {
    mapTestFixture.InaccessibleObjects.Exceptions.Should().BeEmpty();
  }

  [Fact]
  public void AllResearches_CanBeAccessed()
  {
    if (mapTestFixture.InaccessibleObjects.Upgrades.Count <= 0)
    {
      return;
    }

    if (mapTestFixture.InaccessibleObjects.Exceptions.Count != 0)
    {
      throw new XunitException("Test cannot start because there were issues building the InaccessibleObjectCollection.");
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

    if (mapTestFixture.InaccessibleObjects.Exceptions.Count != 0)
    {
      throw new XunitException("Test cannot start because there were issues building the InaccessibleObjectCollection.");
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
      exceptionMessageBuilder.AppendLine($"{GetReadableId(unit)} - {GetId(unit)}");
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }

  [Fact]
  public void AllAbilities_CanBeCast()
  {
    if (mapTestFixture.InaccessibleObjects.Abilities.Count <= 0)
    {
      return;
    }

    if (mapTestFixture.InaccessibleObjects.Exceptions.Count != 0)
    {
      throw new XunitException("Test cannot start because there were issues building the InaccessibleObjectCollection.");
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
      exceptionMessageBuilder.AppendLine($"{GetReadableId(unit)} - {GetId(unit)}");
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }

  [Fact]
  public void AllDoodads_ArePlaced()
  {
    var unplacedDoodads = mapTestFixture.InaccessibleObjects.Doodads;

    if (unplacedDoodads.Count <= 0)
    {
      return;
    }

    if (mapTestFixture.InaccessibleObjects.Exceptions.Count != 0)
    {
      throw new XunitException("Test cannot start because there were issues building the InaccessibleObjectCollection.");
    }

    var exceptionMessageBuilder = new StringBuilder();
    exceptionMessageBuilder.AppendLine(
      $"The following {unplacedDoodads.Count} doodads aren't placed anywhere on the map. Remove them from the map or place them somewhere.");

    foreach (var doodad in unplacedDoodads)
    {
      exceptionMessageBuilder.AppendLine($"{GetReadableId(doodad)} - {GetId(doodad)}");
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }

  private static int GetId(BaseObject baseObject) => baseObject.NewId != 0 ? baseObject.NewId : baseObject.OldId;

  private static string GetReadableId(BaseObject baseObject) => GetId(baseObject).ToRawcode();
}
