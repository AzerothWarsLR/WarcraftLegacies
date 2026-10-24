namespace MacroTools.UserInterface.Frames;

public sealed class TextFrame : Frame
{
  public string Text
  {
    get => Handle.Text;
    set => Handle.Text = value;
  }

  public void CenterText()
  {
    BlzFrameSetTextAlignment(Handle, TEXT_JUSTIFY_MIDDLE, TEXT_JUSTIFY_CENTER);
  }

  public void SetScale(float scale)
  {
    BlzFrameSetScale(Handle, scale);
  }

  /// <summary>Sets where the text sits inside the frame.</summary>
  public void SetTextAlignment(textaligntype vertical, textaligntype horizontal) =>
    Handle.SetTextAlignment(vertical, horizontal);

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
