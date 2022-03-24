using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Warsong;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class WarsongQuestSetup{

    public static void Setup( ){
      //Setup
      FACTION_WARSONG.StartingQuest = FACTION_WARSONG.AddQuest(new QuestLumberQuota());
      FACTION_WARSONG.AddQuest(new QuestCrossroads());
      FACTION_WARSONG.AddQuest(new QuestChenStormstout(PreplacedUnitSystem.GetUnitByUnitType(FourCC("Nsjs"))));
      FACTION_WARSONG.AddQuest(new QuestFountainOfBlood());
      //Early duel
      FACTION_WARSONG.AddQuest(new QuestWarsongKillDruids());
      FACTION_WARSONG.AddQuest(new QuestMoreWyverns());
      //Misc
      FACTION_WARSONG.AddQuest(new QuestWarsongHold());

    }

  }
}
