using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class FelHordeSetup
  {
    public static Faction FelHorde { get; private set; }

    public static void Initialize()
    {
      FelHorde = new Faction("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000", "PitLord");
      FactionSystem.Add(FelHorde);
    }
  }
}