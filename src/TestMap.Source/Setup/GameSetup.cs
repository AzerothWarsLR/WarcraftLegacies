using MacroTools;
using MacroTools.Mechanics;
using MacroTools.PassiveAbilitySystem;
using MacroTools.UserInterface;
using static War3Api.Common;

namespace TestMap.Source.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      var hars = CreateUnit(Player(0), FourCC("hars"), 0, 0, 0);
      SetPlayerState(Player(0), PLAYER_STATE_RESOURCE_FOOD_CAP, 100);
      
      LegendSetup.Setup();
      TeamSetup.Setup();
      AllFactionSetup.Setup();
      PlayerSetup.Setup();
      ArtifactSetup.Setup();
      ControlPointSetup.Setup();
      AllQuestSetup.Setup();
      SpellSetup.Setup();
      CheatSetup.Setup();
      FactionMultiboard.Setup();
      BookSetup.Setup();
      TestSetup.Setup();
      WaygateManager.Setup(FourCC("nwgt"));
      HintSetup.Setup();
      DialogueSetup.Setup();
      AugmentSetup.Setup();
      PassiveAbilityManager.InitializePreplacedUnits();
    }
  }
}