using System.Text;
using Launcher.Extensions;
using War3Api.Object;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker
{
  public sealed class UnitTests : IClassFixture<MapTestFixture>
  {
    private readonly MapTestFixture _mapTestFixture;

    public UnitTests(MapTestFixture mapTestFixture)
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
        foreach (var preplacedUnitChild in GetChildren(preplacedUnit))
          inaccessibleUnits.Remove(preplacedUnitChild);

      if (inaccessibleUnits.Count <= 0) 
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      exceptionMessageBuilder.AppendLine(
        "There is no way to train, summon, or spawn the following units. Remove them from the map or add a way for the player to get them.");
      foreach (var unit in inaccessibleUnits)
        exceptionMessageBuilder.AppendLine(GetReadableId(unit));
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }
 
    private static IEnumerable<Unit> GetChildren(Unit unit)
    {
      if (unit.IsTechtreeUnitsTrainedModified)
        foreach (var trainedUnit in unit.TechtreeUnitsTrained)
        {
          yield return trainedUnit;
          foreach (var trainedUnitChildren in GetChildren(trainedUnit))
            yield return trainedUnitChildren;
        }
    }

    private static string GetReadableId(BaseObject baseObject) =>
      baseObject.NewId != 0 ? baseObject.NewId.IdToFourCc() : baseObject.OldId.IdToFourCc();
  }
}