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
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      var lordaeron = LordaeronSetup.Lordaeron;
      var kingTerenas = LegendLordaeron.Terenas?.Unit;
      var uther = LegendLordaeron.Uther;
      if (lordaeron != null && kingTerenas != null && uther != null)
      {
        var questStrahnbrad = new QuestStrahnbrad(Regions.StrahnbradUnlock);
        var questStratholme = new QuestStratholme(Regions.StratholmeUnlock, preplacedUnitSystem);
        lordaeron.AddQuest(questStratholme);
        lordaeron.StartingQuest = questStratholme;
        lordaeron.AddQuest(questStrahnbrad);
        lordaeron.AddQuest(new QuestCapitalCity(Regions.Terenas, kingTerenas, uther,
          new QuestData[]
          {
          questStrahnbrad,
          questStratholme
          }));
        lordaeron.AddQuest(new QuestMograine());
        lordaeron.AddQuest(new QuestShoresOfNorthrend());
        lordaeron.AddQuest(new QuestThunderEagle());
        lordaeron.AddQuest(new QuestKingArthas(kingTerenas, artifactSetup.CrownOfLordaeron));
        lordaeron.AddQuest(new QuestKingdomOfManLordaeron(artifactSetup.CrownOfLordaeron, artifactSetup.CrownOfStormwind));
        lordaeron.AddQuest(new QuestGarithosCrusade());
        lordaeron.AddQuest(new QuestGarithosMindControl());
      }
    }
  }
}