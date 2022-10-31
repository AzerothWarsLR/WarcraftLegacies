using WarcraftLegacies.MacroTools;
using WarcraftLegacies.Source.Quests.KulTiras;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class KultirasQuestSetup
  {
    public static void Setup()
    {
      var kultiras = KultirasSetup.Kultiras;

      kultiras.StartingQuest = kultiras.AddQuest(new QuestBoralus(Regions.Kultiras));
      kultiras.AddQuest(new QuestUnlockShip(Regions.ShipAmbient,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS)));
      kultiras.AddQuest(new QuestSafeSea());
      kultiras.AddQuest(new QuestTheramore(Regions.Theramore));
      kultiras.AddQuest(new QuestBeyondPortal());
      kultiras.AddQuest(new QuestJoinCrusade());
    }
  }
}