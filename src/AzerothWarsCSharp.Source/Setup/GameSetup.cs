using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Artifacts;
using AzerothWarsCSharp.Source.Game_Logic;
using AzerothWarsCSharp.Source.Game_Logic.GameEnd;
using AzerothWarsCSharp.Source.IncompatibleUpgrades;
using AzerothWarsCSharp.Source.Mechanics.Quelthalas;
using AzerothWarsCSharp.Source.User_Interface;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      Legend.Setup();
      QuestData.Setup();
      ShoreSetup.Setup();
      InstanceSetup_OnInit();
      TeamSetup_OnInit();
      AllFactionSetup.Setup();
      PersonSetup_OnInit();
      ArtifactSetup_OnInit();
      ControlPointSetup.Setup();
      AllQuestSetup.Setup();
      ResearchSetup_OnInit();
      ObserverSetup_OnInit();
      SpellsSetup.Setup();
      CpCapture.Setup();
      DestructibleHider.Setup();
      CheatSetup.Setup();
      CommandSetup.Setup();
      ControlPointVictory.Setup();
      SilvermoonDies.Setup();
      ZinrokhAssembly.Setup();
      IncompatibleTierConfig.Setup();
      FactionMultiboard.Setup();
    }
  }
}