using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Frostwolf;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class FrostwolfQuestSetup{

    public static void Setup( )
    {
      var frostwolf = FrostwolfSetup.FACTION_FROSTWOLF;
      
      //Setup
      QuestData newQuest = frostwolf.AddQuest(new QuestSeaWitch());
      frostwolf.StartingQuest = newQuest;
      frostwolf.AddQuest(new QuestThunderBluff(Regions.ThunderBluff.Rect));
      frostwolf.AddQuest(new QuestStonemaul());
      //Starting duel
      frostwolf.AddQuest(new QuestDrektharsSpellbook());
      //frostwolf.AddQuest(new QuestScepterOfTheQueenWarsong());
      //Misc
      frostwolf.AddQuest(new QuestFreeNerzhul());
    }

  }
}
