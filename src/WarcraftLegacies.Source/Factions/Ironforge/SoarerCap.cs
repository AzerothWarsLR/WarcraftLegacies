using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>Stops a player mounting more Soarers once they have the most allowed, since mounting skips unit limits.</summary>
public static class SoarerCap
{
  private const float CheckInterval = 0.25f;

  /// <summary>Starts limiting <paramref name="whichPlayer"/>'s Soarers to <paramref name="limit"/>.</summary>
  public static void Start(player whichPlayer, int limit)
  {
    var check = timer.Create();
    check.Start(CheckInterval, true, () =>
    {
      var soarers = 0;
      foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
      {
        if (whichUnit.Alive && whichUnit.UnitType == UNIT_H0F7_SOARER_WILDHAMMER)
        {
          soarers++;
        }
      }

      var canMount = soarers < limit;
      SetPlayerAbilityAvailable(whichPlayer, ABILITY_A1AU_MOUNT_GRYPHON_WILDHAMMER, canMount);
      SetPlayerAbilityAvailable(whichPlayer, ABILITY_A1AV_PICK_UP_CLANSMAN_WILDHAMMER, canMount);
    });
  }
}
