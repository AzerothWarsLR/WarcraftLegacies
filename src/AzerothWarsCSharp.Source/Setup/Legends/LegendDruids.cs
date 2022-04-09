using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendDruids
  {
    public static Legend LegendCenarius { get; private set; }
    public static Legend LegendMalfurion { get; private set; }
    public static Legend LegendFandral { get; private set; }
    public static Legend LegendUrsoc { get; private set; }
    public static Legend LegendTortolla { get; private set; }
    public static Legend LegendNordrassil { get; private set; }
    public static int UnittypeCenariusAlive { get; private set; } = FourCC("Ecen");
    public static int UnittypeCenariusGhost { get; private set; } = FourCC("E00H");
    
    public static void Setup()
    {
      Legend.Register(LegendCenarius = new Legend
      {
        UnitType = FourCC("Ecen"),
        PermaDies = true,
        DeathMessage =
          "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor.",
        DeathSfx = "Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl",
        PlayerColor = PLAYER_COLOR_CYAN,
        StartingXp = 1000
      });

      Legend.Register(LegendMalfurion = new Legend
      {
        UnitType = FourCC("Efur"),
        Essential = true
      });

      Legend.Register( LegendFandral = new Legend
      {
        UnitType = FourCC("E00K")
      });

      Legend.Register(LegendUrsoc = new Legend
      {
        UnitType = FourCC("E00A"),
        StartingXp = 7000
      });

      Legend.Register(LegendNordrassil = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n002")),
        Capturable = true,
        IsCapital = true
      });

      Legend.Register(LegendTortolla = new Legend
      {
        UnitType = FourCC("H04U"),
        StartingXp = 1800
      });
    }
  }
}