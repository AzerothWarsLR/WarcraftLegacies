using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Fel_Horde;
using static AzerothWarsCSharp.Source.Setup.FactionSetup.FelHordeSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class FelHordeQuestSetup
  {
    public static void Setup()
    {
      //Early duel
      QuestData newQuest = FactionFelHorde.AddQuest(new QuestKillDraenei());
      FactionFelHorde.StartingQuest = newQuest;
      FactionFelHorde.AddQuest(new QuestKilsorrow(PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_KIL_SORROW_FORTRESS)));
      FactionFelHorde.AddQuest(new QuestHellfire());
      FactionFelHorde.AddQuest(new QuestBlackrock());
      FactionFelHorde.AddQuest(new QuestFelHordeKillIronforge());
      FactionFelHorde.AddQuest(new QuestFelHordeKillStormwind());
      //Misc
      FactionFelHorde.AddQuest(new QuestGuldansLegacy());
    }
  }
}