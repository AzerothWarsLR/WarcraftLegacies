using WarcraftLegacies.Source.Setup.QuestSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllQuestSetup
  {
    public static void Setup()
    {
      DalaranQuestSetup.Setup();
      DruidsQuestSetup.Setup();
      FelHordeQuestSetup.Setup();
      FrostwolfQuestSetup.Setup();
      IronforgeQuestSetup.Setup();
      LegionQuestSetup.Setup();
      LordaeronQuestSetup.Setup();
      QuelthalasQuestSetup.Setup();
      var questPlague = ScourgeQuestSetup.Setup();
      SentinelsQuestSetup.Setup();
      StormwindQuestSetup.Setup();
      WarsongQuestSetup.Setup();
      NagaQuestSetup.Setup();
      //GilneasQuestSetup.Setup();
      KultirasQuestSetup.Setup();
      ScarletQuestSetup.Setup();
      TrollQuestSetup.Setup();
      ForsakenQuestSetup.Setup(questPlague);
      TwilightQuestSetup.Setup();
      GoblinQuestSetup.Setup();
      DraeneiQuestSetup.Setup();
      SharedQuestSetup.Setup();
    }
  }
}