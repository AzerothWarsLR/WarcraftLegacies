using System.Collections.Generic;
using static War3Api.Common;

namespace MacroTools.DialogueSystem
{
  /// <summary>
  /// A sequence of <see cref="Dialogue"/>s that can be made to play in order.
  /// </summary>
  public sealed class DialogueSequence : IHasPlayableDialogue
  {
    private readonly IEnumerable<Dialogue> _dialogues;

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogueSequence"/> class.
    /// </summary>
    public DialogueSequence(params Dialogue[] dialogues)
    {
      _dialogues = dialogues;
    }
    
    /// <summary>
    /// Plays the entire <see cref="Dialogue"/> sequence in order.
    /// </summary>
    public void Play(List<player>? players)
    {
      foreach (var dialogue in _dialogues)
        dialogue.Play(players);
    }
  }
}