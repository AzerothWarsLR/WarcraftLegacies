using System.Diagnostics.CodeAnalysis;
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
      var objectDatabase = _mapTestFixture.ObjectDatabase;
      
      foreach (var unit in objectDatabase.GetUnits())
      {
        if (VerifyResearchesAvailable(unit, out var researchesAvailableIssue)) 
          issues.Add(researchesAvailableIssue);
        
        if (VerifyResearchesRequired(unit, objectDatabase, out var researchesRequiredIssue)) 
          issues.Add(researchesRequiredIssue);
      }
      if (issues.Count == 0)
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      foreach (var issue in issues)
        exceptionMessageBuilder.AppendLine(issue);
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }

    private static bool VerifyResearchesAvailable(Unit unit, [NotNullWhen(true)] out string? issue)
    {
      issue = null;
      
      if (!unit.IsTechtreeResearchesAvailableModified)
        return false;

      try
      {
        _ = unit.TechtreeResearchesAvailable;
      }
      catch (KeyNotFoundException)
      {
        issue = $"{GetReadableId(unit)} has an invalid Researches Available field.";
        return true;
      }
      
      return false;
    }
    
    private static bool VerifyResearchesRequired(Unit unit, ObjectDatabase objectDatabase,
      [NotNullWhen(true)] out string? issue)
    {
      issue = null;
      
      if (!unit.IsTechtreeRequirementsModified)
        return false;
      
      var requirements = unit.TechtreeRequirements;
      if (requirements.All(requirement => IsTechValid(requirement, objectDatabase))) 
        return false;
      
      issue = $"{GetReadableId(unit)} has an invalid Requirements field.";
      return true;
    }

    private static bool IsTechValid(Tech tech, ObjectDatabaseBase objectDatabase)
    {
      try
      {
        _ = objectDatabase.GetObject(tech.Key);
      }
      catch
      {
        return false;
      }

      return true;
    }
    
    private static string GetReadableId(BaseObject baseObject) =>
      baseObject.NewId != 0 ? baseObject.NewId.IdToFourCc() : baseObject.OldId.IdToFourCc();
  }
}