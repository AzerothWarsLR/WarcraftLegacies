using System.Diagnostics.CodeAnalysis;
using System.Text;
using Launcher.Extensions;
using War3Api.Object;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker
{
  public sealed class AbilityLevelSkipTests : IClassFixture<MapTestFixture>
  {
    private readonly MapTestFixture _mapTestFixture;

    public AbilityLevelSkipTests(MapTestFixture mapTestFixture)
    {
      _mapTestFixture = mapTestFixture;
    }
    
    [Fact]
    public void AllUnits_HaveValidFields()
    {
      var issues = new List<string>();
      var objectDatabase = _mapTestFixture.ObjectDatabase;
      
      foreach (var unit in objectDatabase.GetAbilities())
      {
        if (VerifyLevelSkip(unit, out var levelSkipIssue)) 
          issues.Add(levelSkipIssue);
      }
      if (issues.Count == 0)
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      foreach (var issue in issues)
        exceptionMessageBuilder.AppendLine(issue);
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }

    private static bool VerifyLevelSkip(Ability ability, [NotNullWhen(true)] out string? issue)
    {
      issue = null;
      
      if (!ability.StatsHeroAbility)
        return false;

      if (ability.StatsRequiredLevel == 10 && ability.StatsLevelSkipRequirement != 5)
      {
        issue = $"{GetReadableId(ability)} is an ultimate and should have a level skip requirement of 5.";
        return true;
      }
      
      if (ability.StatsRequiredLevel == 0 && ability.StatsLevelSkipRequirement != 0)
      {
        issue = $"{GetReadableId(ability)} is a hero ability and should have a level skip requirement of 0.";
        return true;
      }
      
      return false;
    }
    
    private static string GetReadableId(BaseObject baseObject) =>
      baseObject.NewId != 0 ? baseObject.NewId.IdToFourCc() : baseObject.OldId.IdToFourCc();
  }
}