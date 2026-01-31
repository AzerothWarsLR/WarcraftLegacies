using System;
using System.ComponentModel;
using MacroTools.Artifacts;
using MacroTools.BookSystem.Core;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Frames;

namespace MacroTools.BookSystem.ArtifactSystem;

/// <summary>
///   Represents a single Artifact in a black rectangle.
/// </summary>
public sealed class ArtifactCard : Card<Artifact>
{
  private const float BoxWidth = 0.13f;
  private const float BoxHeight = 0.086f;
  private Artifact? _artifact;

  private readonly Button _pingButton;
  private readonly TextFrame _text;
  private readonly Frame _icon;
  private readonly TextFrame _title;

  /// <inheritdoc />
  public override bool Occupied => Item != null;

  /// <inheritdoc />
  public override void Clear() => Item = null;

  /// <summary>
  /// The <see cref="Item"/> currently being represented by this <see cref="ArtifactCard"/>.
  /// </summary>
  public override Artifact? Item
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
      {
        return;
      }

      _icon.Texture = _artifact.Item.Icon;
      _title.Text = _artifact.Item.Name;
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
    _icon.SetPoint(framepointtype.Left, this, framepointtype.Left, 0.015f, -0.0090f);
    AddFrame(_icon);

    _title = new TextFrame("ArtifactItemTitle", this, 0)
    {
      Text = "",
      Width = BoxWidth - 0.04f,
      Height = 0
    };
    _title.SetPoint(framepointtype.Center, this, framepointtype.Center, 0, 0.0255f);
    AddFrame(_title);

    _text = new TextFrame("ArtifactItemOwnerText", this, 0);
    _text.SetPoint(framepointtype.TopLeft, _icon, framepointtype.TopRight, 0.007f, 0);
    _text.SetPoint(framepointtype.BottomLeft, _icon, framepointtype.BottomRight, 0.007f, 0);
    _text.SetPoint(framepointtype.Right, this, framepointtype.Right, -0.007f, 0);
    AddFrame(_text);

    _pingButton = new Button("ScriptDialogButton", this, 0)
    {
      Width = 0.062f,
      Height = 0.027f,
      Text = "Ping",
      Visible = false
    };
    _pingButton.SetPoint(framepointtype.Left, this, framepointtype.Left, 0.057f, -0.009f);
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
        var owningFaction = _artifact.OwningPlayer?.GetPlayerData().Faction;
        if (owningFaction != null)
        {
          _text.Visible = true;
          _pingButton.Visible = false;
          _text.Text = $"Owned by {owningFaction.ColoredName}";
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
      if (e == _artifact?.OwningPlayer?.GetPlayerData().Faction)
      {
        RefreshLocationDescriptionFrame();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }
}
