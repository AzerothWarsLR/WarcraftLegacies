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

      ScarletSetup.ScarletCrusade.StartingQuest = ScarletSetup.ScarletCrusade.AddQuest(new QuestTownWatch());
      ScarletSetup.ScarletCrusade.AddQuest(new QuestScarletCrusade(Regions.ScarletAmbient,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H00T_SCARLET_MONASTERY_LORDAERON), liberateLordaeron));
      ScarletSetup.ScarletCrusade.AddQuest(new QuestArgentDawn());
      ScarletSetup.ScarletCrusade.AddQuest(new QuestArathiVolunteers());
      ScarletSetup.ScarletCrusade.AddQuest(new QuestTyr(Regions.TyrUnlock));
    }
  }
}