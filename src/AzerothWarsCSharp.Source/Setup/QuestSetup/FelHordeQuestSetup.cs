using AzerothWarsCSharp.Source.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Fel_Horde;
using static AzerothWarsCSharp.Source.Setup.FactionSetup.FelHordeSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class FelHordeQuestSetup
  {
    public static void Setup()
    {
      //Early duel
      QuestData newQuest = FACTION_FEL_HORDE.AddQuest(new QuestKillDraenei());
      FACTION_FEL_HORDE.StartingQuest = newQuest;
      FACTION_FEL_HORDE.AddQuest(new QuestKilsorrow());
      FACTION_FEL_HORDE.AddQuest(new QuestHellfire());
      FACTION_FEL_HORDE.AddQuest(new QuestBlackrock());
      FACTION_FEL_HORDE.AddQuest(new QuestFelHordeKillIronforge());
      FACTION_FEL_HORDE.AddQuest(new QuestFelHordeKillStormwind());
      //Misc
      FACTION_FEL_HORDE.AddQuest(new QuestGuldansLegacy());
    }
  }
}