namespace WarcraftLegacies.MacroTools.Frames.Books
{
  public abstract class Card : Frame
  {
    protected Card(Frame parent, float width, float height) : base("ArtifactItemBox", parent, 0)
    {
      Width = width;
      Height = height;
    }
  }
}