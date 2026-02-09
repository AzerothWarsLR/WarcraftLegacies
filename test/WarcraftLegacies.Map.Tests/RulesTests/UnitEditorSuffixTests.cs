using System.Text;
using Warcraft.Cartographer.Extensions;
using WarcraftLegacies.Map.Tests.TestSupport;
using Xunit.Sdk;

namespace WarcraftLegacies.Map.Tests.RulesTests;

public sealed class UnitEditorSuffixTests(MapTestFixture mapTestFixture) : IClassFixture<MapTestFixture>
{
  private static readonly List<string> _approvedEditorSuffixes =
  [
    "Cthun",
    "Nzoth",
    "Dalaran",
    "Nexus",
    "Draenei",
    "Druids",
    "Fel",
    "Frostwolf",
    "Gilneas",
    "Illidari",
    "Ironforge",
    "KulTiras",
    "Legion",
    "Lordaeron",
    "Quelthalas",
    "Scarlet",
    "Scourge",
    "Sentinels",
    "Skywall",
    "Stormwind",
    "Sunfury",
    "Warsong",
    "Creep",
    "Horde",
    "NightElves",
    "Alliance",
    "Evil",
    "Patrons",
    "Neutral",
    "Gate",
    "Portal",
    ""
  ];

  [Fact]
  public void AllUnits_FirstWordOfEditorSuffix_MatchesApprovedList()
  {
    var issues = new List<string>();
    var objectDatabase = mapTestFixture.ObjectDatabase;

    foreach (var unit in objectDatabase.GetUnits().ToArray())
    {
      if (unit.EditorCategorizationSpecial)
      {
        continue;
      }

      var firstEditorSuffix = unit.TextNameEditorSuffix
        .Replace("(", string.Empty)
        .Replace(")", string.Empty)
        .Split(" ")
        .First()
        .Split(',')
        .First()
        .Split('-')
        .First();
      if (!_approvedEditorSuffixes.Contains(firstEditorSuffix))
      {
        issues.Add($"{unit.TextName} {unit.TextNameEditorSuffix} [{unit.GetReadableId()}]: **{firstEditorSuffix}**");
      }
    }

    if (issues.Count == 0)
    {
      return;
    }

    var exceptionMessageBuilder = new StringBuilder();
    exceptionMessageBuilder.AppendLine(
      $"The following {issues.Count} units have an invalid word as the first word of their Editor Suffix");
    foreach (var issue in issues)
    {
      exceptionMessageBuilder.AppendLine(issue);
    }

    throw new XunitException(exceptionMessageBuilder.ToString());
  }
}
