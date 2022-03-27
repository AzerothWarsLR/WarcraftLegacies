using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendNaga
  {
    public static Legend LEGEND_ILLIDAN { get; private set; }
    public static Legend LEGEND_VASHJ { get; private set; }
    public static Legend LEGEND_NAJENTUS { get; private set; }
    public static Legend LEGEND_AZSHARA { get; private set; }
    public static Legend LEGEND_NZOTH { get; private set; }
    public static Legend LEGEND_ALTRUIS { get; private set; }
    public static Legend LEGEND_AKAMA { get; private set; }
    public static Legend LEGEND_NAZJATAR { get; private set; }
    public static Legend LEGEND_VAULT { get; private set; }

    public static void Setup()
    {
      LEGEND_ILLIDAN = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("Eill")),
        PlayerColor = PLAYER_COLOR_PURPLE
      };

      LEGEND_VASHJ = new Legend
      {
        UnitType = FourCC("Hvsh"),
        StartingXp = 2800
      };

      LEGEND_AZSHARA = new Legend
      {
        UnitType = FourCC("H08U")
      };

      LEGEND_NAJENTUS = new Legend
      {
        UnitType = FourCC("U00S"),
        StartingXp = 2800
      };

      LEGEND_ALTRUIS = new Legend
      {
        UnitType = FourCC("E015"),
        StartingXp = 4000
      };

      LEGEND_AKAMA = new Legend
      {
        UnitType = FourCC("Naka"),
        StartingXp = 4000
      };

      LEGEND_NZOTH = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("U01Z")),
        DeathMessage = "N'zoth the Corruptor lay in wait for millenia before enacting final ploy. In the end, it was all for naught; N'zoth lies dead, and he will never witness the true floatization of his Black Empire.",
        PermaDies = true
      };

      LEGEND_NAZJATAR = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n045")),
        DeathMessage = "The Eternal Palace, the royal seat of Queen Azshara and the Nazjatar Empire, has been destroyed.",
        IsCapital = true,
        Hivemind = true
      };

      LEGEND_VAULT = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n05A")),
        DeathMessage = "The Aetheneum vault has been destroyed, and with it, ages of knowledge is lost.",
        IsCapital = true
      };
    }
  }
}