using System;
using System.ComponentModel;
using MacroTools.ArtifactSystem;
using MacroTools.BookSystem.Core;
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
    private Artifact? _artifact;
    
    private readonly Button _pingButton;
    private readonly TextFrame _text;
    private readonly Frame _icon;
    private readonly TextFrame _title;

    /// <inheritdoc />
    public override bool Occupied => _artifact != null;
    
    /// <summary>
    /// The <see cref="Artifact"/> currently being represented by this <see cref="ArtifactCard"/>.
    /// </summary>
    public Artifact? Artifact
    {
      get => _artifact;
      set
      {
        Visible = value != null;

        if (_artifact != null)
        {
          _artifact.OwnerChanged -= OnArtifactOwnerChanged;
          _artifact.StatusChanged -= OnArtifactStatusChanged;
          _artifact.FactionChanged -= OnArtifactOwnerChanged;
        }
        
        _artifact = value;

        if (_artifact == null)
          return;
        
        _icon.Texture = BlzGetItemIconPath(_artifact.Item);
        _title.Text = GetItemName(_artifact.Item);
        _pingButton.OnClick = _artifact.Ping;
        _artifact.OwnerChanged += OnArtifactOwnerChanged;
        _artifact.StatusChanged += OnArtifactStatusChanged;
        _artifact.FactionChanged += OnArtifactOwnerChanged;
        RefreshLocationDescriptionFrame();
      }
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ArtifactCard"/> class.
    /// </summary>
    /// <param name="parent"><inheritdoc /></param>
    public ArtifactCard(Frame parent) : base(parent, BoxWidth, BoxHeight)
    {
      _icon = new Frame("BACKDROP", "ArtifactIcon", this)
      {
        Width = 0.04f,
        Height = 0.04f,
        Texture = ""
      };
      _icon.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.015f, -0.0090f);
      AddFrame(_icon);

      _title = new TextFrame("ArtifactItemTitle", this, 0)
      {
        Text = "",
        Width = BoxWidth - 0.04f,
        Height = 0
      };
      _title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0.0255f);
      AddFrame(_title);

      _text = new TextFrame("ArtifactItemOwnerText", this, 0);
      _text.SetPoint(FRAMEPOINT_TOPLEFT, _icon, FRAMEPOINT_TOPRIGHT, 0.007f, 0);
      _text.SetPoint(FRAMEPOINT_BOTTOMLEFT, _icon, FRAMEPOINT_BOTTOMRIGHT, 0.007f, 0);
      _text.SetPoint(FRAMEPOINT_RIGHT, this, FRAMEPOINT_RIGHT, -0.007f, 0);
      AddFrame(_text);

      _pingButton = new Button("ScriptDialogButton", this, 0)
      {
        Width = 0.062f,
        Height = 0.027f,
        Text = "Ping",
        Visible = false
      };
      _pingButton.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.057f, -0.009f);
      AddFrame(_pingButton);
      
      FactionManager.AnyFactionNameChanged += OnAnyFactionNameChanged;
    }

    /// <summary>
    /// Updates the description to reflect current <see cref="Artifact.LocationType"/> settings.
    /// </summary>
    private void RefreshLocationDescriptionFrame()
    {
      switch (_artifact!.LocationType)
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
        if (e == _artifact?.OwningPlayer?.GetFaction())
          RefreshLocationDescriptionFrame();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }
  }
}