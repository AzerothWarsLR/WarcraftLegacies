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
      
      foreach (var unit in objectDatabase.GetUnits().ToArray())
      {
        if (VerifyResearchesAvailable(unit, out var researchesAvailableIssue)) 
          issues.Add(researchesAvailableIssue);
        
        if (VerifyResearchesRequired(unit, out var researchesRequiredIssue)) 
          issues.Add(researchesRequiredIssue);
        
        if (VerifyNormalAbilities(unit, out var normalAbilitiesIssue)) 
          issues.Add(normalAbilitiesIssue);
        
        if (VerifyHeroAbilities(unit, out var heroAbilitiesIssue)) 
          issues.Add(heroAbilitiesIssue);
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
        issue = $"{unit.GetReadableId()} has an invalid Researches Available field.";
        return true;
      }
      
      return false;
    }
    
    private static bool VerifyResearchesRequired(Unit unit,[NotNullWhen(true)] out string? issue)
    {
      issue = null;
      
      if (!unit.IsTechtreeRequirementsModified)
        return false;

      try
      {
        _ = unit.TechtreeRequirements;
      }
      catch (KeyNotFoundException)
      {
        issue = $"{unit.GetReadableId()} has an invalid Researches Required field.";
        return true;
      }
      
      return false;
    }
    
    private static bool VerifyNormalAbilities(Unit unit, [NotNullWhen(true)] out string? issue)
    {
      issue = null;
      
      if (!unit.IsAbilitiesNormalModified)
        return false;

      try
      {
        _ = unit.AbilitiesNormal;
      }
      catch (KeyNotFoundException)
      {
        issue = $"{unit.GetReadableId()} has at least one invalid normal Ability.";
        return true;
      }
      
      return false;
    }
    
    private static bool VerifyHeroAbilities(Unit unit, [NotNullWhen(true)] out string? issue)
    {
      issue = null;
      
      if (!unit.IsAbilitiesHeroModified)
        return false;

      try
      {
        _ = unit.AbilitiesHero;
      }
      catch (KeyNotFoundException)
      {
        issue = $"{unit.GetReadableId()} has at least one invalid hero Ability.";
        return true;
      }
      
      return false;
    }
  }
}