﻿using System.Text;
using Launcher.IntegrityChecker.TestSupport;
using MacroTools.Shared.Extensions;
using War3Api.Object;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker
{
  public sealed class ObjectDataAccessibilityTests : IClassFixture<MapTestFixture>
  {
    private readonly MapTestFixture _mapTestFixture;
    private readonly InaccessibleObjectCollection _inaccesibleObjects;

    public ObjectDataAccessibilityTests(MapTestFixture mapTestFixture)
    {
      _mapTestFixture = mapTestFixture;
      _inaccesibleObjects = GetInaccessibleObjects();
    }
    
    [Fact]
    public void AllResearches_CanBeAccessed()
    {
      if (_inaccesibleObjects.Upgrades.Count <= 0) 
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      exceptionMessageBuilder.AppendLine(
        $"There is no way to research the following {_inaccesibleObjects.Upgrades.Count} researches. Remove them from the map or add a way to research them.");
      foreach (var upgrade in _inaccesibleObjects.Upgrades)
        exceptionMessageBuilder.AppendLine($"{GetReadableId(upgrade)} - {GetId(upgrade)}");
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }

    private InaccessibleObjectCollection GetInaccessibleObjects()
    {
      var map = _mapTestFixture.Map;
      var objectDatabase = _mapTestFixture.ObjectDatabase;
      
      var inaccessibleObjects = new InaccessibleObjectCollection(
        objectDatabase.GetUnits().ToList(),
        objectDatabase.GetUpgrades().ToList());
      
      var preplacedUnitIds = map.Units!.Units.Select(x => x.TypeId).ToHashSet();
      var preplacedUnitTypes = objectDatabase.GetUnits().Where(x => preplacedUnitIds.Contains(x.NewId)).ToList();

      foreach (var preplacedUnit in preplacedUnitTypes)
        inaccessibleObjects.RemoveWithChildren(preplacedUnit);

      var objectsInScript = inaccessibleObjects
        .GetAllObjects()
        .Where(x => _mapTestFixture.UncompiledScript.Contains(GetReadableId(x)))
        .ToList();

      foreach (var objectInScript in objectsInScript) 
        inaccessibleObjects.RemoveWithChildren(objectInScript);

      return inaccessibleObjects;
    }

    private static int GetId(BaseObject baseObject) => baseObject.NewId != 0 ? baseObject.NewId : baseObject.OldId;

    private static string GetReadableId(BaseObject baseObject) => GetId(baseObject).IdToFourCc();
  }
}