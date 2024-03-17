using System.Collections.Generic;
using WarcraftLegacies.Source.FactionMechanics.Scourge.Plague;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// Provides information about how the Plague should work.
  /// </summary>
  public sealed class PlagueParameters
  {
    /// <summary>Where to spawn Plague Cauldrons. Each <see cref="Rectangle"/> gets 1 army.</summary>
    public List<Rectangle> PlagueRects { get; set; } = new();

    /// <summary>Which units to spawn around Plague Cauldrons and how many.</summary>
    public List<PlagueArmySummonParameter> PlagueArmySummonParameters { get; set; } = new();

    /// <summary>List of potential points spawned armies can be sent to.</summary>
    public List<Point> AttackTargets { get; set; } = new();
  }
}