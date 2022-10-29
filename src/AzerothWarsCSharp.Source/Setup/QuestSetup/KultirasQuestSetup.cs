using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.KulTiras;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
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
      kultiras.AddQuest(new QuestTheramore(Regions.Kultiras));
      kultiras.AddQuest(new QuestBeyondPortal());
      kultiras.AddQuest(new QuestJoinCrusade());
    }
  }
}