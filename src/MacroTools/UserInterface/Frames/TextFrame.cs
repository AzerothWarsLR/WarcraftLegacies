namespace MacroTools.UserInterface.Frames;

public sealed class TextFrame : Frame
{
  public string Text
  {
    get => Handle.Text;
    set => Handle.Text = value;
  }

  /// <summary>
  /// Centers this text both horizontally and vertically within its own frame bounds.
  /// </summary>
  public void CenterText()
  {
    BlzFrameSetTextAlignment(Handle, TEXT_JUSTIFY_MIDDLE, TEXT_JUSTIFY_CENTER);
  }

  /// <summary>
  /// Scales this frame - including its text - uniformly around its anchor point. Used to shrink text below
  /// its template's default size (1 = default, less than 1 = smaller).
  /// </summary>
  public void SetScale(float scale)
  {
    BlzFrameSetScale(Handle, scale);
  }

  public TextFrame(string name, Frame parent, int priority) : base(name, parent, priority)
  {
  }

  public TextFrame(string name, Frame parent) : base(name, parent)
  {
  }

  public TextFrame(string typeName, string name, Frame parent, string inherits) : base(typeName, name, parent, inherits)
  {
  }
}
