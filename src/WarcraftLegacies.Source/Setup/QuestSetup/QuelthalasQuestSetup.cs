using MacroTools;
using WarcraftLegacies.Source.Quests.Quelthalas;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class QuelthalasQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var quelthalas = QuelthalasSetup.Quelthalas;
      var newQuest = quelthalas.AddQuest(new QuestSilvermoon(Regions.SunwellAmbient,
        preplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_TOWER, new Point(20477, 17447)), preplacedUnitSystem));
      quelthalas.StartingQuest = newQuest;
      quelthalas.AddQuest(new QuestTheBloodElves(Regions.BloodElfSecondChanceSpawn));
      quelthalas.AddQuest(new QuestQueldanil(Regions.QuelDanil_Lodge));
      quelthalas.AddQuest(new QuestQueensArchive());
      quelthalas.AddQuest(new QuestForgottenKnowledge(Regions.IllidanStartingPosition));
    }
  }
}