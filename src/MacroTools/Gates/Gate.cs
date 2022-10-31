namespace WarcraftLegacies.MacroTools.Gates
{
  /// <summary>
  /// Gates are buildings that can open and close.
  /// </summary>
  public sealed class Gate
  {
    public int OpenedId { get; }
    public int ClosedId { get; }
    public int DeadId { get; }
    
    /// <summary>
    /// Constructs a new <see cref="Gate"/>.
    /// </summary>
    /// <param name="openedId">The unit type ID of the gate while open.</param>
    /// <param name="closedId">The unit type ID of the gate while closed.</param>
    /// <param name="deadId">The unit type ID of the gate while dead.</param>
    public Gate(int openedId, int closedId, int deadId)
    {
      OpenedId = openedId;
      ClosedId = closedId;
      DeadId = deadId;
    }
  }
}