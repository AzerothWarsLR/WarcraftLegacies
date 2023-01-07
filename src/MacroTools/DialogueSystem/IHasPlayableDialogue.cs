using System.Collections.Generic;
using static War3Api.Common;

namespace MacroTools.DialogueSystem
{
  /// <summary>
  /// Provides method/s to play one or more pieces of dialogue.
  /// </summary>
  public interface IHasPlayableDialogue
  {
    /// <summary>
    /// Plays one or more pieces of dialogue to the specified players.
    /// </summary>
    public void Play(List<player>? players);
  }
}