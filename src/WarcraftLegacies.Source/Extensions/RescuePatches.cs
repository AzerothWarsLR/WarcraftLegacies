using System.Collections.Generic;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Extensions;

public static class RescuePatches
{
  public static void RescueGroupWithUnburrow(this player whichPlayer, List<unit> units)
  {
    whichPlayer.RescueGroup(units);

    foreach (var u in units)
    {
      if (u.UnitType == UNIT_UCRM_BURROWED_CRYPT_FIEND_SCOURGE)
      {
        u.IssueOrder(ORDER_UNBURROW);
      }
    }
  }
}
