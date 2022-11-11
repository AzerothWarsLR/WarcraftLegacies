using static War3Api.Common;

namespace WarcraftLegacies.Source.Rocks
{
  /// <summary>
  /// Sets up all <see cref="RockGroup"/>s in the <see cref="RockSystem"/>.
  /// </summary>
  public static class RockSetup
  {
    private static readonly int RockChunkId = FourCC("LTrc");
    
    public static void Setup()
    {
      RockSystem.Register(new RockGroup(Regions.KaliRock1, RockChunkId, 600));
      RockSystem.Register(new RockGroup(Regions.KaliRock2, RockChunkId, 600));
      RockSystem.Register(new RockGroup(Regions.KaliRock3, RockChunkId, 600));
      RockSystem.Register(new RockGroup(Regions.KaliRock4, RockChunkId, 600));
      RockSystem.Register(new RockGroup(Regions.KaliRock6, RockChunkId, 600));
      
      //RockSystem.Register(new RockGroup(Regions.NRRock1, _rockChunkId, 600)); //Todo: uncomment these
      //RockSystem.Register(new RockGroup(Regions.NRRock2, _rockChunkId, 600));
      //RockSystem.Register(new RockGroup(Regions.NRRock3, _rockChunkId, 600));

      RockSystem.Register(new RockGroup(Regions.KaliRock5, RockChunkId, 840));
    }
  }
}