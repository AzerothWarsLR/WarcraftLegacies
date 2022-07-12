using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Frames.Books.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.Frames.Books.Powers;
using AzerothWarsCSharp.MacroTools.Mechanics;
using AzerothWarsCSharp.MacroTools.UserInterface;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      CreateUnit(Player(0), FourCC("hars"), 0, 0, 0);
      SetPlayerState(Player(0), PLAYER_STATE_RESOURCE_FOOD_CAP, 100);

      PreplacedUnitSystem.Initialize();
      LegendSetup.Setup();
      //ShoreSetup.Setup();
      //InstanceSetup.Setup();
      TeamSetup.Setup();
      AllFactionSetup.Setup();
      PlayerSetup.Setup();
      ArtifactSetup.Setup();
      ControlPointSetup.Setup();
      AllQuestSetup.Setup();
      //ResearchSetup.Setup();
      //ObserverSetup.Setup();
      SpellSetup.Setup();
      CheatSetup.Setup();
      //CommandSetup.Setup();
      //ControlPointVictory.Setup();
      //IncompatibleTierConfig.Setup();
      FactionMultiboard.Setup();
      PowerBook.Initialize();
      ArtifactBook.Initialize();
      TestSetup.Setup();
      WaygateManager.Setup(FourCC("nwgt"));
      HintSetup.Setup();
      PreplacedUnitSystem.Shutdown();
      DialogueSetup.Setup();
      AugmentSetup.Setup();
    }
  }
}