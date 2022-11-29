using MacroTools;
using WarcraftLegacies.Source.Setup.QuestSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      QuelthalasQuestSetup.Setup(preplacedUnitSystem);
      DalaranQuestSetup.Setup(preplacedUnitSystem);
      DruidsQuestSetup.Setup();
      FelHordeQuestSetup.Setup(preplacedUnitSystem);
      FrostwolfQuestSetup.Setup(preplacedUnitSystem);
      IronforgeQuestSetup.Setup(preplacedUnitSystem);
      LegionQuestSetup.Setup(preplacedUnitSystem);
      LordaeronQuestSetup.Setup(preplacedUnitSystem);
      var questPlague = ScourgeQuestSetup.Setup(preplacedUnitSystem);
      SentinelsQuestSetup.Setup();
      StormwindQuestSetup.Setup(preplacedUnitSystem);
      WarsongQuestSetup.Setup(preplacedUnitSystem);
      NagaQuestSetup.Setup();
      GilneasQuestSetup.Setup();
      KultirasQuestSetup.Setup(preplacedUnitSystem);
      ScarletQuestSetup.Setup(preplacedUnitSystem);
      TrollQuestSetup.Setup();
      ForsakenQuestSetup.Setup(questPlague, preplacedUnitSystem);
      GoblinQuestSetup.Setup();
      DraeneiQuestSetup.Setup(preplacedUnitSystem);
      DragonmawQuestSetup.Setup(preplacedUnitSystem);
      SharedQuestSetup.Setup(preplacedUnitSystem);
    }
  }
}