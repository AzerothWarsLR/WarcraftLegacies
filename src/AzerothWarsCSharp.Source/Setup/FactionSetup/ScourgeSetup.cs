using AzerothWarsCSharp.Source.Libraries;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public class ScourgeSetup
  {
    public static Faction Scourge { get; private set; }

    public static void Initialize()
    {
      Scourge = new Faction(
        name: "Scourge",
        playercolor: PLAYER_COLOR_PURPLE,
        prefixColor: "|c00540081",
        icon: "ReplaceableTextures\\CommandButtons\\BTNRevenant.blp",
        weight: 3,
        objectLimits: new Dictionary<int, int>()
        {
          { FourCC("unpl"), Faction.UNLIMITED},
          { FourCC("unp1"), Faction.UNLIMITED},
          { FourCC("unp2"), Faction.UNLIMITED},
          { FourCC("uzig"), Faction.UNLIMITED},
          { FourCC("uzg1"), Faction.UNLIMITED},
          { FourCC("uzg2"), Faction.UNLIMITED},
          { FourCC("uaod"), Faction.UNLIMITED},
          { FourCC("usep"), Faction.UNLIMITED},
          { FourCC("ugrv"), Faction.UNLIMITED},
          { FourCC("uslh"), Faction.UNLIMITED},
          { FourCC("utod"), Faction.UNLIMITED},
          { FourCC("ubon"), Faction.UNLIMITED},
          { FourCC("utom"), Faction.UNLIMITED},
          { FourCC("ushp"), Faction.UNLIMITED},
          { FourCC("u002"), Faction.UNLIMITED},
          { FourCC("u003"), Faction.UNLIMITED}
        });
    }
  }
}