namespace MacroTools.DialogueSystem
{
  /// <summary>Provides methods to play one or more pieces of dialogue.</summary>
  public interface IHasPlayableDialogue
  {
    /// <summary>Plays the dialogue for the specified player..</summary>
    public void Play(player whichPlayer);
    
    /// <summary>How long the dialogue plays for.</summary>
    public float Length { get; }
  }
}