using System.Text;
using Launcher.Extensions;
using Launcher.IntegrityChecker.TestSupport;
using War3Api.Object;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker
{
  public sealed class ObjectEditorAccessibilityTests : IClassFixture<MapTestFixture>
  {
    private readonly MapTestFixture _mapTestFixture;
    private readonly InaccessibleObjectCollection _inaccesibleObjects;

    public ObjectEditorAccessibilityTests(MapTestFixture mapTestFixture)
    {
      _mapTestFixture = mapTestFixture;
      _inaccesibleObjects = GetInaccessibleObjects();
    }
    
    [Fact]
    public void AllUnits_CanBeAccessed()
    {
      if (_inaccesibleObjects.Units.Count <= 0) 
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      exceptionMessageBuilder.AppendLine(
        $"There is no way to train, summon, or spawn the following {_inaccesibleObjects.Units.Count} units. Remove them from the map or add a way to get them.");
      foreach (var unit in _inaccesibleObjects.Units)
        exceptionMessageBuilder.AppendLine(GetReadableId(unit));
      
      throw new XunitException(exceptionMessageBuilder.ToString());
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
        exceptionMessageBuilder.AppendLine(GetReadableId(upgrade));
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }

    private InaccessibleObjectCollection GetInaccessibleObjects()
    {
      var map = _mapTestFixture.Map;
      var objectDatabase = _mapTestFixture.ObjectDatabase;
      
      var preplacedUnitIds = map.Units!.Units.Select(x => x.TypeId).ToHashSet();
      var preplacedUnitTypes = objectDatabase.GetUnits().Where(x => preplacedUnitIds.Contains(x.NewId));
      
      var inaccessibleObjects = new InaccessibleObjectCollection(
        objectDatabase.GetUnits().ToList(),
        objectDatabase.GetUpgrades().ToList());

      foreach (var preplacedUnit in preplacedUnitTypes)
        inaccessibleObjects.RemoveWithChildren(preplacedUnit);

      return inaccessibleObjects;
    }
    
    private static string GetReadableId(BaseObject baseObject) =>
      baseObject.NewId != 0 ? baseObject.NewId.IdToFourCc() : baseObject.OldId.IdToFourCc();
  }
}