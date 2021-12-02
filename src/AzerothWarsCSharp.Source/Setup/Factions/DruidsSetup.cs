using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class DruidsSetup
  {
    public static Faction Druids { get; private set; }

    public static void Initialize()
    {
      Druids = new Faction("Druids", PLAYER_COLOR_BROWN, "|c004e2a04", "Furion");
      FactionSystem.Add(Druids);
    }
  }
}