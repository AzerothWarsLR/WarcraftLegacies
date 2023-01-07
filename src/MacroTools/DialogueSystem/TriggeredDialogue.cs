namespace MacroTools.DialogueSystem
{
  /// <summary>
  /// Plays a particular <see cref="IHasPlayableDialogue"/> when conditions are met.
  /// </summary>
  public sealed class TriggeredDialogue
  {
    private readonly IHasPlayableDialogue _playableDialogue;

    /// <summary>
    /// Initializes a new instance of the <see cref="TriggeredDialogue"/> class.
    /// </summary>
    /// <param name="playableDialogue">The dialogue that will be played when the conditions are met.</param>
    public TriggeredDialogue(IHasPlayableDialogue playableDialogue)
    {
      _playableDialogue = playableDialogue;
    }
  }
}