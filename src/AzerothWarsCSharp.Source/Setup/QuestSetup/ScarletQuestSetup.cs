using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Scarlet;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class ScarletQuestSetup
  {
    public static void Setup()
    {
      var liberateLordaeron = new QuestLiberateLordaeron(Regions.ScarletHarbor);
      
      ScarletSetup.FactionScarlet.StartingQuest = ScarletSetup.FactionScarlet.AddQuest(new QuestTownWatch());
      ScarletSetup.FactionScarlet.AddQuest(new QuestMonastery(Regions.ScarletAmbient,
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H00T_SCARLET_MONASTERY_LORDAERON), liberateLordaeron));
      ScarletSetup.FactionScarlet.AddQuest(new QuestArgentDawn());
      ScarletSetup.FactionScarlet.AddQuest(new QuestArathiVolunteers());
      ScarletSetup.FactionScarlet.AddQuest(new QuestTyr(Regions.TyrUnlock));
    }
  }
}