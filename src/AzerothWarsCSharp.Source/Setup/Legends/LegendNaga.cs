using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendNaga
  {
    public static Legend LegendIllidan { get; private set; }
    public static Legend LegendVashj { get; private set; }
    public static Legend LegendNajentus { get; private set; }
    public static Legend LegendAzshara { get; private set; }
    public static Legend LegendNzoth { get; private set; }
    public static Legend LegendAltruis { get; private set; }
    public static Legend LegendAkama { get; private set; }
    public static Legend LegendNazjatar { get; private set; }
    public static Legend LegendVault { get; private set; }

    public static void Setup()
    {
      LegendIllidan = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("Eill")),
        PlayerColor = PLAYER_COLOR_PURPLE
      };

      LegendVashj = new Legend
      {
        UnitType = FourCC("Hvsh"),
        StartingXp = 2800
      };

      LegendAzshara = new Legend
      {
        UnitType = FourCC("H08U")
      };

      LegendNajentus = new Legend
      {
        UnitType = FourCC("U00S"),
        StartingXp = 2800
      };

      LegendAltruis = new Legend
      {
        UnitType = FourCC("E015"),
        StartingXp = 4000
      };

      LegendAkama = new Legend
      {
        UnitType = FourCC("Naka"),
        StartingXp = 4000
      };

      LegendNzoth = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("U01Z")),
        DeathMessage = "N'zoth the Corruptor lay in wait for millenia before enacting final ploy. In the end, it was all for naught; N'zoth lies dead, and he will never witness the true floatization of his Black Empire.",
        PermaDies = true
      };

      LegendNazjatar = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n045")),
        DeathMessage = "The Eternal Palace, the royal seat of Queen Azshara and the Nazjatar Empire, has been destroyed.",
        IsCapital = true,
        Hivemind = true
      };

      LegendVault = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n05A")),
        DeathMessage = "The Aetheneum vault has been destroyed, and with it, ages of knowledge is lost.",
        IsCapital = true
      };
    }
  }
}