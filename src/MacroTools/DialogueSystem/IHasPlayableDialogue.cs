using static War3Api.Common;

namespace MacroTools.DialogueSystem
{
  /// <summary>Provides method/s to play one or more pieces of dialogue.</summary>
  public interface IHasPlayableDialogue
  {
    /// <summary>Plays one or more pieces of dialogue to the specified player.</summary>
    public void Play(player whichPlayer);
    
    /// <summary>How long the dialogue plays for.</summary>
    public float Length { get; }
  }
}