using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.RoC.Quests.Fel_Horde;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class FelHordeQuestSetup{

    public static void OnInit( ){
      //Early duel
      QuestData newQuest = FACTION_FEL_HORDE.AddQuest(QuestKillDraenei.create());
      FACTION_FEL_HORDE.StartingQuest = newQuest;
      FACTION_FEL_HORDE.AddQuest(QuestKilsorrow.create());
      FACTION_FEL_HORDE.AddQuest(QuestHellfire.create());
      FACTION_FEL_HORDE.AddQuest(QuestBlackrock.create());
      FACTION_FEL_HORDE.AddQuest(QuestFelHordeKillIronforge.create());
      FACTION_FEL_HORDE.AddQuest(QuestFelHordeKillStormwind.create());
      //Misc
      FACTION_FEL_HORDE.AddQuest(QuestGuldansLegacy.create());
    }

  }
}
