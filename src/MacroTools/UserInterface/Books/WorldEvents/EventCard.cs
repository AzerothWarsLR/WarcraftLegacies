using MacroTools.Localization;
using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Frames;
using MacroTools.WorldEvents;

namespace MacroTools.UserInterface.Books.WorldEvents;

public sealed class EventCard : Card<WorldEvent>
{
  private const float BoxWidth = 0.34f;
  private const float BoxHeight = 0.15f;

  private WorldEvent? _worldEvent;
  private readonly Frame _icon;
  private readonly TextFrame _title;
  private readonly TextFrame _textFrame;

  /// <inheritdoc />
  public override bool Occupied => Item != null;

  /// <inheritdoc />
  public override void Clear() => Item = null;

  /// <summary>
  /// The <see cref="WorldEvent"/> currently being represented by this <see cref="EventCard"/>.
  /// </summary>
  public override WorldEvent? Item
  {
    get => _worldEvent;
    set
    {
      Visible = value != null;

      if (_worldEvent != null)
      {
        _worldEvent.StateChanged -= OnEventChanged;
        _worldEvent.Updated -= OnEventChanged;
      }

      _worldEvent = value;

      if (_worldEvent == null)
      {
        return;
      }

      _icon.Texture = _worldEvent.IconPath;
      _title.Text = Loc.Get(_worldEvent.Name);
      _worldEvent.StateChanged += OnEventChanged;
      _worldEvent.Updated += OnEventChanged;
      Refresh();
    }
  }

  public EventCard(Frame parent) : base(parent, BoxWidth, BoxHeight)
  {
    _icon = new Frame("BACKDROP", "ArtifactIcon", this)
    {
      Width = 0.04f,
      Height = 0.04f
    };
    _icon.SetPoint(framepointtype.TopLeft, this, framepointtype.TopLeft, 0.015f, -0.03f);
    AddFrame(_icon);

    _title = new TextFrame("ArtifactItemTitle", this, 0)
    {
      Width = BoxWidth - 0.04f,
      Height = 0
    };
    _title.SetPoint(framepointtype.Top, this, framepointtype.Top, 0, -0.012f);
    AddFrame(_title);

    _textFrame = new TextFrame("ArtifactItemOwnerText", this, 0);
    _textFrame.SetPoint(framepointtype.TopLeft, _icon, framepointtype.TopRight, 0.007f, 0);
    _textFrame.SetPoint(framepointtype.Right, this, framepointtype.Right, -0.012f, 0);
    _textFrame.SetPoint(framepointtype.Bottom, this, framepointtype.Bottom, 0, 0.012f);
    _textFrame.SetTextAlignment(textaligntype.Top, textaligntype.Left);
    AddFrame(_textFrame);
  }

  private void OnEventChanged(WorldEvent worldEvent) => Refresh();

  private void Refresh()
  {
    if (_worldEvent == null)
    {
      return;
    }

    var details = _worldEvent.State == WorldEventState.Happened
      ? _worldEvent.Outcome == null ? "" : $"\n{_worldEvent.Outcome}"
      : CardText.FormatRequirements(_worldEvent.Requirements);
    _textFrame.Text = $"{GetStatusText(_worldEvent)}\n{Loc.Get(_worldEvent.Description)}{details}";
  }

  private static string GetStatusText(WorldEvent worldEvent)
  {
    switch (worldEvent.State)
    {
      case WorldEventState.Upcoming:
        return $"|cffaaaaaa{Loc.Get("Upcoming")}|r";
      case WorldEventState.Imminent:
        return $"|cffff8800{Loc.Get("Imminent")}|r - {Loc.Format("happens in {time}", ("{time}", CardText.FormatTime(worldEvent.WarningTimeRemaining)))}";
      case WorldEventState.Happened:
        return worldEvent.Instigator == null
          ? $"|cffffcc00{Loc.Get("Happened")}|r - {Loc.Format("turn {turn}", ("{turn}", worldEvent.HappenedOnTurn.ToString()))}"
          : $"|cffffcc00{Loc.Get("Happened")}|r - {Loc.Format("turn {turn}, started by {who}", ("{turn}", worldEvent.HappenedOnTurn.ToString()), ("{who}", worldEvent.Instigator))}";
      default:
        return $"|cffff0000{Loc.Get("Cancelled")}|r";
    }
  }
}
