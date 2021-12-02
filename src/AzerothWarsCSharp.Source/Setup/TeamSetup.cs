using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class TeamSetup
  {
    public static void Setup()
    {
      var northAlliance = new Team("Alliance", "HeroicVictory");
      var kultiras = new Faction("Kul'tiras", PLAYER_COLOR_EMERALD, "|cff00781e", "Proudmoore");
      FactionSystem.FactionSetTeam(kultiras, northAlliance);
      FactionSystem.Add(northAlliance);
      
      var legion = new Team("Burning Legion", "DarkVictory");
      FactionSystem.Add(legion);
      
      var horde = new Team("Horde", "DarkVictory");
      var zandalar = new Faction("Zandalar", PLAYER_COLOR_PEACH, "|cffff8c6c","HeadHunterBerserker");
      FactionSystem.FactionSetTeam(zandalar, horde);
      FactionSystem.Add(horde);
      
      var nightElves = new Team("Night Elves", "HeroicVictory");
      FactionSystem.Add(nightElves);
      
      var oldGods = new Team("Old Gods", "DarkVictory");
      FactionSystem.Add(oldGods);
      
      var naga = new Team("Naga", "DarkVictory");
      FactionSystem.Add(naga);
      
      var gilneas = new Team("Gilneas", "HeroicVictory");
      FactionSystem.Add(gilneas);
      
      var scarlet = new Team("Scarlet Crusade", "DarkVictory");
      FactionSystem.Add(scarlet);
      
      var forsaken = new Team("Forsaken", "DarkVictory");
      FactionSystem.Add(forsaken);
      
      var scourge = new Team("Scourge", "DarkVictory");
      FactionSystem.Add(scourge);
    }
  }
}