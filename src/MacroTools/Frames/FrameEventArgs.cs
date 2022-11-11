using System;

namespace MacroTools.Frames
{
  public class FrameEventArgs : EventArgs
  {
    public Frame Frame { get; }
    
    public FrameEventArgs(Frame frame)
    {
      Frame = frame;
    }
  }
}