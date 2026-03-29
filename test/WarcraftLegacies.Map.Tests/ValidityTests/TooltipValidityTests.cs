using System.Text;
using War3Net.Common.Extensions;
using Warcraft.Cartographer.Extensions;
using WarcraftLegacies.Map.Tests.TestSupport;
using Xunit.Sdk;

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

    ThrowIfAny(issues);
  }

  [Fact]
  public void AllUnits_HaveValidTooltipReferences()
  {
    var issues = fixture.ObjectDatabase.GetUnits().ToList()
      .Where(x => x.IsTextTooltipExtendedModified)
      .SelectMany(x => GetTooltipIssues(x.GetReadableId(), x.TextTooltipExtended))
      .ToList();

    ThrowIfAny(issues);
  }

  private IEnumerable<string> GetTooltipIssues(string ownerId, string tooltip)
  {
    return MapDataRegex.ParseTags().Matches(tooltip)
      .Select(match => match.Groups["fourcc"].Value)
      .Where(fourcc => !fixture.ObjectDatabase.TryGetObject(fourcc.FromRawcode(), out _))
      .Distinct()
      .Select(fourcc => $"{ownerId} has a tooltip reference to unknown object {fourcc}.");
  }

  private static void ThrowIfAny(List<string> issues)
  {
    if (issues.Count == 0)
    {
      return;
    }

    var sb = new StringBuilder();
    foreach (var issue in issues)
    {
      sb.AppendLine(issue);
    }

    throw new XunitException(sb.ToString());
  }
}
