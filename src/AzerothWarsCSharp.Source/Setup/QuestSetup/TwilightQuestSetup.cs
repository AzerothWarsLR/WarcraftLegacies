using AzerothWarsCSharp.Source.Quests.Twilight;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class TwilightQuestSetup{

    public static void Setup( ){

      FACTION_TWILIGHT.StartingQuest = FACTION_TWILIGHT.AddQuest(QuestDragonmawPort.create());
      FACTION_TWILIGHT.AddQuest(QuestGrimBatol.create());
      FACTION_TWILIGHT.AddQuest(QuestSpreadTheWord.create());
      FACTION_TWILIGHT.AddQuest(QuestThunderfury.create());
      FACTION_TWILIGHT.AddQuest(QuestFeludius.create());
      FACTION_TWILIGHT.AddQuest(QuestIgnacious.create());
      FACTION_TWILIGHT.AddQuest(QuestCataclysm.create());

    }

  }
}
