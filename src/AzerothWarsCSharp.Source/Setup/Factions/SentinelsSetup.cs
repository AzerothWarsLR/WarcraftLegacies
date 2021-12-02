using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class SentinelsSetup
  {
    public static Faction Sentinels { get; private set; }

    public static void Initialize()
    {
      Sentinels = new Faction("Sentinels", PLAYER_COLOR_MINT, "|CFFBFFF80", "PriestessOfTheMoon");
      FactionSystem.Add(Sentinels);
    }
  }
}