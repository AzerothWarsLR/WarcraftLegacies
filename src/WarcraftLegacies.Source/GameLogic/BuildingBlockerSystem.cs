using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic;

public static class BuildBlockerSystem
{
  private static readonly int BlockerId = FourCC("tp18");
  private static readonly List<destructable> ActiveBlockers = new();

  public static void BlockRegion(Rectangle rect)
  {
    var x = rect.Left;
    while (x <= rect.Right)
    {
      var y = rect.Bottom;
      while (y <= rect.Top)
      {
        var blocker = CreateDestructable(BlockerId, x, y, 0, 1, 0);
        ActiveBlockers.Add(blocker);
        y += 128f;
      }

      x += 128f;
    }
  }

  public static void UnblockAll()
  {
    foreach (var blocker in ActiveBlockers)
    {
      KillDestructable(blocker);
    }

    ActiveBlockers.Clear();
  }
}
