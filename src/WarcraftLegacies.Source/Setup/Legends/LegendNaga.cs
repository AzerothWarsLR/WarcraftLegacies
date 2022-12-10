using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendNaga
  {
    public static Legend LegendIllidan { get; private set; }
    public static Legend LegendVashj { get; private set; }
    public static Legend LegendNajentus { get; private set; }
    public static Legend LegendAzshara { get; private set; }
    public static Legend LegendAltruis { get; private set; }
    public static Legend LegendAkama { get; private set; }

    public static void Setup()
    {
      LegendIllidan = new Legend
      {
        UnitType = FourCC("Eill"),
        PlayerColor = PLAYER_COLOR_PURPLE,
        Name = "Illidan"
      };
      Legend.Register(LegendIllidan);

      LegendVashj = new Legend
      {
        UnitType = FourCC("Hvsh"),
        StartingXp = 2800,
        Name = "Lady Vashj"
      };
      Legend.Register(LegendVashj);

      LegendAzshara = new Legend
      {
        UnitType = FourCC("H08U"),
        Name = "Azshara"
      };
      Legend.Register(LegendAzshara);

      LegendNajentus = new Legend
      {
        UnitType = FourCC("U00S"),
        StartingXp = 2800,
        Name = "Warlord Najentus"
      };
      Legend.Register(LegendNajentus);

      LegendAltruis = new Legend
      {
        UnitType = FourCC("E015"),
        Name = "Altruis"
      };
      Legend.Register(LegendAltruis);

      LegendAkama = new Legend
      {
        UnitType = FourCC("Naka"),
        StartingXp = 4000,
        Name = "Akama"
      };
      Legend.Register(LegendAkama);
    }
  }
}