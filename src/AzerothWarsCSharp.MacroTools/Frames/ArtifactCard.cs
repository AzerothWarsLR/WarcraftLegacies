using System;
using static War3Api.Common;
using System.ComponentModel;

namespace AzerothWarsCSharp.MacroTools.Frames
{
  public sealed class ArtifactCard : Frame
  {
    private const float BoxWidth = 0.13f;
    private const float BoxHeight = 0.086f;

    private ArtifactMenuPage _parentPage;
    private readonly Frame _icon;
    private readonly TextFrame _title;
    private readonly TextFrame _text;
    private readonly Frame _pingButton;

    private void OnArtifactOwnerChanged(object? sender, ArtifactEventArgs args)
    {
      var artifactOwningFaction = args.Artifact.OwningFaction;
      if (artifactOwningFaction != null)
      {
        _text.Text = $"{artifactOwningFaction.ColoredName}";
      }
    }

    private void OnArtifactStatusChanged(object? sender, ArtifactEventArgs args)
    {
      switch (args.Artifact.Status)
      {
        case ArtifactStatus.Unit:
          _text.Visible = true;
          _pingButton.Visible = false;
          break;
        case ArtifactStatus.Ground:
          _text.Visible = false;
          _pingButton.Visible = true;
          break;
        case ArtifactStatus.Special:
          _text.Visible = false;
          _pingButton.Visible = true;
          break;
        case ArtifactStatus.Hidden:
          _text.Visible = true;
          _pingButton.Visible = false;
          break;
        default:
          throw new InvalidEnumArgumentException();
      }
    }
    
    public ArtifactCard(Artifact artifact, ArtifactMenuPage parentPage) : base("ArtifactItemBox", parentPage, 0, 0)
    {
      _parentPage = parentPage;

      Width = BoxWidth;
      Height = BoxHeight;

      _icon = new Frame("BACKDROP", "ArtifactIcon", this)
      {
        Width = 0.04f,
        Height = 0.04f,
        Texture = artifact.IconPath
      };
      _icon.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.015f, -0.0090f);
      AddFrame(_icon);
      
      _title = new TextFrame("ArtifactItemTitle", this, 0, 0)
      {
        Text = artifact.Name,
        Width = BoxWidth - 0.04f,
        Height = 0
      };
      _title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0.0255f);
      AddFrame(_title);
      
      _text = new TextFrame("ArtifactItemOwnerText", this, 0, 0);
      _text.SetPoint(FRAMEPOINT_TOPLEFT, _icon, FRAMEPOINT_TOPRIGHT, 0.007f, 0);
      _text.SetPoint(FRAMEPOINT_BOTTOMLEFT, _icon, FRAMEPOINT_BOTTOMRIGHT, 0.007f, 0);
      _text.SetPoint(FRAMEPOINT_RIGHT, this, FRAMEPOINT_RIGHT, -0.007f, 0);
      AddFrame(_text);
      
      _pingButton = new Button("ScriptDialogButton", this, 0, 0)
      {
        Width = 0.062f,
        Height = 0.027f,
        Text = "Ping",
        Visible = false,
        OnClick = () => artifact.Ping(GetTriggerPlayer())
      };
      _pingButton.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.057f, -0.009f);
      AddFrame(_pingButton);
      
      artifact.OwnerChanged += OnArtifactOwnerChanged;
      artifact.StatusChanged += OnArtifactStatusChanged;
    }
  }
}