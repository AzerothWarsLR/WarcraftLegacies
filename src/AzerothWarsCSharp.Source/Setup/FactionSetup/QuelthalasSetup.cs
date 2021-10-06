using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public class QuelthalasSetup
  {
    public static Faction Quelthalas { get; private set; }

    public static void Initialize()
    {
      Quelthalas = new Faction("Quel'thalas", PLAYER_COLOR_CYAN, "|C0000FFFF", "ReplaceableTextures\\CommandButtons\\BTNSylvanusWindrunner.blp", 2);
    }
  }
}