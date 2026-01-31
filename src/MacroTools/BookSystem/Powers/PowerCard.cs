using MacroTools.BookSystem.Core;
using MacroTools.Factions;
using MacroTools.Frames;

namespace MacroTools.BookSystem.Powers;

public sealed class PowerCard : Card<Power>
{
  private const float BoxWidth = 0.32f;
  private const float BoxHeight = 0.092f;
  private Power? _power;
  private readonly TextFrame _textFrame;
  private readonly TextFrame _title;
  private readonly Frame _icon;

  /// <inheritdoc />
  public override bool Occupied => Item != null;

  /// <inheritdoc />
  public override void Clear() => Item = null;

  /// <summary>
  /// The <see cref="Item"/> currently being represented by this <see cref="PowerCard"/>.
  /// </summary>
  public override Power? Item
  {
    get => _power;
    set
    {
      Visible = value != null;

      if (_power != null)
      {
        _power.DescriptionChanged -= OnPowerDescriptionChanged;
      }

      _power = value;

      if (_power == null)
      {
        return;
      }

      _icon.Texture = _power.IconPath;
      _title.Text = _power.Name;
      _textFrame.Text = _power.Description;
      _power.DescriptionChanged += OnPowerDescriptionChanged;
    }
  }

  public PowerCard(Frame parent) : base(parent, BoxWidth, BoxHeight)
  {
    _icon = new Frame("BACKDROP", "ArtifactIcon", this)
    {
      Width = 0.04f,
      Height = 0.04f
    };
    _icon.SetPoint(framepointtype.Left, this, framepointtype.Left, 0.015f, -0.0090f);
    AddFrame(_icon);

    _title = new TextFrame("ArtifactItemTitle", this, 0)
    {
      Width = BoxWidth - 0.04f,
      Height = 0
    };
    _title.SetPoint(framepointtype.Center, this, framepointtype.Center, 0, 0.0255f);
    AddFrame(_title);

    _textFrame = new TextFrame("ArtifactItemOwnerText", this, 0);
    _textFrame.SetPoint(framepointtype.TopLeft, _icon, framepointtype.TopRight, 0.007f, 0);
    _textFrame.SetPoint(framepointtype.BottomLeft, _icon, framepointtype.BottomRight, 0.007f, 0);
    _textFrame.SetPoint(framepointtype.Right, this, framepointtype.Right, -0.007f, 0);
    AddFrame(_textFrame);
  }

  private void OnPowerDescriptionChanged(object? sender, Power power)
  {
    _textFrame.Text = power.Description;
  }
}
