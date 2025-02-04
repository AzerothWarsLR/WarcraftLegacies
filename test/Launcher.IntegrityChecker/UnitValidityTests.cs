using System.Diagnostics.CodeAnalysis;
using System.Text;
using Launcher.Extensions;
using Launcher.IntegrityChecker.TestSupport;
using War3Api.Object;
using War3Api.Object.Abilities;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker
{
  public sealed class UnitValidityTests : IClassFixture<MapTestFixture>
  {
    private readonly MapTestFixture _mapTestFixture;

    public UnitValidityTests(MapTestFixture mapTestFixture)
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
        if (VerifyUnitsTrained(unit, out var unitsTrainedIssues)) 
          issues.Add(unitsTrainedIssues);
        
        if (VerifyResearchesAvailable(unit, out var researchesAvailableIssue)) 
          issues.Add(researchesAvailableIssue);
        
        if (VerifyResearchesRequired(unit, out var researchesRequiredIssue)) 
          issues.Add(researchesRequiredIssue);
        
        if (VerifyNormalAbilities(unit, out var normalAbilitiesIssue)) 
          issues.Add(normalAbilitiesIssue);
        
        if (VerifyHeroAbilities(unit, out var heroAbilitiesIssue)) 
          issues.Add(heroAbilitiesIssue);

        if (VerifyForbiddenAbilities(unit, out var forbiddenAbilityIssue))
          issues.Add(forbiddenAbilityIssue);
      }
      if (issues.Count == 0)
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      foreach (var issue in issues)
        exceptionMessageBuilder.AppendLine(issue);
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }

    private static bool VerifyUnitsTrained(Unit unit, [NotNullWhen(true)] out string? issue)
    {
      issue = null;
      
      if (!unit.IsTechtreeUnitsTrainedModified)
        return false;

      try
      {
        _ = unit.TechtreeUnitsTrained;
      }
      catch (KeyNotFoundException)
      {
        issue = $"{unit.GetReadableId()} has an invalid Units Trained field.";
        return true;
      }
      
      return false;
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
    
    private static bool VerifyForbiddenAbilities(Unit unit, [NotNullWhen(true)] out string? issue)
    {
      issue = null;

      foreach (var ability in unit.AbilitiesNormal)
      {
        if (AbilityIsForbidden(ability))
        {
          issue = $"{unit.GetReadableId()} has forbidden unit ability {ability.GetReadableId()}. Legacies doesn't use blight.";
          return true;
        }
      }

      //todo: re-enable this but fix all of the blight issues
      // foreach (var ability in unit.AbilitiesHero)
      // {
      //   if (AbilityIsForbidden(ability))
      //   {
      //     issue = $"{unit.GetReadableId()} has forbidden hero ability {ability.GetReadableId()}. Legacies doesn't use blight.";
      //     return true;
      //   }
      // }
      
      return false;
    }
    
    private static bool AbilityIsForbidden(Ability ability)
    {
      if (ability is BlightDispelLarge or BlightDispelSmall or BlightPlacement or BlightedGoldMine or BlightGrowthLarge or BlightGrowthSmall)
        return true;

      return false;
    }
  }
}