using MacroTools;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Dalaran;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class DalaranQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      var dalaran = DalaranSetup.Dalaran;

      QuestNewGuardian newGuardian = new(artifactSetup.BookOfMedivh, allLegendSetup.Dalaran.Jaina,
        allLegendSetup.Dalaran.Dalaran);
      QuestAegwynn aegwynn = new(allLegendSetup.Dalaran.Jaina, allLegendSetup.Dalaran.Antonidas);
      QuestTheNexus theNexus = new(allLegendSetup.Dalaran, allLegendSetup.Scourge.TheFrozenThrone, allLegendSetup.Neutral.TheNexus);
      QuestCrystalGolem crystalGolem = new(allLegendSetup.Neutral.DraktharonKeep);
      QuestFallenGuardian fallenGuardian = new(allLegendSetup.Neutral.Karazhan);

      newGuardian.AddObjective(new ObjectiveQuestNotComplete(theNexus));
      crystalGolem.AddObjective(new ObjectiveQuestNotComplete(theNexus));
      aegwynn.AddObjective(new ObjectiveQuestNotComplete(theNexus));

      theNexus.AddObjective(new ObjectiveQuestNotComplete(newGuardian));

      var questSouthshore = dalaran.AddQuest(new QuestSouthshore(Regions.SouthshoreUnlock,
        preplacedUnitSystem.GetUnit(FourCC("nmrm"), Regions.SouthshoreUnlock.Center)));
      dalaran.StartingQuest = questSouthshore;
      var questShadowfang = dalaran.AddQuest(new QuestShadowfang(Regions.ShadowfangUnlock,
        preplacedUnitSystem.GetUnit(Constants.UNIT_NWLD_DIRE_WOLF_CREEP, new Point(7668.5f, 4352.2f))));
      dalaran.AddQuest(new QuestDalaran(new[]
      {
        Regions.Dalaran
      }, new QuestData[]
      {
        questSouthshore,
        questShadowfang
      }));
      dalaran.AddQuest(new QuestJainaSoulGem(allLegendSetup.Dalaran.Jaina, allLegendSetup.Neutral.Caerdarrow));
      dalaran.AddQuest(new QuestBlueDragons(allLegendSetup.Neutral.TheNexus));
      dalaran.AddQuest(new QuestKarazhan(allLegendSetup.Neutral.Karazhan));

      dalaran.AddQuest(new QuestTheramore(allLegendSetup.Dalaran.Jaina, allLegendSetup.Dalaran.Dalaran,  Regions.Theramore));

      dalaran.AddQuest(crystalGolem);
      dalaran.AddQuest(fallenGuardian);
      dalaran.AddQuest(aegwynn);
      dalaran.AddQuest(newGuardian);
      dalaran.AddQuest(theNexus);
    }
  }
}