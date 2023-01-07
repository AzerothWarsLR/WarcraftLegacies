using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace MacroTools.DialogueSystem
{
  /// <summary>
  /// A sequence of <see cref="Dialogue"/>s that can be made to play in order.
  /// </summary>
  public sealed class DialogueSequence : IHasPlayableDialogue
  {
    /// <summary>
    /// Plays the entire <see cref="Dialogue"/> sequence in order.
    /// </summary>
    public void Play(IEnumerable<player>? players)
    {
      throw new NotImplementedException();
    }
  }
}