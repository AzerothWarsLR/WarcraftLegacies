using AzerothWarsCSharp.Source.Setup.QuestSetup;

namespace AzerothWarsCSharp.Source.Setup
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
      CthunQuestSetup.Setup();
      GoblinQuestSetup.Setup();
      BlackEmpireQuestSetup.Setup();
      DraeneiQuestSetup.Setup();
      SharedQuestSetup.Setup();
    }
  }
}