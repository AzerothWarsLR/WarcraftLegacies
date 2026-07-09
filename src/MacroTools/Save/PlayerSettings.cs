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
  /// The player's preferred language for translated game text, as an IETF-style tag (eg. "en", "es", "zh").
  /// Null means it has not been detected or set yet, and callers should fall back to English.
  /// </summary>
  public string? Language { get; internal set; }

  public bool LanguageIsManual { get; internal set; }
}
