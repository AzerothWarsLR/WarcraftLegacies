using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.KulTiras;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class KultirasQuestSetup
  {
    public static void Setup()
    {
      var kultiras = KultirasSetup.FACTION_KULTIRAS;

      kultiras.StartingQuest = kultiras.AddQuest(new QuestBoralus());
      kultiras.AddQuest(new QuestUnlockShip(PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H08T_PROUDMOORE_FLAGSHIP_LANDED)));
      kultiras.AddQuest(new QuestSafeSea());
      kultiras.AddQuest(new QuestTheramore());
      kultiras.AddQuest(new QuestBeyondPortal());
      kultiras.AddQuest(new QuestJoinCrusade());
    }
  }
}