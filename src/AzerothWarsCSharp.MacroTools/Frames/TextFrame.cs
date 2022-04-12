using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames
{
  public class TextFrame : Frame
  {
    public string Text
    {
      get => BlzFrameGetText(Handle);
      set => BlzFrameSetText(Handle, value);
    }

    public TextFrame(string name, Frame parent, int priority, int createContext) : base(name, parent, priority, createContext)
    {
    }

    public TextFrame(string name, Frame parent, int createContext) : base(name, parent, createContext)
    {
    }

    public TextFrame(string typeName, string name, Frame parent, string inherits, int createContext) : base(typeName, name, parent, inherits, createContext)
    {
    }
  }
}