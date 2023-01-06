using WarcraftLegacies.Source.Quests.Scarlet;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class ScarletQuestSetup
  {
    public static void Setup()
    {
      ScarletSetup.ScarletCrusade.StartingQuest = ScarletSetup.ScarletCrusade.AddQuest(new QuestTownWatch());
      ScarletSetup.ScarletCrusade.AddQuest(new QuestArathiVolunteers());
    }
  }
}