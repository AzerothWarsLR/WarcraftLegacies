using War3Api.Object;
using War3Net.Common.Extensions;
using Warcraft.Cartographer.Extensions;
using Warcraft.Integrity;
using WarcraftLegacies.Map.Tests.TestSupport;

namespace WarcraftLegacies.Map.Tests.ValidityTests;

[Collection(nameof(MapTestCollection))]
public sealed class TooltipValidityTests(MapTestFixture fixture)
{
  [Fact]
  public void AllItems_HaveValidTooltipReferences()
  {
    var issues = fixture.ObjectDatabase.GetItems().ToList()
      .Where(x => x.IsTextTooltipExtendedModified)
      .SelectMany(x => GetTooltipIssues(x.GetReadableId(), x.TextTooltipExtended))
      .ToList();

    ValidityTestHelpers.ThrowIfAny(issues);
  }

  [Fact]
  public void AllUnits_HaveValidTooltipReferences()
  {
    var issues = fixture.ObjectDatabase.GetUnits().ToList()
      .Where(x => x.IsTextTooltipExtendedModified)
      .SelectMany(x => GetTooltipIssues(x.GetReadableId(), x.TextTooltipExtended))
      .ToList();

    ValidityTestHelpers.ThrowIfAny(issues);
  }

  [Fact]
  public void AllAbilities_HaveValidTooltipReferences()
  {
    var issues = fixture.ObjectDatabase.GetAbilities().ToList()
      .SelectMany(GetAbilityTooltipIssues)
      .ToList();

    ValidityTestHelpers.ThrowIfAny(issues);
  }

  private IEnumerable<string> GetAbilityTooltipIssues(Ability ability)
  {
    var id = ability.GetReadableId();

    var leveledIssues = Enumerable.Range(1, ability.StatsLevels)
      .SelectMany(level => new[]
        {
          (IsModified: ability.IsTextTooltipNormalExtendedModified[level], Property: ability.TextTooltipNormalExtended),
          (IsModified: ability.IsTextTooltipTurnOffExtendedModified[level], Property: ability.TextTooltipTurnOffExtended),
        }
        .Where(x => x.IsModified)
        .Select(x => x.Property.TryGetStringAtLevel(level, x.IsModified))
        .OfType<string>()
        .SelectMany(tooltip => GetTooltipIssues(id, tooltip)));

    var learnIssues = ability.IsTextTooltipLearnExtendedModified
      ? GetTooltipIssues(id, ability.TextTooltipLearnExtended)
      : [];

    return leveledIssues.Concat(learnIssues);
  }

  private IEnumerable<string> GetTooltipIssues(string ownerId, string tooltip)
  {
    return MapDataRegex.ParseTags().Matches(tooltip)
      .Select(match => match.Groups["fourcc"].Value)
      .Where(fourcc => !fixture.ObjectDatabase.TryGetObject(fourcc.FromRawcode(), out _))
      .Distinct()
      .Select(fourcc => $"{ownerId} has an invalid tooltip tag '{fourcc}'.");
  }
}
