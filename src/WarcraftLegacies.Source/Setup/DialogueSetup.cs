using System;
using MacroTools;
using WarcraftLegacies.Source.Dialogue;

namespace WarcraftLegacies.Source.Setup
{
  public static class DialogueSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup legendSetup)
    {
      GameTime.GameStarted += (_, _) =>
      {
        try
        {
          ScourgeDialogueSetup.Setup(legendSetup);
          WarsongDialogueSetup.Setup(legendSetup);
          DruidsDialogueSetup.Setup(preplacedUnitSystem, legendSetup);
          LordaeronDialogueSetup.Setup(preplacedUnitSystem, legendSetup);
          IllidariDialogueSetup.Setup(legendSetup);
          SentinelsDialogueSetup.Setup(legendSetup);
          FrostwolfDialogueSetup.Setup(legendSetup);
          LegionDialogueSeup.Setup(legendSetup);
          QuelthalasDialogueSetup.Setup(legendSetup);
          GoblinDialogueSetup.Setup(legendSetup);
          KultirasDialogueSetup.Setup(legendSetup);
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Failed to run DialogueSetup: {ex}");
        }
      };
    }
  }
}