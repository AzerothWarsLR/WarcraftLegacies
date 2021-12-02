using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class TeamSetup
  {
    public static void Setup()
    {
      var northAlliance = new Team("Alliance", "HeroicVictory");
      var dalaran = new Faction("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0", "Jaina");
      var kultiras = new Faction("Kul'tiras", PLAYER_COLOR_EMERALD, "|cff00781e", "Proudmoore");
      var lordaeron = new Faction("Lordaeron", PLAYER_COLOR_BLUE, "|c000042ff", "Arthas");
      var ironforge = new Faction("Ironforge", PLAYER_COLOR_YELLOW, "|C00FFFC01", "HeroMountainKing");
      var quelthalas = new Faction("Quel'thalas", PLAYER_COLOR_CYAN, "|C0000FFFF", "Sylvanas");
      var stormwind = new Faction("Stormwind", PLAYER_COLOR_AQUA, "|CFF106246", "Knight");
      FactionSystem.FactionSetTeam(dalaran, northAlliance);
      FactionSystem.FactionSetTeam(kultiras, northAlliance);
      FactionSystem.FactionSetTeam(lordaeron, northAlliance);
      FactionSystem.FactionSetTeam(ironforge, northAlliance);
      FactionSystem.FactionSetTeam(quelthalas, northAlliance);
      FactionSystem.FactionSetTeam(stormwind, northAlliance);
      FactionSystem.Add(northAlliance);
      
      var felHorde = new Faction("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000", "PitLord");
      var legion = new Faction("Legion", PLAYER_COLOR_PEANUT, "|CFFBF8F4F", "Kiljaedin");
      var legionTeam = new Team("Burning Legion", "DarkVictory");
      FactionSystem.FactionSetTeam(felHorde, legionTeam);
      FactionSystem.FactionSetTeam(legion, legionTeam);
      FactionSystem.Add(legionTeam);
      
      var frostwolf = new Faction("Frostwolf", PLAYER_COLOR_RED, "|c00ff0303", "Thrall");
      var warsong = new Faction("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000", "HellScream");
      var horde = new Team("Horde", "DarkVictory");
      var zandalar = new Faction("Zandalar", PLAYER_COLOR_PEACH, "|cffff8c6c","HeadHunterBerserker");
      FactionSystem.FactionSetTeam(frostwolf, horde);
      FactionSystem.FactionSetTeam(warsong, horde);
      FactionSystem.FactionSetTeam(zandalar, horde);
      FactionSystem.Add(horde);
      
      var sentinels = new Faction("Sentinels", PLAYER_COLOR_MINT, "|CFFBFFF80", "PriestessOfTheMoon");
      var druids = new Faction("Druids", PLAYER_COLOR_BROWN, "|c004e2a04", "Furion");
      var nightElves = new Team("Night Elves", "HeroicVictory");
      FactionSystem.FactionSetTeam(sentinels, nightElves);
      FactionSystem.FactionSetTeam(druids, nightElves);
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