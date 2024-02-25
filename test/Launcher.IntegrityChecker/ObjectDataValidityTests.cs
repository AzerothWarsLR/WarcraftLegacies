using System.Text;
using Launcher.Extensions;
using War3Api.Object;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker
{
  public sealed class ObjectDataValidityTests : IClassFixture<MapTestFixture>
  {
    private readonly MapTestFixture _mapTestFixture;

    public ObjectDataValidityTests(MapTestFixture mapTestFixture)
    {
      _mapTestFixture = mapTestFixture;
    }
    
    [Fact]
    public void AllUnits_HaveValidFields()
    {
      var issues = new List<string>();

      foreach (var unit in _mapTestFixture.ObjectDatabase.GetUnits())
        if (unit.IsTechtreeResearchesAvailableModified)
          try
          {
            _ = unit.TechtreeResearchesAvailable;
          }
          catch (KeyNotFoundException)
          {
            issues.Add($"{GetReadableId(unit)} has an invalid Researches Available field.");
          }

      if (issues.Count == 0)
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      foreach (var issue in issues)
        exceptionMessageBuilder.AppendLine(issue);
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }
    
    private static string GetReadableId(BaseObject baseObject) =>
      baseObject.NewId != 0 ? baseObject.NewId.IdToFourCc() : baseObject.OldId.IdToFourCc();
  }
}