using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendDruids
  {
    public static Legend LEGEND_CENARIUS;
    public static Legend LEGEND_MALFURION;
    public static Legend LEGEND_FANDRAL;
    public static Legend LEGEND_URSOC;
    public static Legend LEGEND_TORTOLLA;
    public static Legend LEGEND_NORDRASSIL;

    public static int UNITTYPE_CENARIUS_ALIVE = FourCC("Ecen");
    public static int UNITTYPE_CENARIUS_GHOST = FourCC("E00H");
    
    public static void Setup()
    {
      Legend.Register(LEGEND_CENARIUS = new Legend
      {
        UnitType = FourCC("Ecen"),
        PermaDies = true,
        DeathMessage =
          "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor.",
        DeathSfx = "Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl",
        PlayerColor = PLAYER_COLOR_CYAN,
        StartingXp = 1000
      });

      Legend.Register(LEGEND_MALFURION = new Legend
      {
        UnitType = FourCC(Efur),
        Essential = true
      });

      Legend.Register( LEGEND_FANDRAL = new Legend
      {
        UnitType = FourCC(E00K)
      });

      Legend.Register(LEGEND_URSOC = new Legend
      {
        UnitType = FourCC(E00A),
        StartingXp = 7000
      });

      Legend.Register(LEGEND_NORDRASSIL = new Legend
      {
        Unit = gg_unit_n002_0130,
        Capturable = true,
        IsCapital = true
      });

      Legend.Register(LEGEND_TORTOLLA = new Legend
      {
        UnitType = FourCC(H04U),
        StartingXp = 1800
      });
    }
  }
}