using System.Collections.Generic;
using WarcraftLegacies.Source.FactionMechanics.Scourge.Plague;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Skywall
{
  /// <summary>
  /// Provides information about how the Plague should work.
  /// </summary>
  public sealed class InvasionParameters
  {
    /// <summary>Where to spawn invasion units. Each <see cref="Rectangle"/> gets 1 army.</summary>
    public List<Rectangle> InvasionRects { get; set; } = new();

    /// <summary>Which units to spawn at the spots and how many.</summary>
    public List<InvasionArmySummonParameter> InvasionArmySummonParameters { get; set; } = new();

    /// <summary>List of potential points spawned armies can be sent to.</summary>
    public List<Point> AttackTargets { get; set; } = new();
  }
}