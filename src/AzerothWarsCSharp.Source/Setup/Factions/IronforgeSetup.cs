using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class IronforgeSetup
  {
    public static Faction Ironforge { get; private set; }

    public static void Initialize()
    {
      Ironforge = new Faction("Ironforge", PLAYER_COLOR_YELLOW, "|C00FFFC01", "HeroMountainKing");
      FactionSystem.Add(Ironforge);
    }
  }
}