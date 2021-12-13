using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames.Books.Powers
{
  public class PowerCard : Card
  {
    private const float BoxWidth = 0.23f;
    private const float BoxHeight = 0.092f;
    
    public PowerCard(Power power, Frame parent) : base(parent, BoxWidth, BoxHeight)
    {
      var icon = new Frame("BACKDROP", "ArtifactIcon", this)
      {
        Width = 0.04f,
        Height = 0.04f,
        Texture = power.IconPath
      };
      icon.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.015f, -0.0090f);
      AddFrame(icon);
      
      var title = new TextFrame("ArtifactItemTitle", this, 0, 0)
      {
        Text = power.Name,
        Width = BoxWidth - 0.04f,
        Height = 0
      };
      title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0.0255f);
      AddFrame(title);

      var textFrame = new TextFrame("ArtifactItemOwnerText", this, 0, 0)
      {
        Text = power.Description
      };
      textFrame.SetPoint(FRAMEPOINT_TOPLEFT, icon, FRAMEPOINT_TOPRIGHT, 0.007f, 0);
      textFrame.SetPoint(FRAMEPOINT_BOTTOMLEFT, icon, FRAMEPOINT_BOTTOMRIGHT, 0.007f, 0);
      textFrame.SetPoint(FRAMEPOINT_RIGHT, this, FRAMEPOINT_RIGHT, -0.007f, 0);
      AddFrame(textFrame);
    }
  }
}