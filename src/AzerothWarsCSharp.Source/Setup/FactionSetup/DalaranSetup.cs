using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public class DalaranSetup
  {
    public static Faction Dalaran { get; private set; }

    public static void Initialize()
    {
      Dalaran = new Faction("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0", "ReplaceableTextures\\CommandButtons\\BTNJaina.blp", 2);
    }
  }
}