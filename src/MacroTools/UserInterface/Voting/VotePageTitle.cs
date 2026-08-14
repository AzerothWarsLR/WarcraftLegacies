using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Voting;

public static class VotePageTitle
{
  public const float Height = 0.05f;

  public const float Gap = 0.012f;

  private const float Scale = 1.2f;

  public static void Add(Frame root, string text, float rootWidth, float topMargin)
  {
    var titleFrame = new TextFrame("ArtifactMenuTitle", root, 0)
    {
      Width = rootWidth,
      Height = Height,
      Text = text
    };

    var centerX = rootWidth / 2;
    var centerY = -topMargin - Height / 2;
    titleFrame.SetPoint(framepointtype.Center, root, framepointtype.TopLeft, centerX / Scale, centerY / Scale);
    titleFrame.SetScale(Scale);
    titleFrame.CenterText();
    root.AddFrame(titleFrame);
  }
}
