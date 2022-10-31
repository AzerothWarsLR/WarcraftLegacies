using System;

namespace WarcraftLegacies.MacroTools.Frames
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