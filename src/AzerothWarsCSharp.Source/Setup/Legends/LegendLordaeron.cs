using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendLordaeron
  {
    public static Legend LegendUther { get; private set; }
    public static Legend LegendArthas { get; private set; }
    public static Legend LegendMograine { get; private set; }
    public static Legend LegendGarithos { get; private set; }
    public static Legend LegendGoodchild { get; private set; }
    public static Legend LegendCapitalpalace { get; private set; }
    public static Legend LegendStratholme { get; private set; }
    public static Legend LegendTyrshand { get; private set; }
    
    public static void Setup()
    {
      LegendMograine = new Legend
      {
        UnitType = FourCC("H01J"),
        StartingXp = 2800
      };

      LegendGarithos = new Legend
      {
        UnitType = FourCC("Hlgr"),
        StartingXp = 2800
      };

      LegendGoodchild = new Legend
      {
        UnitType = FourCC("E00O"),
        StartingXp = 2800
      };

      LegendCapitalpalace = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h000")),
        DeathMessage = "The capital city of Lordaeron has been razed, and King Terenas is dead.",
        IsCapital = true
      };

      LegendStratholme = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h01G")),
        DeathMessage = "The majestic city of Stratholme has been destroyed.",
        IsCapital = true
      };

      LegendTyrshand = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h030")),
        DeathMessage = "Tyr's Hand, the bastion of human power in Lordaeron, has fallen.",
        IsCapital = true
      };

      LegendUther = new Legend
      {
        UnitType = FourCC("Huth")
      };
      LegendUther.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("h000")));
      LegendUther.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nico")));
      LegendUther.DeathMessage =
        "Uther the Lightbringer makes his last stand, perishing in the defense of the light. Lordaeron, and humanity itself, has lost one of its finest exemplars in this dark hour.";
      LegendUther.PlayerColor = PLAYER_COLOR_LIGHT_BLUE;
      LegendUther.StartingXp = 1000;

      LegendArthas = new Legend
      {
        UnitType = FourCC("Hart"),
        PlayerColor = PLAYER_COLOR_BLUE
      };
      LegendArthas.AddUnitDependency(LegendStratholme.Unit);
      LegendArthas.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nico")));
      LegendArthas.Essential = true;
    }
  }
}