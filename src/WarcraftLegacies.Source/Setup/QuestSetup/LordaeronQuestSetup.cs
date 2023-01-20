using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Lordaeron;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  /// <summary>
  /// Setup of all quests for the Lordaeron <see cref="Faction"/>
  /// </summary>
  public static class LordaeronQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      var questStrahnbrad = new QuestStrahnbrad(Regions.StrahnbradUnlock);
      var questStratholme = new QuestStratholme(Regions.StratholmeUnlock, preplacedUnitSystem);
      LordaeronSetup.Lordaeron.AddQuest(new QuestHearthglen(Regions.Hearthglen));
      LordaeronSetup.Lordaeron.AddQuest(questStratholme);
      LordaeronSetup.Lordaeron.StartingQuest = questStratholme;
      LordaeronSetup.Lordaeron.AddQuest(questStrahnbrad);
      LordaeronSetup.Lordaeron.AddQuest(new QuestCapitalCity(Regions.Terenas, legendLordaeron.Terenas.Unit, legendLordaeron.Uther,
        new QuestData[]
        {
          questStrahnbrad,
          questStratholme
        }));
      LordaeronSetup.Lordaeron.AddQuest(new QuestTyrHand(Regions.TyrUnlock));
      LordaeronSetup.Lordaeron.AddQuest(new QuestMograine());
      LordaeronSetup.Lordaeron.AddQuest(new QuestShoresOfNorthrend());
      LordaeronSetup.Lordaeron.AddQuest(new QuestThunderEagle());
      LordaeronSetup.Lordaeron.AddQuest(new QuestKingArthas(legendLordaeron.Terenas.Unit, artifactSetup.CrownOfLordaeron));
      LordaeronSetup.Lordaeron.AddQuest(new QuestKingdomOfManLordaeron(artifactSetup.CrownOfLordaeron, artifactSetup.CrownOfStormwind));
    }
  }
}