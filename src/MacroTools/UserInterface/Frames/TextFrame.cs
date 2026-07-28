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
