using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public class DalaranSetup
  {
    public static Faction Dalaran { get; private set; }

    public static void Initialize()
    {
      Dalaran = new Faction("Scourge", PLAYER_COLOR_PURPLE, "|c00540081", "ReplaceableTextures\\CommandButtons\\BTNRevenant.blp", 3);
    }
  }
}