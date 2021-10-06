using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public class LordaeronSetup
  {
    public static Faction Lordaeron { get; private set; }

    public static void Initialize()
    {
      Lordaeron = new Faction("Lordaeron", PLAYER_COLOR_BLUE, "|c000042ff", "ReplaceableTextures\\CommandButtons\\BTNArthas.blp", 2);
    }
  }
}