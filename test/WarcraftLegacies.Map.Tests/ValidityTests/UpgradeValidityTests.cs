using War3Api.Object;
using War3Net.Common.Extensions;
using Warcraft.Cartographer.Extensions;
using WarcraftLegacies.Map.Tests.TestSupport;

namespace WarcraftLegacies.Map.Tests.ValidityTests;

[Collection(nameof(MapTestCollection))]
public sealed class UpgradeValidityTests(MapTestFixture fixture)
{
  [Fact]
  public void AllUpgrades_HaveValidEffectReferences()
  {
    var issues = fixture.ObjectDatabase.GetUpgrades()
      .SelectMany(x => GetEffectIssues(x.GetReadableId(), GetEffectFourCcs(x)))
      .ToList();

    ValidityTestHelpers.ThrowIfAny(issues);
  }

  private IEnumerable<string> GetEffectIssues(string upgradeId, IEnumerable<string> fourCcs)
  {
    return fourCcs
      .Where(fourCc => !fixture.ObjectDatabase.TryGetObject(fourCc.FromRawcode(), out _))
      .Select(fourCc => $"{upgradeId} has an invalid effect '{fourCc}'.");
  }

  private static IEnumerable<string> GetEffectFourCcs(Upgrade upgrade)
  {
    return new (bool IsModified, string FourCc)[]
    {
      (upgrade.IsDataEffect1_gco1Modified, upgrade.DataEffect1_gco1),
      (upgrade.IsDataEffect2_gco2Modified, upgrade.DataEffect2_gco2),
      (upgrade.IsDataEffect3_gco3Modified, upgrade.DataEffect3_gco3),
      (upgrade.IsDataEffect4_gco4Modified, upgrade.DataEffect4_gco4),
    }
    .Where(x => x.IsModified && !string.IsNullOrEmpty(x.FourCc) && x.FourCc != "-")
    .Select(x => x.FourCc);
  }
}
