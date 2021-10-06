using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public class FelHordeSetup
  {
    public static Faction FelHorde { get; private set; }

    public static void Initialize()
    {
      FelHorde = new Faction("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000", "ReplaceableTextures\\CommandButtons\\BTNPitLord.blp", 6);
    }
  }
}