using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Commands
{
  /// <summary>
  /// A <see cref="CommandSystem.Command"/> that pings all of the player's limited units.
  /// </summary>
  public sealed class Limited : Command
  {
    /// <inheritdoc />
    public override string CommandText => "limited";
    
    /// <inheritdoc />
    public override bool Exact => true;
  
    /// <inheritdoc />
    public override int MinimumParameterCount => 0;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Pings all limited units you control.";

    /// <inheritdoc />
    public override string Execute(player commandUser, params string[] parameters)
    {
      var limitedUnits = CreateGroup().EnumUnitsOfPlayer(commandUser).EmptyToList().Where(
        u => commandUser.GetObjectLimit(u.GetTypeId()) is > 0 and < Faction.UNLIMITED && u.IsAlive() == true);
      foreach (var unit in limitedUnits) 
        commandUser.PingLocation(unit.GetPosition(), 5f);

      return "Pinging all limited units you control.";
    }
  }
}