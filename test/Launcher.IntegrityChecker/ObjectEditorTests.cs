using System.Text;
using Launcher.Extensions;
using Launcher.IntegrityChecker.TestSupport;
using War3Api.Object;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker
{
  public sealed class ObjectEditorTests : IClassFixture<MapTestFixture>
  {
    private readonly MapTestFixture _mapTestFixture;

    public ObjectEditorTests(MapTestFixture mapTestFixture)
    {
      _mapTestFixture = mapTestFixture;
    }
    
    [Fact]
    public void AllUnits_CanBeAccessed()
    {
      var map = _mapTestFixture.Map;
      var objectDatabase = _mapTestFixture.ObjectDatabase;
      
      var preplacedUnitIds = map.Units!.Units.Select(x => x.TypeId).ToHashSet();
      var preplacedUnitTypes = objectDatabase.GetUnits().Where(x => preplacedUnitIds.Contains(x.NewId));
      
      var inaccessibleObjects = new InaccessibleObjectCollection(
        objectDatabase.GetUnits().ToList(),
        objectDatabase.GetAbilities().ToList());

      foreach (var preplacedUnit in preplacedUnitTypes)
        inaccessibleObjects.RemoveWithChildren(preplacedUnit);

      if (inaccessibleObjects.Units.Count <= 0) 
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      exceptionMessageBuilder.AppendLine(
        $"There is no way to train, summon, or spawn the following {inaccessibleObjects.Units.Count} units. Remove them from the map or add a way for the player to get them.");
      foreach (var unit in inaccessibleObjects.Units)
        exceptionMessageBuilder.AppendLine(GetReadableId(unit));
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }

    private static string GetReadableId(BaseObject baseObject) =>
      baseObject.NewId != 0 ? baseObject.NewId.IdToFourCc() : baseObject.OldId.IdToFourCc();
  }
}