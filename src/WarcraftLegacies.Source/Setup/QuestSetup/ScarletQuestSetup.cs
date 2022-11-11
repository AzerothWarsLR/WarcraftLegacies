using MacroTools;
using WarcraftLegacies.Source.Quests.Scarlet;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class ScarletQuestSetup
  {
    public static void Setup()
    {
      var liberateLordaeron = new QuestLiberateLordaeron(Regions.ScarletHarbor);

      ScarletSetup.ScarletCrusade.StartingQuest = ScarletSetup.ScarletCrusade.AddQuest(new QuestTownWatch());
      ScarletSetup.ScarletCrusade.AddQuest(new QuestScarletCrusade(Regions.ScarletAmbient,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.Scarlet_Monastery_Exterior.Center),
        liberateLordaeron));
      ScarletSetup.ScarletCrusade.AddQuest(new QuestArgentDawn());
      ScarletSetup.ScarletCrusade.AddQuest(new QuestArathiVolunteers());
      ScarletSetup.ScarletCrusade.AddQuest(new QuestTyr(Regions.TyrUnlock));
    }
  }
}