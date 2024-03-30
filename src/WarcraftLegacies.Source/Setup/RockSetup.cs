using WarcraftLegacies.Source.Rocks;

namespace WarcraftLegacies.Source.Setup
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

      //south rocks
      RockSystem.Register(new RockGroup(Regions.KaliRock12, RockChunkId, 300));

      //Kali Ashenvale rocks
      RockSystem.Register(new RockGroup(Regions.KaliRock7, ForestChunkId, 480));
      RockSystem.Register(new RockGroup(Regions.KaliRock10, ForestChunkId, 480));
      RockSystem.Register(new RockGroup(Regions.KaliRock11, ForestChunkId, 480));
      RockSystem.Register(new RockGroup(Regions.KaliRock13, ForestChunkId, 480));

      //Northrend Rocks
      RockSystem.Register(new RockGroup(Regions.NorthrendRock1, RockChunkId, 360));
      RockSystem.Register(new RockGroup(Regions.NorthrendRock2, RockChunkId, 360));
      RockSystem.Register(new RockGroup(Regions.NorthrendRock3, RockChunkId, 360));
      RockSystem.Register(new RockGroup(Regions.NorthrendRock4, RockChunkId, 360));

      //Bridge Rocks
      RockSystem.Register(new RockGroup(Regions.BridgeAmbient, RockChunkId, 1800));
    }
  }
}