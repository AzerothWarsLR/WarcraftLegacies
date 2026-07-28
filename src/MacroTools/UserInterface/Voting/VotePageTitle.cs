using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Voting;

/// <summary>
/// Adds a single page-level heading above a vote panel's content (e.g. "Custom Options"), spanning the panel's
/// full width - distinct from each individual <see cref="VoteGroup"/>'s own title, which labels just that one
/// group of buttons.
/// </summary>
public static class VotePageTitle
{
  /// <summary>The vertical space the heading itself takes up.</summary>
  public const float Height = 0.05f;

  /// <summary>The gap left between the heading and whatever's laid out below it.</summary>
  public const float Gap = 0.012f;

  // Scaled up so the page heading actually reads as a bigger deal than each VoteGroup's own (unscaled) title -
  // otherwise "Custom Options" and "Control Point Gold Rate" render at identical size with nothing to tell a
  // page heading apart from a section heading.
  private const float Scale = 1.2f;

  /// <summary>
  /// Adds the heading as a child of <paramref name="root"/>, centered across <paramref name="rootWidth"/> and
  /// sitting <paramref name="topMargin"/> below <paramref name="root"/>'s top edge.
  /// </summary>
  public static void Add(Frame root, string text, float rootWidth, float topMargin)
  {
    var titleFrame = new TextFrame("ArtifactMenuTitle", root, 0)
    {
      Width = rootWidth,
      Height = Height,
      Text = text
    };

    // BlzFrameSetScale also scales the offset SetPoint was given (as if measured from the parent's own
    // origin), not just the frame's own size - see VoteGroup's description positioning for the full story.
    // Dividing the intended offset by scale up front cancels that out.
    var centerX = rootWidth / 2;
    var centerY = -topMargin - Height / 2;
    titleFrame.SetPoint(framepointtype.Center, root, framepointtype.TopLeft, centerX / Scale, centerY / Scale);
    titleFrame.SetScale(Scale);
    titleFrame.CenterText();
    root.AddFrame(titleFrame);
  }
}
