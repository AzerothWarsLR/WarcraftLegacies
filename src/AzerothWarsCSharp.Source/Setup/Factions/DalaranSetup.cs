using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class DalaranSetup
  {
    public static Faction Dalaran { get; private set; }

    public static void Initialize()
    {
      Dalaran = new Faction("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0", "Jaina");
      FactionSystem.Add(Dalaran);
    }
  }
}