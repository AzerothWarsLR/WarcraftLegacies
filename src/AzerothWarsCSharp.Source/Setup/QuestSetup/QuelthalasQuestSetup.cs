using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Quelthalas;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class QuelthalasQuestSetup
  {
    public static QuestData SUMMON_KIL { get; private set; }
    public static QuestData GREAT_TREACHERY { get; private set; }
    public static QuestData STAY_LOYAL { get; private set; }

    public static void Setup()
    {
      var quelthalas = QuelthalasSetup.FactionQuelthalas;
      QuestData newQuest = quelthalas.AddQuest(new QuestSilvermoon(Regions.SunwellAmbient,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS, new Point(20477, 17447))));
      //QuestData tempestKeep = new QuestTempestKeep();
      quelthalas.StartingQuest = newQuest;
      quelthalas.AddQuest(new QuestTheBloodElves(Regions.BloodElfSecondChanceSpawn));
      quelthalas.AddQuest(new QuestQueldanil(Regions.QuelDanil_Lodge.Rect));

      //quelthalas.AddQuest(tempestKeep);
      //tempestKeep.Progress = QuestProgress.Undiscovered;

      SUMMON_KIL = new QuestSummonKil();
      GREAT_TREACHERY = new QuestGreatTreachery();
      STAY_LOYAL = new QuestStayLoyal();
    }
  }
}