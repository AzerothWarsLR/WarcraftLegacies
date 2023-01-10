using System;
using MacroTools;
using WarcraftLegacies.Source.Dialogue;

namespace WarcraftLegacies.Source.Setup
{
  public static class DialogueSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      try
      {
        ScourgeDialogueSetup.Setup();
        WarsongDialogueSetup.Setup();
        DruidsDialogueSetup.Setup(preplacedUnitSystem);
        LordaeronDialogueSetup.Setup(preplacedUnitSystem);
        IllidariDialogueSetup.Setup();
        SentinelsDialogueSetup.Setup();
        FrostwolfDialogueSetup.Setup();
        LegionDialogueSeup.Setup();
        DalaranDialogueSetup.Setup();
        QuelthalasDialogueSetup.Setup();
        GoblinDialogueSetup.Setup();
        KultirasDialogueSetup.Setup();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}