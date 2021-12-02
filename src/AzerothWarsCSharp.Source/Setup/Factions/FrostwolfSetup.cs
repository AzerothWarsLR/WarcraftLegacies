using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class FrostwolfSetup
  {
    public static Faction Frostwolf { get; private set; }

    public static void Initialize()
    {
      Frostwolf = new Faction("Frostwolf", PLAYER_COLOR_RED, "|c00ff0303", "Thrall.blp");
      FactionSystem.Add(Frostwolf);
    }
  }
}