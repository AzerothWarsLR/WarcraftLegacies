using System;
using WarcraftLegacies.Source.Dialogue;

namespace WarcraftLegacies.Source.Setup
{
  public static class DialogueSetup
  {
    public static void Setup()
    {
      try
      {
        ScourgeDialogueSetup.Setup();
        WarsongDialogueSetup.Setup();
        DruidsDialogueSetup.Setup();
        LordaeronDialogueSetup.Setup();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}