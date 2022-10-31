using MacroTools.FactionSystem;
using static War3Api.Common;

namespace TestMap.Source.Setup.FactionSetup.FactionSetup
{
  public static class DalaranSetup
  {
    public static Faction? Dalaran { get; private set; }
    
    public static void Setup()
    {
      Dalaran = new Faction("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0",
        "ReplaceableTextures\\CommandButtons\\BTNJaina.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
      };
      FactionManager.Register(Dalaran);
    }
  }
}