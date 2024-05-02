using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Commands
{
  /// <summary>
  /// A <see cref="CommandSystem.Command"/> that clears all messages from the player's screen.
  /// </summary>
  public sealed class Clear : Command
  {
    private readonly string _commandText;

    /// <summary>
    /// Initializes a new instance of the <see cref="Clear"/> class.
    /// </summary>
    public Clear(string commandText)
    {
      _commandText = commandText;
    }
    
    /// <inheritdoc />
    public override string CommandText => _commandText;

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(0);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Clears all text from your screen.";

    /// <inheritdoc />
    public override string Execute(player commandUser, params string[] parameters)
    {
      if (GetLocalPlayer() == commandUser)
        ClearTextMessages();
      return "Clearing messages.";
    }
  }
}