using WarcraftLegacies.Source.Rocks;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Sets up all <see cref="RockGroup"/>s in the <see cref="RockSystem"/>.
/// </summary>
public static class RockSetup
{
  private static readonly int _rockChunkId = FourCC("LTrc");
  private static readonly int _islandChunkId = FourCC("B013");
  private static readonly int _forceWallChunk = FourCC("B005");

  public static void Setup()
  {

    //south rocks
    RockSystem.Register(new RockGroup(Regions.KaliRock12, _rockChunkId, 0));

    //Northrend Rocks
    RockSystem.Register(new RockGroup(Regions.NorthrendRock1, _rockChunkId, 360));
    RockSystem.Register(new RockGroup(Regions.NorthrendRock2, _rockChunkId, 360));
    RockSystem.Register(new RockGroup(Regions.NorthrendRock3, _rockChunkId, 360));
    RockSystem.Register(new RockGroup(Regions.NorthrendRock4, _rockChunkId, 360));

    //AQ Rocks
    RockSystem.Register(new RockGroup(Regions.AQ_Blockers, _rockChunkId, 0));

    //Bridge Rocks
    RockSystem.Register(new RockGroup(Regions.BridgeAmbient, _rockChunkId, 1800));
  }
}
