using MacroTools.Frames;

namespace MacroTools.BookSystem.Core;

public abstract class Card<T> : Frame
{
  /// <summary>
  /// The thing that the Card is representing.
  /// </summary>
  public abstract T? Item { get; set; }

  /// <summary>
  /// Returns true if the Card is actively representing something.
  /// </summary>
  public abstract bool Occupied { get; }

  /// <summary>
  /// Clears the thing that the Card is representing, if anything.
  /// </summary>
  public abstract void Clear();

  protected Card(Frame parent, float width, float height) : base("ArtifactItemBox", parent, 0)
  {
    Width = width;
    Height = height;
    Visible = false;
  }
}
