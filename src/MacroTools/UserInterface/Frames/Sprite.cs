namespace MacroTools.UserInterface.Frames;

/// <summary>A user interface element that plays a model, like a glow.</summary>
public sealed class Sprite : Frame
{
  public Sprite(string name, framehandle parent) : base("SPRITE", name, parent)
  {
  }

  /// <summary>The model the sprite plays.</summary>
  public string Model
  {
    set => Handle.SetModel(value, 0);
  }
}
