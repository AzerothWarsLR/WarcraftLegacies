using System;
using AzerothWarsCSharp.Source.Dialogue;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

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
        LordaeronDialogueSetup.Setup();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}