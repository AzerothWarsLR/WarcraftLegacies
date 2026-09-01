using WarcraftLegacies.Source.GameLogic.Rocks;
using WarcraftLegacies.Source.GameLogic.SouthKalimdorGuard;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Sets up all <see cref="RockGroup"/>s in the <see cref="RockSystem"/>.
/// </summary>
public static class RockSetup
{
  private static readonly int _rockChunkId = FourCC("LTrc");

  public static void Setup()
  {
    //Northrend Rocks
    RockSystem.Register(new RockGroup(Regions.NorthrendRock1, _rockChunkId, 6));
    RockSystem.Register(new RockGroup(Regions.NorthrendRock2, _rockChunkId, 6));
    RockSystem.Register(new RockGroup(Regions.NorthrendRock3, _rockChunkId, 6));
    RockSystem.Register(new RockGroup(Regions.NorthrendRock4, _rockChunkId, 6));

    //AQ Rocks
    RockSystem.Register(new RockGroup(Regions.AQ_Blockers, _rockChunkId));

    //Bridge Rocks
    RockSystem.Register(new RockGroup(Regions.BridgeAmbient, _rockChunkId, 30));

    RockSystem.Register(new RockGroup(Regions.SouthKalimdor2, _rockChunkId, SouthKalimdorGuardSystem.UnlockTurn));
    RockSystem.Register(new RockGroup(Regions.SouthKalimdor3, _rockChunkId, SouthKalimdorGuardSystem.UnlockTurn));
  }
}
