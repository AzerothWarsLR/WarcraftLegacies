using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.RoC.Quests.Frostwolf;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class FrostwolfQuestSetup{

    public static void OnInit( ){
      //Setup
      QuestData newQuest = FACTION_FROSTWOLF.AddQuest(QuestSeaWitch.create());
      FACTION_FROSTWOLF.StartingQuest = newQuest;
      FACTION_FROSTWOLF.AddQuest(QuestThunderBluff.create());
      FACTION_FROSTWOLF.AddQuest(QuestStonemaul.create());
      //Starting duel
      FACTION_FROSTWOLF.AddQuest(QuestDrektharsSpellbook.create());
      FACTION_FROSTWOLF.AddQuest(QuestScepterOfTheQueenWarsong.create());
      //Misc
      FACTION_FROSTWOLF.AddQuest(QuestFreeNerzhul.create());
    }

  }
}
