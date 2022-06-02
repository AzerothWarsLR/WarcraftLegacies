using System;
using AzerothWarsCSharp.Source.Dialogue;

namespace AzerothWarsCSharp.Source.Setup
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
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}