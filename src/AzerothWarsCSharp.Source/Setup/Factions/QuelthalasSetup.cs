using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class QuelthalasSetup
  {
    public static Faction Quelthalas { get; private set; }

    public static void Initialize()
    {
      Quelthalas = new Faction("Quel'thalas", PLAYER_COLOR_CYAN, "|C0000FFFF", "SylvanusWindrunner");
      FactionSystem.Add(Quelthalas);
    }
  }
}