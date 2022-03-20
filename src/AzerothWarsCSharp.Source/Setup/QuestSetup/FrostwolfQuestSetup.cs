using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Frostwolf;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class FrostwolfQuestSetup{

    public static void Setup( ){
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
