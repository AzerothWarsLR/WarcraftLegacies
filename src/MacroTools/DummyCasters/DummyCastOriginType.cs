namespace MacroTools.DummyCasters
{
  /// <summary>
  /// Indicates where the dummy unit should be moved to before it casts its spell.
  /// </summary>
  public enum DummyCastOriginType
  {
    /// <summary>
    /// The dummy unit should be spawned at the caster.
    /// </summary>
    Caster,
    
    /// <summary>
    /// The dummy unit should be spawned at the target.
    /// </summary>
    Target
  }
}