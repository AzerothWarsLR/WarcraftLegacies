using AzerothWarsCSharp.Source.RoC.Setup.QuestSetup;

namespace AzerothWarsCSharp.Source.RoC.Setup
{
  public static class AllQuestSetup{
    public static void Setup( ){
      DalaranQuestSetup_OnInit();
      DruidsQuestSetup_OnInit();
      FelHordeQuestSetup_OnInit();
      FrostwolfQuestSetup_OnInit();
      IronforgeQuestSetup_OnInit();
      LegionQuestSetup_OnInit();
      LordaeronQuestSetup_OnInit();
      QuelthalasQuestSetup_OnInit();
      ScourgeQuestSetup_OnInit();
      SentinelsQuestSetup_OnInit();
      StormwindQuestSetup_OnInit();
      WarsongQuestSetup_OnInit();
      NagaQuestSetup_OnInit();
      GilneasQuestSetup_OnInit();
      KultirasQuestSetup_OnInit();
      ScarletQuestSetup_OnInit();
      TrollQuestSetup_OnInit();
      ForsakenQuestSetup_OnInit();
      TwilightQuestSetup_OnInit();
      CthunQuestSetup_OnInit();
      GoblinQuestSetup.Setup();
      BlackEmpireQuestSetup_OnInit();
      DraeneiQuestSetup_OnInit();
    }

  }
}
