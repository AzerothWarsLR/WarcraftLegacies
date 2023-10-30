namespace WarcraftLegacies.Source.Spells.Slipstream
{
  /// <summary>
  /// The state a <see cref="SlipstreamPortalBuff"/> is in.
  /// </summary>
  public enum SlipstreamPortalState
  {
    /// <summary>
    /// The portal has not been opened yet, and cannot be used.
    /// </summary>
    Unopened,
    
    /// <summary>
    /// The portal is not yet open and cannot be used.
    /// </summary>
    Opening,
    
    /// <summary>
    /// The portal is open and can be used.
    /// </summary>
    Stable,
    
    /// <summary>
    /// The portal is in the process of closing. It can be used but will be removed soon.
    /// </summary>
    Closing,
    
    /// <summary>
    /// The portal fully closed and cannot be used.
    /// </summary>
    Closed
  }
}