using MacroTools.FactionSystem;
using MacroTools.Powers;
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
      Dalaran.ModObjectLimit(FourCC("Rhan"), 1);
      Dalaran.ModObjectLimit(FourCC("Rhri"), 1);
      Dalaran.ModObjectLimit(FourCC("Rhde"), 1);
      
      Dalaran.AddPower(new DummyPower("Cool Dalaran Guy", "You're from space, and can use spaceships.", "Marine"));
      Dalaran.AddPower(new DummyPower("Good Job!", "You're from space, and can use spaceships.", "Marine"));
      Dalaran.AddPower(new DummyPower("Gamer Time!", "You're from space, and can use spaceships.", "Marine"));
      
      FactionManager.Register(Dalaran);
    }
  }
}