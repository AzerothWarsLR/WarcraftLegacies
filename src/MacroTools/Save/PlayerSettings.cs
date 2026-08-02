using System;
using WCSharp.SaveLoad;

namespace MacroTools.Save;

public sealed class PlayerSettings : Saveable
{
  private int? _camDistance;

  public int CamDistance
  {
    get => _camDistance ?? 2400;
    set => _camDistance = Math.Clamp(value, 700, 2701);
  }

  public bool ShowQuestText { get; internal set; } = true;

  public bool PlayDialogue { get; internal set; } = true;

  public bool ShowCaptions { get; internal set; } = true;

  /// <summary>
  /// Whether friendly units use stable destinations when following one of the player's heroes.
  /// Disabled by default until the feature has been validated in large multiplayer games.
  /// </summary>
  public bool SmartFollowEnabled { get; internal set; }

  /// <summary>
  /// The player's preferred language for translated game text, as an IETF-style tag (eg. "en", "es", "zh").
  /// Null means it has not been detected or set yet, and callers should fall back to English.
  /// </summary>
  public string? Language { get; internal set; }

  public bool LanguageIsManual { get; internal set; }
}
