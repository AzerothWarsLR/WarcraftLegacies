using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Quests.Dalaran;
using AzerothWarsCSharp.Source.Quests.KulTiras;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class DalaranQuestSetup
  {
    public static void Setup()
    {
      var dalaran = DalaranSetup.Dalaran;

      QuestNewGuardian newGuardian = new QuestNewGuardian();
      QuestTheNexus theNexus = new QuestTheNexus();
      QuestCrystalGolem crystalGolem = new QuestCrystalGolem();
      QuestFallenGuardian fallenGuardian = new QuestFallenGuardian();
      QuestSouthshore questSouthshore = new QuestSouthshore(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nmrm")));

      newGuardian.AddQuestItem(new QuestItemDontCompleteQuest(theNexus));
      crystalGolem.AddQuestItem(new QuestItemDontCompleteQuest(theNexus));
      fallenGuardian.AddQuestItem(new QuestItemDontCompleteQuest(theNexus));
      theNexus.AddQuestItem(new QuestItemDontCompleteQuest(newGuardian));

      //Early duel
      dalaran.AddQuest(questSouthshore);
      dalaran.StartingQuest = questSouthshore;
      dalaran.AddQuest(new QuestShadowfang(PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_O02J_WORGEN_GILNEAS)));
      dalaran.AddQuest(new QuestDalaran());
      dalaran.AddQuest(new QuestJainaSoulGem());
      dalaran.AddQuest(new QuestBlueDragons());
      //Misc
      dalaran.AddQuest(new QuestKarazhan());
      dalaran.AddQuest(new QuestTheramore());

      dalaran.AddQuest(crystalGolem);
      dalaran.AddQuest(fallenGuardian);
      dalaran.AddQuest(newGuardian);
      dalaran.AddQuest(theNexus);
    }
  }
}