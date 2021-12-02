using AzerothWarsCSharp.Source.Libraries.MacroSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Factions
{
  public class LegionSetup
  {
    public static Faction Legion { get; private set; }

    public static void Initialize()
    {
      Legion = new Faction("Legion", PLAYER_COLOR_PEANUT, "|CFFBF8F4F", "Kiljaedin");
      FactionSystem.Add(Legion);
    }
  }
}