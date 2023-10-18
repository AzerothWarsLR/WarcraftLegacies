using System;
using System.ComponentModel;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Frames;
using static War3Api.Common;

namespace MacroTools.BookSystem.ArtifactSystem
{
  /// <summary>
  ///   Represents a single Artifact in a black rectangle.
  /// </summary>
  public sealed class ArtifactCard : Card
  {
    private const float BoxWidth = 0.13f;
    private const float BoxHeight = 0.086f;
    private readonly Artifact _artifact;
    private readonly Frame _pingButton;

    private readonly TextFrame _text;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArtifactCard"/> class.
    /// </summary>
    /// <param name="artifact">The <see cref="Artifact"/> being represented.</param>
    /// <param name="parent"><inheritdoc /></param>
    public ArtifactCard(Artifact artifact, Frame parent) : base(parent, BoxWidth, BoxHeight)
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

      var title = new TextFrame("ArtifactItemTitle", this, 0)
      {
        Text = GetItemName(artifact.Item),
        Width = BoxWidth - 0.04f,
        Height = 0
      };
      title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0.0255f);
      AddFrame(title);

      _text = new TextFrame("ArtifactItemOwnerText", this, 0);
      _text.SetPoint(FRAMEPOINT_TOPLEFT, icon, FRAMEPOINT_TOPRIGHT, 0.007f, 0);
      _text.SetPoint(FRAMEPOINT_BOTTOMLEFT, icon, FRAMEPOINT_BOTTOMRIGHT, 0.007f, 0);
      _text.SetPoint(FRAMEPOINT_RIGHT, this, FRAMEPOINT_RIGHT, -0.007f, 0);
      AddFrame(_text);

      _pingButton = new Button("ScriptDialogButton", this, 0)
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
      FactionManager.AnyFactionNameChanged += OnAnyFactionNameChanged;
      
      RefreshLocationDescriptionFrame();
    }

    /// <summary>
    /// Updates the description to reflect current <see cref="Artifact.LocationType"/> settings.
    /// </summary>
    private void RefreshLocationDescriptionFrame()
    {
      switch (_artifact.LocationType)
      {
        case ArtifactLocationType.Unit:
          if (_artifact.OwningPlayer?.GetFaction() != null)
          {
            _text.Visible = true;
            _pingButton.Visible = false;
            _text.Text = $"Owned by {_artifact.OwningPlayer?.GetFaction()?.ColoredName}";
          }
          else
          {
            _text.Visible = false;
            _pingButton.Visible = true;
          }
          break;
        case ArtifactLocationType.Ground:
          _text.Visible = false;
          _pingButton.Visible = true;
          break;
        default:
          throw new InvalidEnumArgumentException();
      }
    }
    
    private void OnArtifactOwnerChanged(object? sender, Artifact artifact)
    {
      try
      {
        RefreshLocationDescriptionFrame();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void OnArtifactStatusChanged(object? sender, Artifact artifact)
    {
      try
      {
        RefreshLocationDescriptionFrame();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void OnAnyFactionNameChanged(object? sender, Faction e)
    {
      try
      {
        if (e == _artifact.OwningPlayer?.GetFaction())
          RefreshLocationDescriptionFrame();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    /// <inheritdoc />
    protected override void DisposeEvents()
    {
      _artifact.OwnerChanged -= OnArtifactOwnerChanged;
      _artifact.StatusChanged -= OnArtifactStatusChanged;
      _artifact.FactionChanged -= OnArtifactOwnerChanged;
    }
  }
}