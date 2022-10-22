using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Quelthalas;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class QuelthalasQuestSetup
  {
    public static void Setup()
    {
      var quelthalas = QuelthalasSetup.Quelthalas;
      var newQuest = quelthalas.AddQuest(new QuestSilvermoon(Regions.SunwellAmbient,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS, new Point(20477, 17447))));
      quelthalas.StartingQuest = newQuest;
      quelthalas.AddQuest(new QuestTheBloodElves(Regions.BloodElfSecondChanceSpawn));
      quelthalas.AddQuest(new QuestQueldanil(Regions.QuelDanil_Lodge.Rect));
    }
  }
}