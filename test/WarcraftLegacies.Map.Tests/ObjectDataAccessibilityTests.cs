using System.Text;
using FluentAssertions;
using Warcraft.Cartographer.Extensions;
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
      .Where(upgrade => !exceptions.Contains(upgrade.GetReadableId()))
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
      exceptionMessageBuilder.AppendLine($"{upgrade.GetReadableId()} - {upgrade.GetId()}");
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
      exceptionMessageBuilder.AppendLine($"{unit.GetReadableId()} - {unit.GetId()}");
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
      exceptionMessageBuilder.AppendLine($"{unit.GetReadableId()} - {unit.GetId()}");
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
      exceptionMessageBuilder.AppendLine($"{doodad.GetReadableId()} - {doodad.GetId()}");
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }

  [Fact]
  public void AllItems_CanBeAccessed()
  {
    if (fixture.UnreachableObjects.Items.Count <= 0)
    {
      return;
    }

    if (fixture.UnreachableObjects.Exceptions.Count != 0)
    {
      throw new UnreachableObjectCollectionBuildException(fixture.UnreachableObjects.Exceptions);
    }

    var itemsToCheck = fixture.UnreachableObjects.Items.ToList();

    if (itemsToCheck.Count <= 0)
    {
      return;
    }

    var exceptionMessageBuilder = new StringBuilder();
    exceptionMessageBuilder.AppendLine($"The following {itemsToCheck.Count} items aren't accessible in the map. Remove them from the map or place them somewhere.");

    foreach (var item in itemsToCheck)
    {
      exceptionMessageBuilder.AppendLine($"{item.GetReadableId()} - {item.GetId()}");
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }
}
