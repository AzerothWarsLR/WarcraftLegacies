using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Commands
{
  /// <summary>
  /// A <see cref="CommandSystem.Command"/> that clears all messages from the player's screen.
  /// </summary>
  public sealed class Clear : Command
  {
    /// <inheritdoc />
    public override string CommandText => "clear";
  
    /// <inheritdoc />
    public override int ParameterCount => 0;

    /// <inheritdoc />
    public override string Execute(player commandUser, params string[] parameters)
    {
      if (GetLocalPlayer() == commandUser)
        ClearTextMessages();
      return "Clearing messages.";
    }
  }
}