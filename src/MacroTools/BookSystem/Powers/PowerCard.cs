using MacroTools.FactionSystem;
using MacroTools.Frames;
using static War3Api.Common;

namespace MacroTools.BookSystem.Powers
{
  public sealed class PowerCard : Card
  {
    private const float BoxWidth = 0.32f;
    private const float BoxHeight = 0.092f;
    private readonly Power _power;
    private readonly TextFrame _textFrame;
    private readonly Button _actionButton;
    public PowerCard(Power power, Frame parent) : base(parent, BoxWidth, BoxHeight)
    {
      _power = power;
      var icon = new Frame("BACKDROP", "ArtifactIcon", this)
      {
        Width = 0.04f,
        Height = 0.04f,
        Texture = power.IconPath
      };
      icon.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.015f, -0.0090f);
      AddFrame(icon);

      var title = new TextFrame("ArtifactItemTitle", this, 0)
      {
        Text = power.Name,
        Width = BoxWidth - 0.04f,
        Height = 0
      };
      title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0.0255f);
      AddFrame(title);

      _textFrame = new TextFrame("ArtifactItemOwnerText", this, 0)
      {
        Text = power.Description
      };
      _textFrame.SetPoint(FRAMEPOINT_TOPLEFT, icon, FRAMEPOINT_TOPRIGHT, 0.007f, 0);
      _textFrame.SetPoint(FRAMEPOINT_BOTTOMLEFT, icon, FRAMEPOINT_BOTTOMRIGHT, 0.007f, 0);
      _textFrame.SetPoint(FRAMEPOINT_RIGHT, this, FRAMEPOINT_RIGHT, -0.007f, 0);
      AddFrame(_textFrame);

      _actionButton = new Button("ScriptDialogButton", this, 0)
      {
        Width = 0.062f,
        Height = 0.027f,
        Text = "Use",
        Visible = power.Usable,
        OnClick = power.OnUse
      };
      _actionButton.SetPoint(FRAMEPOINT_BOTTOMRIGHT, this, FRAMEPOINT_BOTTOMRIGHT, -0.01f, 0.002f);
      AddFrame(_actionButton);

      power.DescriptionChanged += OnPowerDescriptionChanged;
    }

    private void OnPowerDescriptionChanged(object? sender, Power power)
    {
      _textFrame.Text = power.Description;
    }

    protected override void DisposeEvents()
    {
      _power.DescriptionChanged -= OnPowerDescriptionChanged;
    }
  }
}
