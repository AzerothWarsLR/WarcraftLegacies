using System;
using MacroTools.CommandSystem;
using MacroTools.FactionSystem;


namespace MacroTools.Cheats
{
  /// <summary>
  /// Kicks the specified player out of the game.
  /// </summary>
  public sealed class CheatKick : Command
  {

    /// <inheritdoc />
    public override string CommandText => "kick";
    
    /// <inheritdoc />
    public override bool Exact => false;

    /// <inheritdoc />
    public override int MinimumParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Kicks the specified player out of the game.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      try
      {
        var faction = FactionManager.GetFactionByName(parameters[0]);
        if (faction == null)
          return $"There is no registered {nameof(Faction)} with the name {parameters[0]}.";
        
        faction.Defeat();
        return $"Kicking {nameof(Faction)} {faction.Name}.";
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
  }
}