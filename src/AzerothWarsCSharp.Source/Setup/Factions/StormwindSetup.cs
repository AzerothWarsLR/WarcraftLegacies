using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class StormwindSetup
  {
    public static Faction Stormwind { get; private set; }

    public static void Initialize()
    {
      Stormwind = new Faction("Stormwind", PLAYER_COLOR_AQUA, "|CFF106246", "Knight");
      FactionSystem.Add(Stormwind);
    }
  }
}