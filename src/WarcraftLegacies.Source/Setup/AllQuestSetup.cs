using MacroTools;
using WarcraftLegacies.Source.Setup.QuestSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      QuelthalasQuestSetup.Setup(preplacedUnitSystem);
      DalaranQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      DruidsQuestSetup.Setup(artifactSetup);
      FelHordeQuestSetup.Setup(preplacedUnitSystem);
      FrostwolfQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      IronforgeQuestSetup.Setup(preplacedUnitSystem);
      LegionQuestSetup.Setup(preplacedUnitSystem);
      LordaeronQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      var questPlague = ScourgeQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      SentinelsQuestSetup.Setup(artifactSetup);
      StormwindQuestSetup.Setup(preplacedUnitSystem);
      WarsongQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      NagaQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      GilneasQuestSetup.Setup(artifactSetup);
      KultirasQuestSetup.Setup(preplacedUnitSystem);
      ScarletQuestSetup.Setup(preplacedUnitSystem);
      TrollQuestSetup.Setup(artifactSetup);
      ForsakenQuestSetup.Setup();
      GoblinQuestSetup.Setup();
      DraeneiQuestSetup.Setup(preplacedUnitSystem);
      DragonmawQuestSetup.Setup(preplacedUnitSystem);
      SharedQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
    }
  }
}