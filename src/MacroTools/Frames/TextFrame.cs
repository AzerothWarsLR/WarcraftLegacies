namespace MacroTools.Frames;

public sealed class TextFrame : Frame
{
  public string Text
  {
    get => BlzFrameGetText(Handle);
    set => BlzFrameSetText(Handle, value);
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
