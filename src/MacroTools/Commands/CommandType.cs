namespace MacroTools.Commands;

/// <summary>
/// Describes a <see cref="Command"/>'s type.
/// </summary>
public enum CommandType
{
  /// <summary>
  /// The command can be executed by anyone during a normal game.
  /// </summary>
  Normal,

  /// <summary>
  /// The command can only be executed by developers or by players playing alone.
  /// </summary>
  Cheat
}
