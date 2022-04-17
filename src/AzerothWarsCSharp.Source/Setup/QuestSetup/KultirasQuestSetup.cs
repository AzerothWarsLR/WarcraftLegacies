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

      kultiras.StartingQuest = kultiras.AddQuest(new QuestBoralus(Regions.Kultiras));
      kultiras.AddQuest(new QuestUnlockShip(Regions.ShipAmbient,
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H08T_PROUDMOORE_FLAGSHIP_LANDED)));
      kultiras.AddQuest(new QuestSafeSea());
      kultiras.AddQuest(new QuestTheramore(Regions.Kultiras));
      kultiras.AddQuest(new QuestBeyondPortal());
      kultiras.AddQuest(new QuestJoinCrusade());
    }
  }
}