using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;


namespace MacroTools.Cheats
{
  /// <summary>
  /// Changes the cheater's <see cref="Faction"/> to a specified <see cref="Faction"/>
  /// </summary>
  public sealed class CheatFaction : Command
  {

    /// <inheritdoc />
    public override string CommandText => "faction";
    
    /// <inheritdoc />
    public override bool Exact => false;

    /// <inheritdoc />
    public override int MinimumParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => " Changes your faction to the specified faction.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!FactionManager.FactionWithNameExists(parameters[0]))
        return $"There is no registered {nameof(Faction)} with the name {parameters[0]}.";

      var f = FactionManager.GetFactionByName(parameters[0]);
      if (f != null)
      {
        PlayerData.ByHandle(GetTriggerPlayer()).Faction = f;
        return $"Successfully changed faction to {f.Name}.";
      }
      return $"Failed changing faction to {parameters[0]}";
    }
  }
}
