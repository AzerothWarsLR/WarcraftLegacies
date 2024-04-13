using MacroTools.Frames;

namespace MacroTools.BookSystem.Core
{
  public abstract class Card : Frame
  {
    public abstract bool Occupied { get; }
    
    protected Card(Frame parent, float width, float height) : base("ArtifactItemBox", parent, 0)
    {
      Width = width;
      Height = height;
      Visible = false;
    }
  }
}