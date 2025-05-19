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
    private static readonly int ForceWallChunk = FourCC("B005");

    public static void Setup()
    {

      //south rocks
      RockSystem.Register(new RockGroup(Regions.KaliRock12, RockChunkId, 0));

      //Northrend Rocks
      RockSystem.Register(new RockGroup(Regions.NorthrendRock1, RockChunkId, 360));
      RockSystem.Register(new RockGroup(Regions.NorthrendRock2, RockChunkId, 360));
      RockSystem.Register(new RockGroup(Regions.NorthrendRock3, RockChunkId, 360));
      RockSystem.Register(new RockGroup(Regions.NorthrendRock4, RockChunkId, 360));
      
      //AQ Rocks
      RockSystem.Register(new RockGroup(Regions.AQ_Blockers, RockChunkId, 0));

      //Bridge Rocks
      RockSystem.Register(new RockGroup(Regions.BridgeAmbient, RockChunkId, 1800));
    }
  }
}