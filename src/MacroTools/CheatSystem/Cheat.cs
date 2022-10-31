using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.CheatSystem
{
  /// <summary>
  /// A function that a player can execute via the chat, which is only enabled in testing scenarios.
  /// </summary>
  public abstract class Cheat
  {
    /// <summary>
    /// The command that a player can execute to run the <see cref="Cheat"/>.
    /// </summary>
    public abstract string Command { get; }
    
    /// <summary>
    /// How many parameters should be supplied to this <see cref="Cheat"/> command.
    /// </summary>
    public abstract int ParameterCount { get; }

    /// <summary>
    /// What happens when the <see cref="Cheat"/> gets executed by a player.
    /// </summary>
    /// <param name="cheater">The player typing the <see cref="Cheat"/> command in.</param>
    /// <param name="parameters">The parameters specified by the player entering the sheet, seperated by spaces.</param>
    /// <returns>A message describing what the <see cref="Cheat"/> is doing to the executing player.</returns>
    public abstract string Execute(player cheater, params string[] parameters);
  }
}