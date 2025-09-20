namespace MacroTools.DummyCasters;

public enum DummyCasterType
{
  /// <summary>A globally shared dummy that casts any instant spell in the game.</summary>
  Global,

  /// <summary>A dummy that only ever casts one specific spell.</summary>
  AbilitySpecific,

  /// <summary>Casts channeled spells.</summary>
  LongLived
}
