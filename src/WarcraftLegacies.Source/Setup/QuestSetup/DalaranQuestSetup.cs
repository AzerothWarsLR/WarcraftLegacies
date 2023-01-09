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
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      var dalaran = DalaranSetup.Dalaran;

      QuestNewGuardian newGuardian = new(artifactSetup.BookOfMedivh);
      QuestTheNexus theNexus = new();
      QuestCrystalGolem crystalGolem = new();
      QuestFallenGuardian fallenGuardian = new();

      newGuardian.AddObjective(new ObjectiveDontCompleteQuest(theNexus));
      crystalGolem.AddObjective(new ObjectiveDontCompleteQuest(theNexus));
      theNexus.AddObjective(new ObjectiveDontCompleteQuest(newGuardian));

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
      dalaran.AddQuest(new QuestJainaSoulGem());
      dalaran.AddQuest(new QuestBlueDragons());
      dalaran.AddQuest(new QuestKarazhan());

      dalaran.AddQuest(crystalGolem);
      dalaran.AddQuest(fallenGuardian);
      dalaran.AddQuest(newGuardian);
      dalaran.AddQuest(theNexus);
    }
  }
}