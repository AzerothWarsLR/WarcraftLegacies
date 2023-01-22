using static War3Api.Common;

namespace WarcraftLegacies.Source.Rocks
{
  /// <summary>
  /// Sets up all <see cref="RockGroup"/>s in the <see cref="RockSystem"/>.
  /// </summary>
  public static class RockSetup
  {
    private static readonly int RockChunkId = FourCC("LTrc");
    private static readonly int IslandChunkId = FourCC("B013");

    public static void Setup()
    {
      RockSystem.Register(new RockGroup(Regions.KaliRock1, RockChunkId, 600));
      RockSystem.Register(new RockGroup(Regions.KaliRock4, RockChunkId, 600));
      RockSystem.Register(new RockGroup(Regions.KaliRock7, RockChunkId, 600));
      RockSystem.Register(new RockGroup(Regions.KaliRock8, RockChunkId, 600));

      RockSystem.Register(new RockGroup(Regions.IslandBlocker1, IslandChunkId, 1200));
      RockSystem.Register(new RockGroup(Regions.IslandBlocker2, IslandChunkId, 1200));
      RockSystem.Register(new RockGroup(Regions.IslandBlocker3, IslandChunkId, 1200));
      RockSystem.Register(new RockGroup(Regions.IslandBlocker4, IslandChunkId, 1200));
      RockSystem.Register(new RockGroup(Regions.IslandBlocker5, IslandChunkId, 1200));

    }
  }
}