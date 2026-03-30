using War3Net.Common.Extensions;
using Warcraft.Cartographer.Extensions;
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

  private IEnumerable<string> GetTooltipIssues(string ownerId, string tooltip)
  {
    return MapDataRegex.ParseTags().Matches(tooltip)
      .Select(match => match.Groups["fourcc"].Value)
      .Where(fourcc => !fixture.ObjectDatabase.TryGetObject(fourcc.FromRawcode(), out _))
      .Distinct()
      .Select(fourcc => $"{ownerId} has an invalid tooltip tag '{fourcc}'.");
  }
}
