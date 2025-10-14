using System.Collections.Generic;
using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.Commands;

/// <summary>
/// A <see cref="CommandSystem.Command"/> that pings all of the player's limited units.
/// </summary>
public sealed class Limited : Command
{
  /// <inheritdoc />
  public override string CommandText => "limited";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Normal;

  /// <inheritdoc />
  public override string Description => "Pings all limited units you control.";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var pingedPositions = new HashSet<Point>();

    var limitedUnits = GlobalGroup
      .EnumUnitsOfPlayer(commandUser)
      .Where(u => commandUser.GetPlayerData().GetObjectLimit(u.UnitType) is > 0 and < Faction.Unlimited && u.Alive);

    foreach (var unit in limitedUnits)
    {
      //Warcraft 3 has a hard-coded on-screen ping limit of 16. We avoid hitting this limit by only pinging a limited
      //unit if it is far enough away from any other unit that has already been pinged.
      var unitPosition = unit.GetPosition();
      if (PositionIsNearPositions(unitPosition, pingedPositions))
      {
        continue;
      }

      pingedPositions.Add(unitPosition);
      commandUser.PingLocation(unitPosition, 5f);
    }

    return "Pinging all limited units you control.";
  }

  private static bool PositionIsNearPositions(Point positionA, HashSet<Point> pingedPositions)
  {
    const float distanceLimit = 500f;
    foreach (var positionB in pingedPositions)
    {
      if (MathEx.GetDistanceBetweenPoints(positionA, positionB) < distanceLimit)
      {
        return true;
      }
    }

    return false;
  }
}
