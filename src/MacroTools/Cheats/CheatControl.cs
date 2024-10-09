using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// Gives the cheater control of all players or a specific player.
  /// </summary>
  public sealed class CheatControl : Command
  {
    private readonly bool _control;
    private string _commandText;

    /// <inheritdoc />
    public override string CommandText => _commandText;

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description
    {
      get
      {
        var givesOrTakes = _control ? "grants" : "surrenders";
        return $"{givesOrTakes} control of all players or a specific player.";
      }
    }

    /// <summary>
    /// Initializes an instance of the <see cref="CheatControl"/> class.
    /// </summary>
    /// <param name="commandText">How to execute the command.</param>
    /// <param name="control">If true, the cheat gives you control. Otherwise, it takes away control.</param>
    public CheatControl(string commandText, bool control)
    {
      _commandText = commandText;
      _control = control;
    }
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var givesOrTakes = _control ? "Took" : "Surrendered";
      
      if (parameters[0] == "all")
      {
        foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        {
          cheater.SetPlayerAllianceStateFullControl(player, _control);
          player.SetPlayerAllianceStateFullControl(cheater, _control);
        }

        return $"{givesOrTakes} control of all players.";
      }

      if (!FactionManager.TryGetFactionByName(parameters[0], out var target))
        return $"There is no faction named {parameters[0]}.";
      
      if (target.Player == null)
        return $"Nobody is playing {target.ColoredName}.";

      target.Player.SetPlayerAllianceStateFullControl(cheater, _control);
      cheater.SetPlayerAllianceStateFullControl(target.Player, _control);
      return $"{givesOrTakes} control of {target.ColoredName}.";
    }
  }
}