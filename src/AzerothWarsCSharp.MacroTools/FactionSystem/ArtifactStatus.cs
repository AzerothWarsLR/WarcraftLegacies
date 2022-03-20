namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public enum ArtifactStatus
  {
    /// <summary>
    /// Artifact is on the ground.
    /// </summary>
    Ground,
    /// <summary>
    /// Artifact is held by a unit.
    /// </summary>
    Unit,
    /// <summary>
    /// Artifact is nowhere, but has a pretend-location that the player can ping.
    /// </summary>
    Special,
    /// <summary>
    /// Artifact does not allow pinging, and only displays text describing its pretend-location.
    /// </summary>
    Hidden
  }
}