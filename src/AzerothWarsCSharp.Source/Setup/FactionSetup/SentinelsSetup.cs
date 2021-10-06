using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public class SentinelsSetup
  {
    public static Faction Sentinels { get; private set; }

    public static void Initialize()
    {
      Sentinels = new Faction("Sentinels", PLAYER_COLOR_MINT, "|CFFBFFF80", "ReplaceableTextures\\CommandButtons\\BTNPriestessOfTheMoon.blp", 3);
    }
  }
}