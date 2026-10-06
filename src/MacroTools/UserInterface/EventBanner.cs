using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface;

/// <summary>
/// A large banner near the top of the screen that announces world events to every player.
/// </summary>
public static class EventBanner
{
  private const float DisplayDuration = 9;
  private const float Width = 0.46f;
  private const float Height = 0.095f;

  private static Frame? _backdrop;
  private static Frame? _icon;
  private static TextFrame? _title;
  private static TextFrame? _body;
  private static timer? _hideTimer;

  /// <summary>Shows the banner, replacing whatever it was showing before.</summary>
  public static void Show(string iconPath, string title, string body)
  {
    if (_backdrop == null || _icon == null || _title == null || _body == null || _hideTimer == null)
    {
      Create();
    }

    _icon!.Texture = iconPath;
    _title!.Text = title;
    _body!.Text = body;
    _backdrop!.Visible = true;
    _hideTimer!.Start(DisplayDuration, false, Hide);
  }

  private static void Hide()
  {
    if (_backdrop != null)
    {
      _backdrop.Visible = false;
    }
  }

  private static void Create()
  {
    _backdrop = new Frame("ArtifactMenuBackdrop", originframetype.GameUI.GetOriginFrame(0), 0)
    {
      Width = Width,
      Height = Height,
      Visible = false
    };
    _backdrop.SetAbsPoint(framepointtype.Top, 0.4f, 0.545f);

    _icon = new Frame("BACKDROP", "EventBannerIcon", _backdrop)
    {
      Width = 0.05f,
      Height = 0.05f
    };
    _icon.SetPoint(framepointtype.Left, _backdrop, framepointtype.Left, 0.022f, 0);
    _backdrop.AddFrame(_icon);

    _title = new TextFrame("ArtifactMenuTitle", _backdrop, 0);
    _title.SetPoint(framepointtype.TopLeft, _icon, framepointtype.TopRight, 0.012f, 0.004f);
    _title.SetPoint(framepointtype.Right, _backdrop, framepointtype.Right, -0.02f, 0);
    _title.SetTextAlignment(textaligntype.Top, textaligntype.Left);
    _backdrop.AddFrame(_title);

    _body = new TextFrame("ArtifactItemOwnerText", _backdrop, 0);
    _body.SetPoint(framepointtype.TopLeft, _icon, framepointtype.TopRight, 0.012f, -0.02f);
    _body.SetPoint(framepointtype.Right, _backdrop, framepointtype.Right, -0.02f, 0);
    _body.SetPoint(framepointtype.Bottom, _backdrop, framepointtype.Bottom, 0, 0.012f);
    _body.SetTextAlignment(textaligntype.Top, textaligntype.Left);
    _backdrop.AddFrame(_body);

    _hideTimer = timer.Create();
  }
}
