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
        preplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_TOWER, new Point(20477, 17447)),
        preplacedUnitSystem, allLegendSetup.Quelthalas.LegendSilvermoon, allLegendSetup.Quelthalas.LegendSunwell));
      quelthalas.StartingQuest = newQuest;
      quelthalas.AddQuest(new QuestTheBloodElves(Regions.BloodElfSecondChanceSpawn,
        allLegendSetup.Neutral.DraktharonKeep, allLegendSetup.Quelthalas.LegendSunwell,
        allLegendSetup.Quelthalas.LegendAnasterian, allLegendSetup.Quelthalas.LegendKael));
      quelthalas.AddQuest(new QuestQueldanil(Regions.QuelDanil_Lodge, allLegendSetup.Neutral.Caerdarrow));
      quelthalas.AddQuest(new QuestQueensArchive(allLegendSetup.Quelthalas.LegendKael));
      quelthalas.AddQuest(new QuestForgottenKnowledge(Regions.IllidanStartingPosition));
    }
  }
}