using MacroTools.FactionSystem;
using static War3Api.Common;

namespace TestMap.Source.Setup.FactionSetup.FactionSetup
{
  public static class DruidsSetup
  {
    public static Faction? FactionDruids { get; private set; }
    
    public static void Setup()
    {
      FactionDruids = new Faction("Druids", PLAYER_COLOR_BROWN, "|c004e2a04",
        "ReplaceableTextures\\CommandButtons\\BTNFurion.blp")
      {
        StartingGold = 150,
        StartingLumber = 500
      };
      FactionManager.Register(FactionDruids);
    }
  }
}