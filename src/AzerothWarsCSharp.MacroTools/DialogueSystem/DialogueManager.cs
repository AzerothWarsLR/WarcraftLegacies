using System.Collections.Generic;

namespace AzerothWarsCSharp.MacroTools.DialogueSystem
{
  public static class DialogueManager
  {
    private static readonly List<Dialogue> _dialogues = new();

    public static void Add(Dialogue dialogue)
    {
      _dialogues.Add(dialogue);
      foreach (var objective in dialogue.Objectives)
      {
        objective.ProgressChanged += dialogue.OnComplete;
      }
    }
  }
}