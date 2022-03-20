using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.RoC.Quests.Fel_Horde;
using static AzerothWarsCSharp.Source.RoC.Setup.FactionSetup.FelHordeSetup;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
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