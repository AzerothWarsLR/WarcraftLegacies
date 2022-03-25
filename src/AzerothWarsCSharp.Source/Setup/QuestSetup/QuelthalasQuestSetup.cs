using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Quelthalas;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class QuelthalasQuestSetup
  {
    public static QuestData SUMMON_KIL { get; private set; }
    public static QuestData GREAT_TREACHERY { get; private set; }
    public static QuestData STAY_LOYAL { get; private set; }

    public static void Setup()
    {
      var quelthalas = QuelthalasSetup.FACTION_QUELTHALAS;
      //Setup
      QuestData newQuest = quelthalas.AddQuest(new QuestSilvermoon());
      QuestData tempestKeep = new QuestTempestKeep();

      quelthalas.StartingQuest = newQuest;
      //Early duel
      quelthalas.AddQuest(new QuestTheBloodElves());
      quelthalas.AddQuest(new QuestQueldanil());

      quelthalas.AddQuest(tempestKeep);
      tempestKeep.Progress = QuestProgress.Undiscovered;

      SUMMON_KIL = new QuestSummonKil();
      GREAT_TREACHERY = new QuestGreatTreachery();
      STAY_LOYAL = new QuestStayLoyal();
    }
  }
}