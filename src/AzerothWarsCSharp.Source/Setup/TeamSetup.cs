using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestObjectives;
using AzerothWarsCSharp.MacroTools.QuestOutcomes;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class TeamSetup
  {
    public static void Setup()
    {
      var felHorde = new Faction("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000", "PitLord");
      var legion = new Faction("Legion", PLAYER_COLOR_PEANUT, "|CFFBF8F4F", "Kiljaedin");
      var legionTeam = new Team("Burning Legion", "DarkVictory");
      FactionSystem.FactionSetTeam(felHorde, legionTeam);
      FactionSystem.FactionSetTeam(legion, legionTeam);
      FactionSystem.Add(legionTeam);

      var thrall = new Legend(FourCC("Othr"))
      {
        Name = "Thrall"
      };
      
      var frostwolf = new Faction("Frostwolf", PLAYER_COLOR_RED, "|c00ff0303", "Thrall");
      FactionSystem.PlayerSetFaction(Player(0), frostwolf);
      var drektharsSpellBookQuest = new Quest("Drekthar's Spellbook", "SorceressMaster")
      {
        Flavour =
          "The savage Night Elves threaten the safety of the entire Horde. Capture their World Tree and bring Thrall to its roots.",
        CompletionFlavour =
          "The World Tree, Nordrassil, has been captured by the forces of the Horde. Drek'thar has gifted Warchief Thrall his magical spellbook for this achievement."
      };
      drektharsSpellBookQuest.AddObjective(new QuestObjectiveTime(5));
      drektharsSpellBookQuest.AddObjective(new QuestObjectiveKillUnit(CreateUnit(Player(0), FourCC("hfoo"), 0, 0, 0)));
      drektharsSpellBookQuest.AddOutcome(new QuestOutcomeChangeFactionName("Boopboop"));
      drektharsSpellBookQuest.AddOutcome(new QuestOutcomeSpawnLegend(thrall, new Point(0, 0), "my house", 5));
      FactionSystem.FactionAddQuest(frostwolf, drektharsSpellBookQuest);

      var testQuest = new Quest("Fat Dab", "Archimonde")
      {
        Flavour = "Sometimes you have to do a fully sick dab.",
        CompletionFlavour = "You did it! The first ever fully sick dab."
      };
      testQuest.AddObjective(new QuestObjectiveControlLegend(thrall));
      FactionSystem.FactionAddQuest(frostwolf, testQuest);
      
      var warsong = new Faction("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000", "HellScream");
      var horde = new Team("Horde", "DarkVictory");
      var zandalar = new Faction("Zandalar", PLAYER_COLOR_PEACH, "|cffff8c6c", "HeadHunterBerserker");
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