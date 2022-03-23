using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendDruids
  {
    public static Legend legendCenarius;
    public static Legend legendMalfurion;
    public static Legend legendFandral;
    public static Legend legendUrsoc;
    public static Legend legendTortolla;
    public static Legend legendNordrassil;

    public static int unittypeCenariusAlive = FourCC(""Ecen"");
    public static int unittypeCenariusGhost = FourCC(""E00H"");
    
    public static void Setup()
    {
      Legend.Register(legendCenarius = new Legend
      {
        UnitType = FourCC(""Ecen""),
        PermaDies = true,
        DeathMessage =
          "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor.",
        DeathSfx = "Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl",
        PlayerColor = PLAYER_COLOR_CYAN,
        StartingXp = 1000
      });

      Legend.Register(legendMalfurion = new Legend
      {
        UnitType = FourCC("Efur"),
        Essential = true
      });

      Legend.Register( legendFandral = new Legend
      {
        UnitType = FourCC("E00K")
      });

      Legend.Register(legendUrsoc = new Legend
      {
        UnitType = FourCC("E00A"),
        StartingXp = 7000
      });

      Legend.Register(legendNordrassil = new Legend
      {
        Unit = gg_unit_n002_0130,
        Capturable = true,
        IsCapital = true
      });

      Legend.Register(legendTortolla = new Legend
      {
        UnitType = FourCC("H04U"),
        StartingXp = 1800
      });
    }
  }
}