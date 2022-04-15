using System;
using System.ComponentModel;
using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames.Books.ArtifactSystem
{
  /// <summary>
  /// Represents a single Artifact in a black rectangle.
  /// </summary>
  public sealed class ArtifactCard : Card
  {
    private const float BOX_WIDTH = 0.13f;
    private const float BOX_HEIGHT = 0.086f;

    private readonly TextFrame _text;
    private readonly Frame _pingButton;
    private readonly Artifact _artifact;

    private void OnArtifactOwnerChanged(object? sender, Artifact artifact)
    {
      try
      {
        _text.Text = $"{artifact.OwningPlayer?.GetFaction()?.ColoredName}";
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void OnArtifactStatusChanged(object? sender, Artifact artifact)
    {
      switch (artifact.Status)
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

    public ArtifactCard(Artifact artifact, Frame parent) : base(parent, BOX_WIDTH, BOX_HEIGHT)
    {
      _artifact = artifact;

      var icon = new Frame("BACKDROP", "ArtifactIcon", this)
      {
        Width = 0.04f,
        Height = 0.04f,
        Texture = BlzGetItemIconPath(artifact.Item)
      };
      icon.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.015f, -0.0090f);
      AddFrame(icon);

      var title = new TextFrame("ArtifactItemTitle", this, 0, 0)
      {
        Text = GetItemName(artifact.Item),
        Width = BOX_WIDTH - 0.04f,
        Height = 0
      };
      title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0.0255f);
      AddFrame(title);

      _text = new TextFrame("ArtifactItemOwnerText", this, 0, 0);
      _text.SetPoint(FRAMEPOINT_TOPLEFT, icon, FRAMEPOINT_TOPRIGHT, 0.007f, 0);
      _text.SetPoint(FRAMEPOINT_BOTTOMLEFT, icon, FRAMEPOINT_BOTTOMRIGHT, 0.007f, 0);
      _text.SetPoint(FRAMEPOINT_RIGHT, this, FRAMEPOINT_RIGHT, -0.007f, 0);
      AddFrame(_text);

      _pingButton = new Button("ScriptDialogButton", this, 0, 0)
      {
        Width = 0.062f,
        Height = 0.027f,
        Text = "Ping",
        Visible = false,
        OnClick = artifact.Ping
      };
      _pingButton.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.057f, -0.009f);
      AddFrame(_pingButton);

      artifact.OwnerChanged += OnArtifactOwnerChanged;
      artifact.StatusChanged += OnArtifactStatusChanged;
      artifact.FactionChanged += OnArtifactOwnerChanged;
    }

    protected override void DisposeEvents()
    {
      _artifact.OwnerChanged -= OnArtifactOwnerChanged;
      _artifact.StatusChanged -= OnArtifactStatusChanged;
      _artifact.FactionChanged -= OnArtifactOwnerChanged;
    }
  }
}