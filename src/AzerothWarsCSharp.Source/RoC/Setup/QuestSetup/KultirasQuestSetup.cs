using AzerothWarsCSharp.Source.RoC.Quests.KulTiras;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class KultirasQuestSetup{

    public static void Setup( ){

      FACTION_KULTIRAS.StartingQuest = FACTION_KULTIRAS.AddQuest(QuestBoralus.create());
      FACTION_KULTIRAS.AddQuest(QuestUnlockShip.create());
      FACTION_KULTIRAS.AddQuest(QuestSafeSea.create());
      FACTION_KULTIRAS.AddQuest(QuestTheramore.create());
      FACTION_KULTIRAS.AddQuest(QuestBeyondPortal.create());
      FACTION_KULTIRAS.AddQuest(QuestJoinCrusade.create());

    }

  }
}
