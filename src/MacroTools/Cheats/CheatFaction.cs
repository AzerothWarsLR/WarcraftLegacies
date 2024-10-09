using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

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
    public override ExpectedParameterCount ExpectedParameterCount => new(1);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => " Changes your faction to the specified faction.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!FactionManager.TryGetFactionByName(parameters[0], out var f))
        return $"There is no registered {nameof(Faction)} with the name {parameters[0]}.";
      
      PlayerData.ByHandle(GetTriggerPlayer()).Faction = f;
      return $"Successfully changed faction to {f.Name}.";
    }
  }
}
