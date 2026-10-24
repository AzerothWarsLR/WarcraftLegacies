namespace MacroTools.GameModes;

/// <summary>How a game mode handles alliances between players.</summary>
public enum DiplomacyRule
{
  /// <summary>Players vote on whether diplomacy is open or closed.</summary>
  Vote,

  /// <summary>Diplomacy is always open.</summary>
  Open,

  /// <summary>Players can't change alliances themselves; only the game mode changes them.</summary>
  Locked
}
