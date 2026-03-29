using System.Text;
using FluentAssertions;
using War3Api.Object;
using War3Net.Common.Extensions;
using WarcraftLegacies.Map.Tests.TestSupport;
using Xunit.Sdk;

namespace WarcraftLegacies.Map.Tests;

[Collection(nameof(MapTestCollection))]
public sealed class ObjectDataAccessibilityTests(MapTestFixture fixture)
{
  [Fact]
  public void UnreachableObjectCollection_HasNoExceptions()
  {
    fixture.UnreachableObjects.Exceptions.Should().BeEmpty();
  }

  [Fact]
  public void AllResearches_CanBeAccessed()
  {
    if (fixture.UnreachableObjects.Upgrades.Count <= 0)
    {
      return;
    }

    if (fixture.UnreachableObjects.Exceptions.Count != 0)
    {
      throw new UnreachableObjectCollectionBuildException(fixture.UnreachableObjects.Exceptions);
    }

    var exceptions = new HashSet<string>
    {
      "Robk"
    };

    var upgradesToCheck = fixture.UnreachableObjects.Upgrades
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
    if (fixture.UnreachableObjects.Units.Count <= 0)
    {
      return;
    }

    if (fixture.UnreachableObjects.Exceptions.Count != 0)
    {
      throw new UnreachableObjectCollectionBuildException(fixture.UnreachableObjects.Exceptions);
    }

    var unitsToCheck = fixture.UnreachableObjects.Units.ToList();

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
    if (fixture.UnreachableObjects.Abilities.Count <= 0)
    {
      return;
    }

    if (fixture.UnreachableObjects.Exceptions.Count != 0)
    {
      throw new UnreachableObjectCollectionBuildException(fixture.UnreachableObjects.Exceptions);
    }

    var abilitiesToCheck = fixture.UnreachableObjects.Abilities.ToList();

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
    var unplacedDoodads = fixture.UnreachableObjects.Doodads;

    if (unplacedDoodads.Count <= 0)
    {
      return;
    }

    if (fixture.UnreachableObjects.Exceptions.Count != 0)
    {
      throw new UnreachableObjectCollectionBuildException(fixture.UnreachableObjects.Exceptions);
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
