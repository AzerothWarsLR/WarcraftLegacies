using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class WarsongSetup
  {
    public static Faction Warsong { get; private set; }

    public static void Initialize()
    {
      Warsong = new Faction("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000", "HellScream");
      FactionSystem.Add(Warsong);
    }
  }
}