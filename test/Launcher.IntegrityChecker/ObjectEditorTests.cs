using System.Text;
using Launcher.Extensions;
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
      var preplacedUnitIds = _mapTestFixture.Map.Units!.Units.Select(x => x.TypeId).ToHashSet();
      var preplacedUnitTypes = _mapTestFixture.ObjectDatabase.GetUnits().Where(x => preplacedUnitIds.Contains(x.NewId));
      var inaccessibleUnits = _mapTestFixture.ObjectDatabase.GetUnits().ToList();

      foreach (var preplacedUnit in preplacedUnitTypes)
        MarkObjectAsAccessible(preplacedUnit, inaccessibleUnits);

      if (inaccessibleUnits.Count <= 0) 
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      exceptionMessageBuilder.AppendLine(
        $"There is no way to train, summon, or spawn the following {inaccessibleUnits.Count} units. Remove them from the map or add a way for the player to get them.");
      foreach (var unit in inaccessibleUnits)
        exceptionMessageBuilder.AppendLine(GetReadableId(unit));
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }
 
    private static void MarkObjectAsAccessible(Unit unit, ICollection<Unit> inaccessibleUnits)
    {
      if (!inaccessibleUnits.Contains(unit))
        return;
      
      inaccessibleUnits.Remove(unit);
      
      if (unit.IsTechtreeUnitsTrainedModified)
        foreach (var trainedUnit in unit.TechtreeUnitsTrained)
          MarkObjectAsAccessible(trainedUnit, inaccessibleUnits);

      if (unit.IsTechtreeStructuresBuiltModified)
        foreach (var builtStructure in unit.TechtreeStructuresBuilt)
          MarkObjectAsAccessible(builtStructure, inaccessibleUnits);
    }

    private static string GetReadableId(BaseObject baseObject) =>
      baseObject.NewId != 0 ? baseObject.NewId.IdToFourCc() : baseObject.OldId.IdToFourCc();
  }
}