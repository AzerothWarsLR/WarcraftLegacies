namespace AzerothWarsCSharp.MacroTools
{
  public enum ArtifactStatus
  {
    /// <summary>
    /// The Artifact is carried by a unit.
    /// </summary>
    Unit,
    /// <summary>
    /// The Artifact is on the ground.
    /// </summary>
    Ground,
    /// <summary>
    /// The Artifact is nowhere, but it is pretending to be somewhere.
    /// </summary>
    Special,
    /// <summary>
    /// The Artifact is hidden.
    /// </summary>
    Hidden
  }
}